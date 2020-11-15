//Author Maxim Kuzmin//makc//

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Logging;
using Makc2020.Core.Web.Ext;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Ldap;
using Makc2020.Host.Base.Parts.Ldap.Jobs.Login;
using Makc2020.Host.Web;
using Makc2020.Mods.IdentityServer.Base.Enums;
using Makc2020.Mods.IdentityServer.Base.Exceptions;
using Makc2020.Mods.IdentityServer.Web.Ext;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountService
    {
        #region Properties

        private static HttpClient HttpClient { get; } = new HttpClient();

        private IModIdentityServerWebMvcPartAccountConfigSettings ConfigSettings { get; set; }

        private DataEntityDbFactory DbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="configSettings">Конфигурационные настройки.</param> 
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public ModIdentityServerWebMvcPartAccountService(
            IModIdentityServerWebMvcPartAccountConfigSettings configSettings,
            DataEntityDbFactory dbFactory
            )
        {
            ConfigSettings = configSettings;
            DbFactory = dbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать получение входа в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public Task<ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput> GetLoginProcess(
            ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput input
            )
        {
            return ProcessLoginGet(input.IsFirstLogin, input.ReturnUrl, input.HttpRequest);
        }

        /// <summary>
        /// Создать отклик на получение входа в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> GetLoginProduce(
            ModIdentityServerWebMvcPartAccountJobLoginGetProduceInput input
            )
        {
            return ProduceLoginGet(
                input.ReturnUrl,
                ModIdentityServerBaseEnumLoginMethods.WindowsDomain,
                input.Interaction,
                input.HttpContext
                );
        }

        /// <summary>
        /// Обработать отправку данных входа в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput> PostLoginProcess(
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput input
        )
        {
            return new ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput
            {
                LoginMethodCookieName = ConfigSettings.LoginMethodCookieName,
                LoginUserNameCookieName = ConfigSettings.LoginUserNameCookieName,
                RememberLoginDurationInDays = ConfigSettings.RememberLoginDurationInDays,
                Status = input.Model.LoginMethod switch
                {
                    ModIdentityServerBaseEnumLoginMethods.Ldap =>
                        await ProcessLoginPostLdap(
                            input.Model,
                            input.Action,
                            input.Events,
                            input.ModelState,
                            input.UrlHelper,
                            input.UserManager,
                            input.Interaction,
                            input.СlientStore,
                            input.HttpContext,
                            input.Logger,
                            input.JobLdapLogin
                            ).CoreBaseExtTaskWithCurrentCulture(false),
                    ModIdentityServerBaseEnumLoginMethods.WindowsDomain =>
                        await ProcessLoginLPostWindowsDomain(
                            input.Model,
                            input.Action,
                            input.Events,
                            input.ModelState,
                            input.UrlHelper,
                            input.UserManager,
                            input.Interaction,
                            input.СlientStore,
                            input.HttpContext,
                            input.Logger
                            ).CoreBaseExtTaskWithCurrentCulture(false),
                    _ => await ProcessLoginPostLocal(
                            input.Model,
                            input.Action,
                            input.Events,
                            input.ModelState,
                            input.SignInManager,
                            input.HttpContext,
                            input.UrlHelper,
                            input.UserManager,
                            input.Interaction,
                            input.СlientStore
                            ).CoreBaseExtTaskWithCurrentCulture(false)
                }
            };
        }

        /// <summary>
        /// Создать отклик на отправку данных входа в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> PostLoginProduce(
            ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput input
        )
        {
            return ProduceLoginGet(
                input.Model.ReturnUrl,
                input.Model.LoginMethod,
                input.Interaction,
                input.HttpContext
                );
        }

        /// <summary>
        /// Получить выход из системы.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public Task<ModIdentityServerWebMvcPartAccountJobLogoutGetOutput> GetLogout(
            ModIdentityServerWebMvcPartAccountJobLogoutGetInput input
            )
        {
            return ProduceLogoutGet(
                input.LogoutId,
                input.Interaction,
                input.User
                );
        }

        /// <summary>
        /// Обработать отправку данных выхода из системы.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput> PostLogoutProcess(
            ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput input
            )
        {
            return new ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput
            {
                Status = await ProcessLogoutPost(
                input.Model,
                input.Events,
                input.SignInManager,
                input.HttpContext,
                input.Interaction,
                input.User
                ).CoreBaseExtTaskWithCurrentCulture(false)
            };
        }

        /// <summary>
        /// Создать отклик на отправку данных выхода из системы.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput> PostLogoutProduce(
            ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput input
            )
        {
            return ProduceLogoutPost(
                input.Model.LogoutId,
                input.HttpContext,
                input.Interaction,
                input.User
                );
        }

        #endregion Public methods

        #region Private methods

        private string CreateSessionId()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        private List<string> GetDomainUserGroupNames(string userName)
        {
            List<string> result = null;

            UserPrincipal user = null;

            try
            {
                //makc!!!//var context = new PrincipalContext(ContextType.Machine);
                var context = new PrincipalContext(ContextType.Domain);

                user = UserPrincipal.FindByIdentity(context, userName);
            }
            catch
            {
                throw new ModIdentityServerBaseExceptionDomainUserNotFound
                {
                    UserName = userName
                };
            }

            if (user != null)
            {
                try
                {
                    var groups = user.GetAuthorizationGroups();

                    result = groups.Select(x => x.Name).ToList();
                }
                catch
                {
                    throw new ModIdentityServerBaseExceptionDomainUserGroupsNotFound
                    {
                        UserName = userName
                    };
                }
            }

            return result;
        }

        private ModIdentityServerBaseEnumLoginMethods GetLoginMethod(IRequestCookieCollection cookies)
        {
            var result = ModIdentityServerBaseEnumLoginMethods.WindowsDomain;

            if (cookies.TryGetValue(ConfigSettings.LoginMethodCookieName, out var loginMethodCookieValue))
            {
                if (int.TryParse(loginMethodCookieValue, out int value))
                {
                    result = (ModIdentityServerBaseEnumLoginMethods)value;
                }
            }

            return result;
        }

        private string GetLoginUserName(IRequestCookieCollection cookies)
        {
            cookies.TryGetValue(ConfigSettings.LoginUserNameCookieName, out var result);

            return result;
        }

        private bool IsUserFromDomain(DataEntityObjectUser user)
        {
            return user.UserName.Contains("\\");
        }

        private void LogActiveDirectoryUserInfoOnTestOrDebug(
            CoreBaseLoggingService logger,
            string userName,
            List<string> groupNames
            )
        {
            if (logger != null)
            {
                var msg = new
                {
                    userName,
                    groupNames = string.Join("', '", groupNames)
                }.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger);

                logger.LogDebug(msg);
            }
        }

        private HostBasePartLdapUser LoginViaLdap(
            CoreBaseLoggingService logger,
            HostBasePartLdapJobLoginService job,
            string userName,
            string password
            )
        {
            var result = new CoreBaseExecutionResultWithData<HostBasePartLdapUser>();

            var input = new HostBasePartLdapJobLoginInput
            {
                Password = password,
                UserName = userName
            };

            try
            {
                result.Data = job.Execute(input);

                job.OnSuccess(logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, logger, result);
            }

            return result.Data;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> ProcessLoginPostLocal(
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            string action,
            IEventService events,
            ModelStateDictionary modelState,
            SignInManager<DataEntityObjectUser> signInManager,
            HttpContext httpContext,
            IUrlHelper urlHelper,
            UserManager<DataEntityObjectUser> userManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore
        )
        {
            // check if we are in the context of an authorization request
            var context = await interaction.GetAuthorizationContextAsync(model.ReturnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            // the user clicked the "cancel" button
            if (action != ModIdentityServerWebMvcSettings.ACTION_Login)
            {
                return await CheckContext(context, clientStore, interaction)
                    .CoreBaseExtTaskWithCurrentCulture(false);
            }
            else if (modelState.IsValid)
            {
                if (ConfigSettings.AllowLoginWithoutPassword)
                {
                    if (model.Password == null)
                    {
                        model.Password = "";
                    }
                }

                var user = await userManager.FindByNameAsync(model.Username)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (user != null)
                {
                    if (!IsUserFromDomain(user))
                    {
                        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false)
                            .CoreBaseExtTaskWithCurrentCulture(false);

                        if (result.Succeeded)
                        {
                            var sessionId = CreateSessionId();

                            await SignIn(
                                httpContext,
                                context,
                                events,
                                user,
                                user.UserName,
                                sessionId,
                                new[] { user.Id },
                                model.RememberLogin
                                ).CoreBaseExtTaskWithCurrentCulture(false);

                            if (context != null)
                            {
                                var isPckeRequired = await clientStore.ModIdentityServerWebExtClientIsPkceRequired(context.ClientId)
                                    .CoreBaseExtTaskWithCurrentCulture(false);

                                if (isPckeRequired)
                                {
                                    // if the client is PKCE then we assume it's native, so this change in how to
                                    // return the response is for better UX for the end user.
                                    return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Redirect;
                                }

                                // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                                return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return;
                            }

                            // request for a local page
                            if (urlHelper.IsLocalUrl(model.ReturnUrl))
                            {
                                return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return;
                            }
                            else if (string.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Index;
                            }
                            else
                            {
                                // user might have clicked on a malicious link - should be logged
                                throw new ModIdentityServerBaseExceptionInvalidReturnUrl();
                            }
                        }
                    }
                }

                await events.RaiseAsync(
                    new UserLoginFailureEvent(
                        model.Username,
                        "invalid credentials",
                        clientId: context?.ClientId
                        )
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                throw new ModIdentityServerBaseExceptionLogin();
            }

            return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> ProcessLoginPostLdap(
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            string action,
            IEventService events,
            ModelStateDictionary modelState,
            IUrlHelper urlHelper,
            UserManager<DataEntityObjectUser> userManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            HttpContext httpContext,
            CoreBaseLoggingService logger,
            HostBasePartLdapJobLoginService jobLdapLogin
            )
        {
            // check if we are in the context of an authorization request
            var context = await interaction.GetAuthorizationContextAsync(model.ReturnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (action != ModIdentityServerWebMvcSettings.ACTION_Login)
            {
                return await CheckContext(context, clientStore, interaction).CoreBaseExtTaskWithCurrentCulture(false);
            }
            else if (modelState.IsValid)
            {
                var ldapUser = LoginViaLdap(logger, jobLdapLogin, model.Username, model.Password);

                if (ldapUser == null)
                {
                    throw new ModIdentityServerBaseExceptionLdapLoginFailed();
                }

                var connection = ldapUser.LdapConnection;

                var groupNames = new List<string>();

                var port = ldapUser.LdapConnection.Port;
                var host = ldapUser.LdapConnection.Host;

                var dcArray = host.Split('.').TakeLast(2).ToArray();

                //Этот код был написан, чтобы не вызывать ошибки LDAPReferralException
                //при вызове ниже в try/catch метода Next() на переменной searchResults.
                //Однако если его раскомментировать, возникнет ошибка "Operations error".
                //Видимо, не хватает прав, поэтому расскоментировать пока не будем.
                //LdapSearchConstraints cons = connection.SearchConstraints;
                //cons.ReferralFollowing = true;
                //connection.Constraints = cons;

                connection.Connect(host, port);

                connection.Bind(LdapConnection.LdapV3, ldapUser.UserName, model.Password);

                if (connection.Bound)
                {
                    const string attrName = "memberOf";

                    var searchResults = ldapUser.LdapConnection.Search(
                        $"DC={dcArray[0]},DC={dcArray[1]}", //You can use String.Empty for all domain search.
                        LdapConnection.ScopeSub,//Use SUB
                        $"(sAMAccountName={model.Username})",
                        new[] { attrName }, // no specified attributes
                        false // return attr and value
                        );

                    while (searchResults.HasMore())
                    {
                        try
                        {
                            var nextEntry = searchResults.Next();

                            var attrs = nextEntry.GetAttributeSet();

                            if (attrs.TryGetValue(attrName, out var attr))
                            {
                                var attrValue = attr.StringValue;

                                if (!string.IsNullOrWhiteSpace(attrValue))
                                {
                                    var matches = Regex.Matches(attrValue, @"CN=([A-Za-zА-Яа-я_\s]*),");

                                    foreach (Match match in matches)
                                    {
                                        if (match.Groups.Count > 1)
                                        {
                                            var groupName = match.Groups[1].Value;

                                            if (!string.IsNullOrWhiteSpace(groupName))
                                            {
                                                groupNames.Add(groupName);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is LdapReferralException)
                            {
                                continue;
                            }

                            throw new ModIdentityServerBaseExceptionLdapGroupsSearchFailed(ex.Message);
                        }
                    }
                }

                return await ProcessLoginPostActiveDirectory(
                    model.Username,
                    groupNames,
                    model,
                    events,
                    urlHelper,
                    userManager,
                    clientStore,
                    httpContext,
                    context,
                    logger
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput> ProcessLoginGet(
            bool? isFirstLogin,
            string returnUrl,
            HttpRequest httpRequest
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput();

            if (isFirstLogin.HasValue)
            {
                var loginMethod = GetLoginMethod(httpRequest.Cookies);

                result.IsWindowsAuthenticationNeeded = isFirstLogin.Value
                    &&
                    ConfigSettings.IsWindowsAuthenticationMandatory
                    &&
                    loginMethod == ModIdentityServerBaseEnumLoginMethods.WindowsDomain;

                return result;
            }

            var oldReturnUri = new Uri(new Uri("http://fake"), returnUrl);

            var oldReturnQs = HttpUtility.ParseQueryString(oldReturnUri.Query);

            var oldReturnQsState = oldReturnQs["state"];

            if (string.IsNullOrWhiteSpace(oldReturnQsState))
            {
                return result;
            }

            var oldReturnQsNonce = oldReturnQs["nonce"];
            Uri oldStateUri;
            bool newPortal = oldReturnQsNonce != null && oldReturnQsState.Contains(oldReturnQsNonce);

            if (newPortal)
            {
                var oldState = HttpUtility.UrlDecode(oldReturnQsState.Substring(oldReturnQsNonce.Length + 1));

                oldStateUri = new Uri(new Uri("http://fake"), oldState);
            }
            else
            {
                oldStateUri = new Uri(new Uri("http://fake"), HttpUtility.UrlDecode(oldReturnUri.Query));
            }

            var oldStateQs = HttpUtility.ParseQueryString(oldStateUri.Query);

            string oldStateQsIsFirstLogin;
            string oldStateQsLang;

            if (newPortal)
            {
                oldStateQsIsFirstLogin = oldStateQs[ConfigSettings.ClientIsFirstLoginParamName];
                oldStateQsLang = oldStateQs[ConfigSettings.ClientLangParamName];
                oldStateQs.Remove(ConfigSettings.ClientIsFirstLoginParamName);

                var newState = HttpUtility.UrlEncode($"{oldStateUri.LocalPath}{oldStateQs.CoreWebExtConvertToQueryString()}");
                var newReturnQsState = $"{oldReturnQsNonce};{newState}";

                oldReturnQs["state"] = newReturnQsState;
            }
            else
            {
                oldStateQsIsFirstLogin = oldReturnQs[ConfigSettings.ClientIsFirstLoginParamName];
                oldStateQsLang = oldReturnQs[ConfigSettings.ClientLangParamName];
                oldReturnQs.Remove(ConfigSettings.ClientIsFirstLoginParamName);
            }

            var newReturnQs = oldReturnQs.CoreWebExtConvertToQueryString(newPortal ? new[] { "response_type", "state", "scope" } : oldReturnQs.AllKeys);

            var newReturnUrl = $"{oldReturnUri.LocalPath}{newReturnQs}";

            var oldRedirectUrl = httpRequest.GetEncodedUrl();

            var redirectUrlPrefix = oldRedirectUrl.Split("?").First();

            var oldRedirectUri = new Uri(oldRedirectUrl);

            var oldRedirectQs = HttpUtility.ParseQueryString(oldRedirectUri.Query);

            oldRedirectQs[HostWebSettings.PARAM_IsFirstLogin] = oldStateQsIsFirstLogin == ConfigSettings.ClientIsFirstLoginParamValue ? "true" : "false";

            if (!string.IsNullOrWhiteSpace(oldStateQsLang))
            {
                oldRedirectQs[HostWebSettings.PARAM_Lang] = oldStateQsLang;
            }

            oldRedirectQs[HostWebSettings.PARAM_ReturnUrl] = newReturnUrl;

            var newRedirectQs = oldRedirectQs.CoreWebExtConvertToQueryString();

            if (newPortal)
            {
                newRedirectQs = newRedirectQs.Replace("%3b", ";", StringComparison.InvariantCultureIgnoreCase);
            }

            result.RedirectUrl = $"{redirectUrlPrefix}{newRedirectQs}{oldRedirectUri.Fragment}";

            return await Task.FromResult(result).CoreBaseExtTaskWithCurrentCulture(false);
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> ProcessLoginLPostWindowsDomain(
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            string action,
            IEventService events,
            ModelStateDictionary modelState,
            IUrlHelper urlHelper,
            UserManager<DataEntityObjectUser> userManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            HttpContext httpContext,
            CoreBaseLoggingService logger
            )
        {
            // check if we are in the context of an authorization request
            var context = await interaction.GetAuthorizationContextAsync(model.ReturnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            modelState.Clear();

            if (action != ModIdentityServerWebMvcSettings.ACTION_Login)
            {
                return await CheckContext(context, clientStore, interaction).CoreBaseExtTaskWithCurrentCulture(false);
            }
            else if (modelState.IsValid)
            {
                // see if windows auth has already been requested and succeeded
                var result = await httpContext.AuthenticateAsync(
                    ModIdentityServerWebMvcSettings.AUTHENTICATION_SCHEME_Windows
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                if (result?.Principal is WindowsPrincipal)
                {
                    var userName = result.Principal.Identity.Name;

                    var groupNames = GetDomainUserGroupNames(userName);

                    return await ProcessLoginPostActiveDirectory(
                        userName,
                        groupNames,
                        model,
                        events,
                        urlHelper,
                        userManager,
                        clientStore,
                        httpContext,
                        context,
                        logger
                        ).CoreBaseExtTaskWithCurrentCulture(false);
                }

                return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Windows;
            }

            return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> CheckContext(
            AuthorizationRequest context,
            IClientStore clientStore,
            IIdentityServerInteractionService interaction
            )
        {
            if (context != null)
            {
                // if the user cancels, send a result back into IdentityServer as if they 
                // denied the consent (even if this client does not require consent).
                // this will send back an access denied OIDC error response to the client.
                await interaction.GrantConsentAsync(context, ConsentResponse.Denied)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var isPckeRequired = await clientStore.ModIdentityServerWebExtClientIsPkceRequired(context.ClientId)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                if (isPckeRequired)
                {
                    // if the client is PKCE then we assume it's native, so this change in how to
                    // return the response is for better UX for the end user.
                    return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Redirect;
                }

                return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return;
            }
            else
            {
                // since we don't have a valid context, then we just go back to the home page
                return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Index;
            }
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> ProcessLoginPostActiveDirectory(
            string userName,
            List<string> groupNames,
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            IEventService events,
            IUrlHelper urlHelper,
            UserManager<DataEntityObjectUser> userManager,
            IClientStore clientStore,
            HttpContext httpContext,
            AuthorizationRequest context,
            CoreBaseLoggingService logger
            )
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                if (groupNames == null)
                {
                    throw new ModIdentityServerBaseExceptionLdapUserHasNotGroups();
                }

#if TEST || DEBUG
                LogActiveDirectoryUserInfoOnTestOrDebug(logger, userName, groupNames);
#endif
                var users = new List<DataEntityObjectUser>();

                var user = await userManager.FindByNameAsync(userName)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (user != null)
                {
                    if (IsUserFromDomain(user))
                    {
                        users.Add(user);
                    }
                }

                foreach (var groupName in groupNames)
                {
                    var groupUser = await userManager.FindByNameAsync(groupName)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (groupUser != null)
                    {
                        if (IsUserFromDomain(user))
                        {
                            if (user == null)
                            {
                                user = groupUser;
                            }

                            users.Add(groupUser);
                        }
                    }
                }

                if (user == null)
                {
                    throw new ModIdentityServerBaseExceptionLdapLoginFailed();
                }

                var userIds = users.Select(x => x.Id).ToArray();

                var sessionId = CreateSessionId();

                await SignIn(
                    httpContext,
                    context,
                    events,
                    user,
                    userName,
                    sessionId,
                    userIds,
                    model.RememberLogin
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                if (context != null)
                {
                    var isPckeRequired = await clientStore.ModIdentityServerWebExtClientIsPkceRequired(context.ClientId)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (isPckeRequired)
                    {
                        // if the client is PKCE then we assume it's native, so this change in how to
                        // return the response is for better UX for the end user.
                        return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Redirect;
                    }

                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                    return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return;
                }

                // request for a local page
                if (urlHelper.IsLocalUrl(model.ReturnUrl))
                {
                    return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return;
                }
                else if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Index;
                }
                else
                {
                    // user might have clicked on a malicious link - should be logged
                    throw new ModIdentityServerBaseExceptionInvalidReturnUrl();
                }
            }

            await events.RaiseAsync(
                new UserLoginFailureEvent(
                    userName,
                    "invalid credentials",
                    clientId: context?.ClientId
                    )
                ).CoreBaseExtTaskWithCurrentCulture(false);

            throw new ModIdentityServerBaseExceptionLogin();
        }

        private async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> ProduceLoginGet(
            string returnUrl,
            ModIdentityServerBaseEnumLoginMethods loginMethod,
            IIdentityServerInteractionService interaction,
            HttpContext httpContext
            )
        {
            var context = await interaction.GetAuthorizationContextAsync(returnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginOutput
            {
                LoginMethod = loginMethod,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
            };

            if (httpContext.Request.Method == "GET")
            {
                result.LoginMethod = GetLoginMethod(httpContext.Request.Cookies);
                result.Username = GetLoginUserName(httpContext.Request.Cookies);
            }

            return result;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutGetOutput> ProduceLogoutGet(
            string logoutId,
            IIdentityServerInteractionService interaction,
            ClaimsPrincipal user
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLogoutGetOutput
            {
                LogoutId = logoutId,
                ShowLogoutPrompt = ConfigSettings.ShowLogoutPrompt
            };

            if (user?.Identity.IsAuthenticated != true)
            {
                // if the user is not authenticated, then just show logged out page
                result.ShowLogoutPrompt = false;

                return result;
            }

            var context = await interaction.GetLogoutContextAsync(logoutId)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (context?.ShowSignoutPrompt == false)
            {
                // it's safe to automatically sign-out
                result.ShowLogoutPrompt = false;

                return result;
            }

            // show the logout prompt. this prevents attacks where the user
            // is automatically signed out by another malicious web page.
            return result;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessEnumStatuses> ProcessLogoutPost(
            ModIdentityServerWebMvcPartAccountViewLogoutModel model,
            IEventService events,
            SignInManager<DataEntityObjectUser> signInManager,
            HttpContext httpContext,
            IIdentityServerInteractionService interaction,
            ClaimsPrincipal principal
            )
        {
            // build a model so the logged out page knows what to display
            var vm = await ProduceLogoutPost(
                model.LogoutId,
                httpContext,
                interaction,
                principal
                ).CoreBaseExtTaskWithCurrentCulture(false);

            if (principal?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await signInManager.SignOutAsync().CoreBaseExtTaskWithCurrentCulture(false);

                // raise the logout event
                await events.RaiseAsync(
                    new UserLogoutSuccessEvent(
                        principal.GetSubjectId(),
                        principal.GetDisplayName()
                        )
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            // check if we need to trigger sign-out at an upstream identity provider
            if (vm.TriggerExternalSignout)
            {
                // this triggers a redirect to the external provider for sign-out
                return ModIdentityServerWebMvcPartAccountJobLogoutPostProcessEnumStatuses.Default;
            }

            return ModIdentityServerWebMvcPartAccountJobLogoutPostProcessEnumStatuses.LoggedOut;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput> ProduceLogoutPost(
            string logoutId,
            HttpContext httpContext,
            IIdentityServerInteractionService interaction,
            ClaimsPrincipal user
            )
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var context = await interaction.GetLogoutContextAsync(logoutId)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var referer = httpContext.Request.Headers["Referer"].FirstOrDefault();

            var result = new ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput
            {
                AutomaticRedirectAfterSignOut = ConfigSettings.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = context?.PostLogoutRedirectUri ?? referer,
                ClientName = string.IsNullOrEmpty(context?.ClientName) ? context?.ClientId : context?.ClientName,
                SignOutIframeUrl = context?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (user?.Identity.IsAuthenticated == true)
            {
                var idp = user.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;

                if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await httpContext.GetSchemeSupportsSignOutAsync(idp)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (providerSupportsSignout)
                    {
                        if (result.LogoutId == null)
                        {
                            // if there's no current logout context, we need to create one
                            // this captures necessary info from the current logged in user
                            // before we signout and redirect away to the external IdP for signout
                            result.LogoutId = await interaction.CreateLogoutContextAsync()
                                .CoreBaseExtTaskWithCurrentCulture(false);
                        }

                        result.ExternalAuthenticationScheme = idp;
                    }
                }
            }

            return result;
        }

        private async Task SignIn(
            HttpContext httpContext,
            AuthorizationRequest context,
            IEventService events,
            DataEntityObjectUser user,
            string userName,
            string sessionId,
            IEnumerable<long> userIds,
            bool rememberLogin
            )
        {
            AuthenticationProperties props = null;

            if (rememberLogin)
            {
                props = new AuthenticationProperties
                {
                    IsPersistent = true
                };
            }

            // issue authentication cookie with subject ID and username
            await httpContext.SignInAsync(
                user.Id.ToString(),
                user.UserName,
                props,
                new Claim(HostBasePartAuthSettings.CLAIM_SessionId, sessionId),
                new Claim(HostBasePartAuthSettings.CLAIM_UserIds, string.Join(",", userIds)),
                new Claim(HostBasePartAuthSettings.CLAIM_UserName, userName)
                ).CoreBaseExtTaskWithCurrentCulture(false);

            await events.RaiseAsync(
                new UserLoginSuccessEvent(
                    user.UserName,
                    user.Id.ToString(),
                    userName,
                    clientId: context?.ClientId
                    )
                ).CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Private methods
    }
}