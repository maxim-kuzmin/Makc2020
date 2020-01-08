//Author Maxim Kuzmin//makc//

using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Makc2020.Mods.IdentityServer.Base.Exceptions;
using Makc2020.Mods.IdentityServer.Web.Ext;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalService
    {
        #region Properties

        private IModIdentityServerWebMvcPartAccountConfigSettings ConfigSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public ModIdentityServerWebMvcPartExternalService(
            IModIdentityServerWebMvcPartAccountConfigSettings configSettings
            )
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить обратный вызов.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModIdentityServerWebMvcPartExternalJobCallbackGetOutput> GetCallback(
            ModIdentityServerWebMvcPartExternalJobCallbackGetInput input
            )
        {
            var (status, returnUrl) = await ProcessCallbackGet(
                input.ClientStore,
                input.Events,
                input.HttpContext,
                input.Interaction,
                input.JobUserEntityCreate,
                input.Logger,
                input.RoleManager,
                input.SignInManager,
                input.UserManager
                );

            input.Status = status;

            return new ModIdentityServerWebMvcPartExternalJobCallbackGetOutput
            {
                ReturnUrl = returnUrl
            };
        }

        /// <summary>
        /// Получить вызов.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModIdentityServerWebMvcPartExternalJobChallengeGetOutput> GetChallenge(
            ModIdentityServerWebMvcPartExternalJobChallengeGetInput input
            )
        {
            if (string.IsNullOrEmpty(input.ReturnUrl))
            {
                input.ReturnUrl = "~/";
            }

            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = input.RedirectUrl,
                Items =
                {
                    { "returnUrl", input.ReturnUrl },
                    { "scheme", input.Provider },
                }
            };

            input.Status = await ProcessChallengeGet(
                authenticationProperties,
                input.Provider,
                input.ReturnUrl,
                input.HttpContext,
                input.UrlHelper,
                input.Interaction
                ).CoreBaseExtTaskWithCurrentCulture(false);

            return new ModIdentityServerWebMvcPartExternalJobChallengeGetOutput
            {
                AuthenticationProperties = authenticationProperties
            };
        }

        #endregion Public methods

        #region Private methods

        private async Task<(
            DataEntityObjectUser user,
            string provider,
            string providerUserId,
            IEnumerable<Claim> claims
            )> FindUserFromExternalProviderAsync(
            AuthenticateResult result,
            UserManager<DataEntityObjectUser> userManager
            )
        {
            var externalUser = result.Principal;

            // try to determine the unique id of the external user (issued by the provider)
            // the most common claim type for that are the sub claim and the NameIdentifier
            // depending on the external provider, some other claim type might be used
            var userIdClaim = externalUser.FindFirst(JwtClaimTypes.Subject) ??
                              externalUser.FindFirst(ClaimTypes.NameIdentifier) ??
                              throw new ModIdentityServerBaseExceptionUnknownUserId();

            // remove the user id claim so we don't include it as an extra claim if/when we provision the user
            var claims = externalUser.Claims.ToList();

            claims.Remove(userIdClaim);

            var provider = result.Properties.Items["scheme"];

            var providerUserId = userIdClaim.Value;

            // find external user
            var user = await userManager.FindByLoginAsync(provider, providerUserId);

            return (user, provider, providerUserId, claims);
        }

        private async Task<DataEntityObjectUser> AutoProvisionUserAsync(
            string provider,
            string providerUserId,
            IEnumerable<Claim> claims,
            ILogger logger,
            HostBasePartAuthJobUserEntityCreateService jobUserEntityCreate,
            RoleManager<DataEntityObjectRole> roleManager,
            UserManager<DataEntityObjectUser> userManager
            )
        {
            // create a list of claims that we want to transfer into our store
            var filtered = new List<Claim>();

            // user's display name
            var name = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name)?.Value ??
                claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            if (name != null)
            {
                filtered.Add(new Claim(JwtClaimTypes.Name, name));
            }
            else
            {
                var first = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.GivenName)?.Value ??
                    claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
                var last = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.FamilyName)?.Value ??
                    claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value;
                if (first != null && last != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first + " " + last));
                }
                else if (first != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first));
                }
                else if (last != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, last));
                }
            }

            // email
            var email = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Email)?.Value ??
               claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            if (email != null)
            {
                filtered.Add(new Claim(JwtClaimTypes.Email, email));
            }

            var input = new HostBasePartAuthJobUserEntityCreateInput
            {
                Email = email,
                LoginProvider = provider,
                ProviderDisplayName = provider,
                ProviderKey = providerUserId,
                RoleManager = roleManager,
                RoleNames = claims.HostBasePartAuthExtGetRoleNamesFromClaims(),
                UserManager = userManager,
                UserName = name
            };

            var execResult = await CreateUserEntity(logger, jobUserEntityCreate, input).CoreBaseExtTaskWithCurrentCulture(false);

            if (!execResult.IsOk)
            {
                throw new Exception(string.Join(". ", execResult.ErrorMessages));
            }

            return execResult.Data;
        }

        private async Task<CoreBaseExecutionResultWithData<DataEntityObjectUser>> CreateUserEntity(
            ILogger logger,
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

        private Task<ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses> ProcessChallengeGet(
            AuthenticationProperties authenticationProperties,
            string provider,
            string returnUrl,
            HttpContext httpContext,
            IUrlHelper urlHelper,
            IIdentityServerInteractionService interaction
            )
        {
            // validate returnUrl - either it is a valid OIDC URL or back to a local page
            if (urlHelper.IsLocalUrl(returnUrl) == false && interaction.IsValidReturnUrl(returnUrl) == false)
            {
                // user might have clicked on a malicious link - should be logged
                throw new ModIdentityServerBaseExceptionInvalidReturnUrl();
            }

            if (provider == ConfigSettings.WindowsAuthenticationSchemeName)
            {
                // windows authentication needs special handling
                return ProcessChallengeGetForWindowsLogin(authenticationProperties, httpContext);
            }
            else
            {
                return Task.FromResult(ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses.Default);
            }
        }

        private async Task<ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses> ProcessChallengeGetForWindowsLogin(
            AuthenticationProperties authenticationProperties,
            HttpContext httpContext
            )
        {
            // see if windows auth has already been requested and succeeded
            var result = await httpContext.AuthenticateAsync(ConfigSettings.WindowsAuthenticationSchemeName)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (result?.Principal is WindowsPrincipal wp)
            {
                // we will issue the external cookie and then redirect the
                var id = new ClaimsIdentity(ConfigSettings.WindowsAuthenticationSchemeName);

                id.AddClaim(new Claim(JwtClaimTypes.Subject, wp.FindFirst(ClaimTypes.PrimarySid).Value));

                id.AddClaim(new Claim(JwtClaimTypes.Name, wp.Identity.Name));

                // add the groups as claims -- be careful if the number of groups is too large
                if (ConfigSettings.IncludeWindowsGroups)
                {
                    var wi = wp.Identity as WindowsIdentity;

                    var groups = wi.Groups.Translate(typeof(NTAccount));

                    var roles = groups.HostBasePartAuthExtGetRoleClaimsFromWindowsGroups();

                    id.AddClaims(roles);
                }

                await httpContext.SignInAsync(
                    IdentityConstants.ExternalScheme,
                    new ClaimsPrincipal(id),
                    authenticationProperties
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                return ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses.Redirect;
            }
            else
            {
                return ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses.Windows;
            }
        }

        private async Task<(
            ModIdentityServerWebMvcPartExternalJobCallbackGetEnumStatuses status,
            string returnUrl
            )> ProcessCallbackGet(
            IClientStore clientStore,
            IEventService events,
            HttpContext httpContext,
            IIdentityServerInteractionService interaction,
            HostBasePartAuthJobUserEntityCreateService jobUserEntityCreate,
            ILogger logger,
            RoleManager<DataEntityObjectRole> roleManager,
            SignInManager<DataEntityObjectUser> signInManager,
            UserManager<DataEntityObjectUser> userManager
            )
        {
            // read external identity from the temporary cookie
            var result = await httpContext.AuthenticateAsync(IdentityConstants.ExternalScheme)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (result?.Succeeded != true)
            {
                throw new ModIdentityServerBaseExceptionExternalAuthentication();
            }

            // lookup our user and external provider info
            var (user, provider, providerUserId, claims) = await FindUserFromExternalProviderAsync(result, userManager);

            if (user == null)
            {
                // this might be where you might initiate a custom workflow for user registration
                // in this sample we don't show how that would be done, as our sample implementation
                // simply auto-provisions new external user
                user = await AutoProvisionUserAsync(
                    provider,
                    providerUserId,
                    claims,
                    logger,
                    jobUserEntityCreate,
                    roleManager,
                    userManager
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            // this allows us to collect any additonal claims or properties
            // for the specific prtotocols used and store them in the local auth cookie.
            // this is typically used to store data needed for signout from those protocols.
            var additionalLocalClaims = new List<Claim>();

            var localSignInProps = new AuthenticationProperties();

            ProcessCallbackGetForOidc(result, additionalLocalClaims, localSignInProps);

            // issue authentication cookie for user
            // we must issue the cookie maually, and can't use the SignInManager because
            // it doesn't expose an API to issue additional claims from the login workflow
            var principal = await signInManager.CreateUserPrincipalAsync(user)
                .CoreBaseExtTaskWithCurrentCulture(false);

            additionalLocalClaims.AddRange(principal.Claims);

            var name = principal.FindFirst(JwtClaimTypes.Name)?.Value ?? user.Id.ToString();

            await httpContext.SignInAsync(
                user.Id.ToString(),
                name,
                provider,
                localSignInProps,
                additionalLocalClaims.ToArray()
                ).CoreBaseExtTaskWithCurrentCulture(false);

            // delete temporary cookie used during external authentication
            await httpContext.SignOutAsync(IdentityConstants.ExternalScheme)
                .CoreBaseExtTaskWithCurrentCulture(false);

            // retrieve return URL
            var returnUrl = result.Properties.Items["returnUrl"] ?? "~/";

            // check if external login is in the context of an OIDC request
            var context = await interaction.GetAuthorizationContextAsync(returnUrl)
                .CoreBaseExtTaskWithCurrentCulture(false);

            await events.RaiseAsync(
                new UserLoginSuccessEvent(
                    provider,
                    providerUserId,
                    user.Id.ToString(),
                    name,
                    true,
                    context?.ClientId
                    )
                ).CoreBaseExtTaskWithCurrentCulture(false);

            var status = ModIdentityServerWebMvcPartExternalJobCallbackGetEnumStatuses.Default;

            if (context != null)
            {
                var isPckeRequired = await clientStore.ModIdentityServerWebExtClientIsPkceRequired(context.ClientId)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (isPckeRequired)
                {
                    // if the client is PKCE then we assume it's native, so this change in how to
                    // return the response is for better UX for the end user.
                    status = ModIdentityServerWebMvcPartExternalJobCallbackGetEnumStatuses.Redirect;
                }
            }

            return (status, returnUrl);
        }

        private void ProcessCallbackGetForOidc(AuthenticateResult externalResult, List<Claim> localClaims, AuthenticationProperties localSignInProps)
        {
            // if the external system sent a session id claim, copy it over
            // so we can use it for single sign-out
            var sid = externalResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);

            if (sid != null)
            {
                localClaims.Add(new Claim(JwtClaimTypes.SessionId, sid.Value));
            }

            // if the external provider issued an id_token, we'll keep it for signout
            var id_token = externalResult.Properties.GetTokenValue("id_token");

            if (id_token != null)
            {
                localSignInProps.StoreTokens(
                    new[]
                    {
                        new AuthenticationToken 
                        {
                            Name = "id_token",
                            Value = id_token 
                        } 
                    });
            }
        }

        #endregion Private methods
    }
}