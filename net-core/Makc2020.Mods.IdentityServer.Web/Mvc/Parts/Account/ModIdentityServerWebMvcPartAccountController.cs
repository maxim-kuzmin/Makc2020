//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Host.Web;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce;
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
            MyModel.Init(HostWebState.Create(HttpContext));

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
            MyModel.Init(HostWebState.Create(HttpContext));

            var processOutput = await GetLoginPostProcessOutput(model, action)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var produceOutput = await GetLoginPostProduceOutput(model)
                .CoreBaseExtTaskWithCurrentCulture(false);
            
            return processOutput.Status switch
            {
                ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Index =>
                    Redirect("~/"),
                ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Redirect =>
                    View(
                        "Redirect",
                        new ModIdentityServerWebMvcViewRedirectModel
                        {
                            RedirectUrl = produceOutput.ReturnUrl
                        }),
                ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return =>
                    Redirect(produceOutput.ReturnUrl),
                _ =>
                    View("~/Views/Account/Login.cshtml", produceOutput),
            };
        }

        /// <summary>
        /// Выход из системы. Получение.
        /// </summary>
        [HttpGet("Logout")]
        public async Task<IActionResult> LogoutGet(string logoutId)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

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

            //return View("~/Views/Account/Logout.cshtml", result.Data);  // страница подтверждения выхода
            return await LogoutPost(new ModIdentityServerWebMvcPartAccountViewLogoutModel()
            {
                LogoutId = result.Data.LogoutId
            }).CoreBaseExtTaskWithCurrentCulture(false);
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
            MyModel.Init(HostWebState.Create(HttpContext));

            var processOutput = await GetLogoutPostProcessOutput(model)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var produceOutput = await GetLogoutPostProduceOutput(model)
                .CoreBaseExtTaskWithCurrentCulture(false);

            return processOutput.Status switch
            {
                 ModIdentityServerWebMvcPartAccountJobLogoutPostProcessEnumStatuses.LoggedOut =>
                    View("~/Views/Account/LoggedOut.cshtml", produceOutput),
                _ =>
                    ((Func<SignOutResult>)(() =>
                    {
                        // build a return URL so the upstream provider will redirect back
                        // to us after the user has logged out. this allows us to then
                        // complete our single sign-out processing.
                        var redirectUri = Url.Action(
                            "LogoutGet",
                            new 
                            {
                                logoutId = produceOutput.LogoutId 
                            });

                        // this triggers a redirect to the external provider for sign-out
                        return SignOut(
                            new AuthenticationProperties {
                                RedirectUri = redirectUri
                            },
                            produceOutput.ExternalAuthenticationScheme
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

        #region Private methods

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput> GetLoginPostProcessOutput(
            ModIdentityServerWebMvcPartAccountViewLoginModel model,
            string action
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLoginPostProcessResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput
            {
                Action = action,
                HttpContext = HttpContext,
                Model = model,
                ModelState = ModelState,
                UrlHelper = Url
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLoginPostProcess(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return result.Data ?? new ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput();
        }

        private async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> GetLoginPostProduceOutput(
            ModIdentityServerWebMvcPartAccountViewLoginModel model
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput
            {
                Model = model,
                ModelState = ModelState
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLoginPostProduce(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return result.Data;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput> GetLogoutPostProcessOutput(
            ModIdentityServerWebMvcPartAccountViewLogoutModel model
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLogoutPostProcessResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput
            {
                HttpContext = HttpContext,
                Model = model,
                ModelState = ModelState,
                UrlHelper = Url,
                User = User
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLogoutPostProcess(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return result.Data ?? new ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput();
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput> GetLogoutPostProduceOutput(
            ModIdentityServerWebMvcPartAccountViewLogoutModel model
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLogoutPostProduceResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput
            {
                HttpContext = HttpContext,
                Model = model,
                ModelState = ModelState,
                User = User
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLogoutPostProduce(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return result.Data;
        }

        #endregion Private methods
    }
}