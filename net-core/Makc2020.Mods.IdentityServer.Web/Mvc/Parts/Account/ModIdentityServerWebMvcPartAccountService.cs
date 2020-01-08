//Author Maxim Kuzmin//makc//

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.IdentityServer.Base.Enums;
using Makc2020.Mods.IdentityServer.Base.Exceptions;
using Makc2020.Mods.IdentityServer.Base.Resources.Titles;
using Makc2020.Mods.IdentityServer.Web.Ext;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountService
    {
        #region Properties

        private IModIdentityServerWebMvcPartAccountConfigSettings ConfigSettings { get; set; }

        /// <summary>
        /// Ресурс заголовков.
        /// </summary>
        private ModIdentityServerBaseResourceTitles ResourceTitles { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitles">Ресурс заголовков.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public ModIdentityServerWebMvcPartAccountService(
            IModIdentityServerWebMvcPartAccountConfigSettings configSettings,
            ModIdentityServerBaseResourceTitles resourceTitles
            )
        {
            ConfigSettings = configSettings;
            ResourceTitles = resourceTitles;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить вход в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> GetLogin(
            ModIdentityServerWebMvcPartAccountJobLoginGetInput input
            )
        {
            return ProduceLogin(
                input.ReturnUrl,
                ModIdentityServerBaseEnumLoginMethods.Windows,
                input.Interaction,
                input.SchemeProvider,
                input.СlientStore
                );
        }

        /// <summary>
        /// Отправить вход в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> PostLogin(
            ModIdentityServerWebMvcPartAccountJobLoginPostInput input
            )
        {
            input.Status = await ProcessLoginPost(
                input.Model,
                input.Action,
                input.Events,
                input.ModelState,
                input.SignInManager,
                input.UrlHelper,
                input.UserManager,
                input.Interaction,
                input.СlientStore
                ).CoreBaseExtTaskWithCurrentCulture(false);
            
            return await ProduceLogin(
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
        /// Отправить выход из системы.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostOutput> PostLogout(
            ModIdentityServerWebMvcPartAccountJobLogoutPostInput input
            )
        {
            input.Status = await ProcessLogoutPost(
                input.Model,
                input.Events,
                input.SignInManager,
                input.HttpContext,
                input.Interaction,
                input.User
                ).CoreBaseExtTaskWithCurrentCulture(false);

            return await ProduceLogoutPost(
                input.Model.LogoutId,
                input.HttpContext,
                input.Interaction,
                input.User
                ).CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods

        #region Private methods

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses> ProcessLoginPost(
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
                        return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Redirect;
                    }

                    return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Return;
                }
                else
                {
                    // since we don't have a valid context, then we just go back to the home page
                    return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Index;
                }
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
                            return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Redirect;
                        }

                        // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                        return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Return;
                    }

                    // request for a local page
                    if (urlHelper.IsLocalUrl(model.ReturnUrl))
                    {
                        return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Return;
                    }
                    else if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Index;
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

            return ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Default;
        }

        private async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> ProduceLogin(
            string returnUrl,
            ModIdentityServerBaseEnumLoginMethods loginMethod,
            IIdentityServerInteractionService interaction,
            IAuthenticationSchemeProvider schemeProvider,
            IClientStore clientStore
            )
        {
            var context = await interaction.GetAuthorizationContextAsync(returnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginOutput(ResourceTitles, loginMethod)
            {
                ReturnUrl = returnUrl,
                Username = context?.LoginHint
            };

            if (context?.IdP != null)
            {
                var scheme = await schemeProvider.GetSchemeAsync(context.IdP)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (scheme != null)
                {
                    var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

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
                        x.Name.Equals(ConfigSettings.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase)
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

            var context = await interaction.GetLogoutContextAsync(logoutId);

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

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostEnumStatuses> ProcessLogoutPost(
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
                );

            if (user?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await signInManager.SignOutAsync();

                // raise the logout event
                await events.RaiseAsync(new UserLogoutSuccessEvent(user.GetSubjectId(), user.GetDisplayName()));
            }

            // check if we need to trigger sign-out at an upstream identity provider
            if (vm.TriggerExternalSignout)
            {                
                // this triggers a redirect to the external provider for sign-out
                return ModIdentityServerWebMvcPartAccountJobLogoutPostEnumStatuses.Default;
            }

            return ModIdentityServerWebMvcPartAccountJobLogoutPostEnumStatuses.LoggedOut;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostOutput> ProduceLogoutPost(
            string logoutId,
            HttpContext httpContext,
            IIdentityServerInteractionService interaction,
            ClaimsPrincipal user
            )
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var context = await interaction.GetLogoutContextAsync(logoutId);

            var result = new ModIdentityServerWebMvcPartAccountJobLogoutPostOutput
            {
                AutomaticRedirectAfterSignOut = ConfigSettings.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = context?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(context?.ClientName) ? context?.ClientId : context?.ClientName,
                SignOutIframeUrl = context?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (user?.Identity.IsAuthenticated == true)
            {
                var idp = user.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;

                if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await httpContext.GetSchemeSupportsSignOutAsync(idp);

                    if (providerSupportsSignout)
                    {
                        if (result.LogoutId == null)
                        {
                            // if there's no current logout context, we need to create one
                            // this captures necessary info from the current logged in user
                            // before we signout and redirect away to the external IdP for signout
                            result.LogoutId = await interaction.CreateLogoutContextAsync();
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