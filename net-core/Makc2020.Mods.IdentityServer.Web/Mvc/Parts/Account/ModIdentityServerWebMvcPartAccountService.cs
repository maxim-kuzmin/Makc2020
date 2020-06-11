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
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
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

        private IModIdentityServerWebMvcPartAccountConfigSettings ConfigSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="configSettings">Конфигурационные настройки.</param> 
        public ModIdentityServerWebMvcPartAccountService(
            IModIdentityServerWebMvcPartAccountConfigSettings configSettings
            )
        {
            ConfigSettings = configSettings;
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
                input.SchemeProvider,
                input.СlientStore
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
                            input.RoleManager,
                            input.Logger,
                            input.JobLdapLogin,
                            input.JobUserEntityCreate
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
                            input.RoleManager,
                            input.Logger,
                            input.JobUserEntityCreate
                            ).CoreBaseExtTaskWithCurrentCulture(false),
                    _ => await ProcessLoginPostLocal(
                            input.Model,
                            input.Action,
                            input.Events,
                            input.ModelState,
                            input.SignInManager,
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
        public async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> PostLoginProduce(
            ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput input
        )
        {
            return await ProduceLoginGet(
                input.Model.ReturnUrl,
                input.Model.LoginMethod,
                input.Interaction,
                input.SchemeProvider,
                input.СlientStore
                ).CoreBaseExtTaskWithCurrentCulture(false);
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
        public async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput> PostLogoutProduce(
            ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput input
            )
        {
            return await ProduceLogoutPost(
                input.Model.LogoutId,
                input.HttpContext,
                input.Interaction,
                input.User
                ).CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods

        #region Private methods

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> ProcessLoginPostLocal(
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            string action,
            IEventService events,
            ModelStateDictionary modelState,
            SignInManager<DataEntityObjectUser> signInManager,
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
                var result = await signInManager.PasswordSignInAsync(
                    model.Username,
                    model.Password,
                    model.RememberLogin,
                    lockoutOnFailure: true
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(model.Username)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    await events.RaiseAsync(
                        new UserLoginSuccessEvent(
                            user.UserName,
                            user.Id.ToString(),
                            user.UserName,
                            clientId: context?.ClientId
                            )
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
            RoleManager<DataEntityObjectRole> roleManager,
            CoreBaseLoggingService logger,
            HostBasePartLdapJobLoginService jobLdapLogin,
            HostBasePartAuthJobUserEntityCreateService jobUserEntityCreate
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

                var groups = new List<string>();

                var port = ldapUser.LdapConnection.Port;
                var host = ldapUser.LdapConnection.Host;

                var dcArray = host.Split('.').TakeLast(2).ToArray();

                connection.Connect(host, port);

                connection.Bind(LdapConnection.LdapV3, ldapUser.UserName, model.Password);

                if (connection.Bound)
                {
                    ILdapSearchResults searchResults = ldapUser.LdapConnection.Search(
                        $"DC={dcArray[0]},DC={dcArray[1]}", //You can use String.Empty for all domain search.
                        LdapConnection.ScopeSub,//Use SUB
                        $"(sAMAccountName={model.Username})",
                        null, // no specified attributes
                        false // return attr and value
                    );

                    while (searchResults.HasMore())
                    {
                        try
                        {
                            var nextEntry = searchResults.Next();
                            nextEntry.GetAttributeSet();
                            var groupString = nextEntry.GetAttribute("memberOf").StringValue;
                            var pattern = @"CN=([A-Za-zА-Яа-я_\s]*),";
                            var matchesGroup = Regex.Matches(groupString, pattern);
                            groups.Add(matchesGroup.FirstOrDefault()?.Groups[1].Value);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                return await ProcessLoginPostActiveDirectoryKind(ldapUser.UserName,
                    groups,
                    model,
                    events,
                    urlHelper,
                    userManager,
                    clientStore,
                    httpContext,
                    roleManager,
                    logger,
                    jobUserEntityCreate,
                    context);
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

            var oldState = HttpUtility.UrlDecode(oldReturnQsState.Substring(oldReturnQsNonce.Length + 1));

            var oldStateUri = new Uri(new Uri("http://fake"), oldState);

            var oldStateQs = HttpUtility.ParseQueryString(oldStateUri.Query);

            var oldStateQsIsFirstLogin = oldStateQs[ConfigSettings.ClientIsFirstLoginParamName];
            var oldStateQsLang = oldStateQs[ConfigSettings.ClientLangParamName];

            oldStateQs.Remove(ConfigSettings.ClientIsFirstLoginParamName);

            var newState = HttpUtility.UrlEncode($"{oldStateUri.LocalPath}{oldStateQs.CoreWebExtConvertToQueryString()}");

            var newReturnQsState = $"{oldReturnQsNonce};{newState}";

            oldReturnQs["state"] = newReturnQsState;

            var newReturnQs = oldReturnQs.CoreWebExtConvertToQueryString(new[] { "response_type", "state", "scope" });

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

            var newRedirectQs = oldRedirectQs.CoreWebExtConvertToQueryString().Replace("%3b", ";", StringComparison.InvariantCultureIgnoreCase);

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
            RoleManager<DataEntityObjectRole> roleManager,
            CoreBaseLoggingService logger,
            HostBasePartAuthJobUserEntityCreateService jobUserEntityCreate
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
                    var groups = GetAdGroups(result.Principal.Identity.Name);

                    return await ProcessLoginPostActiveDirectoryKind(result.Principal.Identity.Name,
                        groups,
                        model,
                        events,
                        urlHelper,
                        userManager,
                        clientStore,
                        httpContext,
                        roleManager,
                        logger,
                        jobUserEntityCreate,
                        context
                        );
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

        private async Task<DataEntityObjectUser> AutoProvisionUserAsync(
            string userName,
            string fullName,
            string password,
            IEnumerable<string> roleNames,
            CoreBaseLoggingService logger,
            HostBasePartAuthJobUserEntityCreateService jobUserEntityCreate,
            RoleManager<DataEntityObjectRole> roleManager,
            UserManager<DataEntityObjectUser> userManager
        )
        {
            var input = new HostBasePartAuthJobUserEntityCreateInput
            {
                RoleManager = roleManager,
                UserManager = userManager,
                UserName = userName,
                FullName = fullName,
                RoleNames = roleNames,
                Password = password
            };

            var execResult = await CreateUserEntity(logger, jobUserEntityCreate, input)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (!execResult.IsOk)
            {
                throw new Exception(string.Join(". ", execResult.ErrorMessages));
            }

            return execResult.Data;
        }

        private async Task<CoreBaseExecutionResultWithData<DataEntityObjectUser>> CreateUserEntity(
            CoreBaseLoggingService logger,
            HostBasePartAuthJobUserEntityCreateService job,
            HostBasePartAuthJobUserEntityCreateInput input
            )
        {
            var result = new CoreBaseExecutionResultWithData<DataEntityObjectUser>();

            try
            {
                result.Data = await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, logger, result);
            }

            return result;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses> ProcessLoginPostActiveDirectoryKind(
            string ldapUserName,
            List<string> groups,
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            IEventService events,
            IUrlHelper urlHelper,
            UserManager<DataEntityObjectUser> userManager,
            IClientStore clientStore,
            HttpContext httpContext,
            RoleManager<DataEntityObjectRole> roleManager,
            CoreBaseLoggingService logger,
            HostBasePartAuthJobUserEntityCreateService jobUserEntityCreate,
            AuthorizationRequest context
            )
        {
            if (ldapUserName != null)
            {
                var user = await userManager.FindByNameAsync(ldapUserName)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (groups == null)
                {
                    throw new ModIdentityServerBaseExceptionLdapUserHasNotGroups();
                }

                AuthenticationProperties props = null;

                if (model.RememberLogin)
                {
                    props = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                }

                var userRoles = await userManager.GetRolesAsync(user).CoreBaseExtTaskWithCurrentCulture(false);

                if (!userRoles.Any())
                {
                    throw new ModIdentityServerBaseExceptionLdapLoginFailed();
                }

                // issue authentication cookie with subject ID and username
                await httpContext.SignInAsync(user.Id.ToString(), user.UserName, props)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                await events.RaiseAsync(
                    new UserLoginSuccessEvent(
                        user.UserName,
                        user.Id.ToString(),
                        user.UserName,
                        clientId: context?.ClientId
                    )
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
                    model.Username,
                    "invalid credentials",
                    clientId: context?.ClientId
                    )
                ).CoreBaseExtTaskWithCurrentCulture(false);

            throw new ModIdentityServerBaseExceptionLogin();
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

        private async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> ProduceLoginGet(
            string returnUrl,
            ModIdentityServerBaseEnumLoginMethods loginMethod,
            IIdentityServerInteractionService interaction,
            IAuthenticationSchemeProvider schemeProvider,
            IClientStore clientStore
            )
        {
            var context = await interaction.GetAuthorizationContextAsync(returnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginOutput
            {
                LoginMethod = loginMethod,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint
            };

            if (context?.IdP != null)
            {
                var scheme = await schemeProvider.GetSchemeAsync(context.IdP)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (scheme != null)
                {
                    var local = context.IdP == IdentityServerConstants.LocalIdentityProvider;

                    // this is meant to short circuit the UI and only trigger the one external IdP
                    result.EnableLocalLogin = local;

                    if (!local)
                    {
                        result.ExternalProviders = new[]
                        {
                            new ModIdentityServerWebMvcPartAccountExternalProvider
                            {
                                AuthenticationScheme = context.IdP
                            }
                        };
                    }
                }
            }
            else
            {
                var schemes = await schemeProvider.GetAllSchemesAsync()
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var providers = schemes.Where(x =>
                    x.DisplayName != null
                    ||
                    x.Name.Equals(
                        ModIdentityServerWebMvcSettings.AUTHENTICATION_SCHEME_Windows,
                        StringComparison.OrdinalIgnoreCase
                        )
                    ).Select(x =>
                        new ModIdentityServerWebMvcPartAccountExternalProvider
                        {
                            DisplayName = x.DisplayName,
                            AuthenticationScheme = x.Name
                        }
                    ).ToList();

                var allowLocal = true;

                if (context?.ClientId != null)
                {
                    var client = await clientStore.FindEnabledClientByIdAsync(context.ClientId)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (client != null)
                    {
                        allowLocal = client.EnableLocalLogin;

                        if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                        {
                            providers = providers.Where(
                                x => client.IdentityProviderRestrictions.Contains(x.AuthenticationScheme)
                                ).ToList();
                        }
                    }
                }

                result.AllowRememberLogin = ConfigSettings.AllowRememberLogin;
                result.EnableLocalLogin = allowLocal && ConfigSettings.AllowLocalLogin;
                result.ExternalProviders = providers.ToArray();
            }

            return result;
        }

        private List<string> GetAdGroups(string name)
        {
            List<string> groups = null;

            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                UserPrincipal userP = UserPrincipal.FindByIdentity(ctx, name);

                if (userP != null)
                {
                    var principals = userP.GetAuthorizationGroups();

                    groups = principals.Select(g => g.Name).ToList();
                }
            }
            catch
            {
            }

            return groups;
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
            ClaimsPrincipal user
            )
        {
            // build a model so the logged out page knows what to display
            var vm = await ProduceLogoutPost(
                model.LogoutId,
                httpContext,
                interaction,
                user
                ).CoreBaseExtTaskWithCurrentCulture(false);

            if (user?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await signInManager.SignOutAsync().CoreBaseExtTaskWithCurrentCulture(false);

                // raise the logout event
                await events.RaiseAsync(
                    new UserLogoutSuccessEvent(
                        user.GetSubjectId(),
                        user.GetDisplayName()
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

        #endregion Private methods
    }
}