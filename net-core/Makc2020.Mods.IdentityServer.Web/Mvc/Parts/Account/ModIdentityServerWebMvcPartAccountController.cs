//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;
using Makc2020.Mods.IdentityServer.Web.Mvc.Security.Headers;
using Makc2020.Mods.IdentityServer.Web.Mvc.Views.Redirect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    [ModIdentityServerWebMvcSecurityHeaders]
    [AllowAnonymous]
    [Route("Account")]
    public abstract class ModIdentityServerWebMvcPartAccountController : Controller
    {
        #region Properties

        private ModIdentityServerWebMvcPartAccountModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModIdentityServerWebMvcPartAccountController(ModIdentityServerWebMvcPartAccountModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Вход в систему. Получение.
        /// </summary>
        [HttpGet("Login")]
        public async Task<IActionResult> LoginGet(string returnUrl)
        {
            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLoginGetInput
            {
                ReturnUrl = returnUrl
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLoginGet(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return View("~/Views/Account/Login.cshtml", result.Data);
        }

        /// <summary>
        /// Вход в систему. Отправка.
        /// </summary>
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginPost(
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            string action
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLoginPostInput
            {
                Action = action,
                Model = model,
                ModelState = ModelState,
                UrlHelper = Url
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLoginPost(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return input.Status switch
            {
                ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Index =>
                    Redirect("~/"),
                ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Redirect =>
                    View(
                        "Redirect",
                        new ModIdentityServerWebMvcViewRedirectModel
                        {
                            RedirectUrl = result.Data.ReturnUrl
                        }),
                ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Return =>
                    Redirect(result.Data.ReturnUrl),
                _ =>
                    View("~/Views/Account/Login.cshtml", result.Data),
            };
        }

        /// <summary>
        /// Выход из системы. Получение.
        /// </summary>
        [HttpGet("Logout")]
        public async Task<IActionResult> LogoutGet(string logoutId)
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLogoutGetResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLogoutGetInput
            {
                LogoutId = logoutId,
                User = User
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLogoutGet(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return View("~/Views/Account/Logout.cshtml", result.Data);
        }

        /// <summary>
        /// Выход из системы. Отправка.
        /// </summary>
        [HttpPost("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutPost(
            ModIdentityServerWebMvcPartAccountViewLogoutModel model
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLogoutPostResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLogoutPostInput
            {
                HttpContext = HttpContext,
                Model = model,                 
                UrlHelper = Url,
                User = User
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLogoutPost(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return input.Status switch
            {
                ModIdentityServerWebMvcPartAccountJobLogoutPostEnumStatuses.LoggedOut =>
                    View("~/Views/Account/LoggedOut.cshtml", result.Data),
                _ =>
                    ((Func<SignOutResult>)(() =>
                    {
                        // build a return URL so the upstream provider will redirect back
                        // to us after the user has logged out. this allows us to then
                        // complete our single sign-out processing.
                        var redirectUri = Url.Action(
                            "~/Views/Account/Logout.cshtml",
                            new 
                            {
                                logoutId = result.Data.LogoutId 
                            });

                        // this triggers a redirect to the external provider for sign-out
                        return SignOut(
                            new AuthenticationProperties {
                                RedirectUri = redirectUri
                            },
                            result.Data.ExternalAuthenticationScheme
                            );
                    }))()
            };
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion Public methods
    }
}