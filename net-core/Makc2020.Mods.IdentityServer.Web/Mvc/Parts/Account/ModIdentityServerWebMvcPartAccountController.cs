﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Web.Ext;
using Makc2020.Host.Web;
using Makc2020.Mods.IdentityServer.Base.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
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
using Makc2020.Mods.IdentityServer.Web.Mvc.Security.Headers;
using Makc2020.Mods.IdentityServer.Web.Mvc.Views.Redirect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> LoginGet(string returnUrl, string isFirstLogin)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var processOutput = await GetLoginGetProcessOutput(returnUrl, isFirstLogin)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (processOutput.IsWindowsAuthenticationNeeded)
            {
                var model = new ModIdentityServerWebMvcPartAccountViewLoginModel()
                {
                    LoginMethod = ModIdentityServerBaseEnumLoginMethods.WindowsDomain,
                    ReturnUrl = returnUrl
                };

                var loginOutput = await GetLoginPostProcessOutput(model, ModIdentityServerWebMvcSettings.ACTION_Login)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var produceOutput = await GetLoginPostProduceOutput(model)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (!ModelState.IsValid)
                {
                    ModelState.Clear();
                }

                return GetLoginResult(loginOutput, produceOutput);
            }
            else if (string.IsNullOrWhiteSpace(processOutput.RedirectUrl))
            {
                var produceOutput = await GetLoginGetProduceOutput(returnUrl)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                return View("~/Views/Account/Login.cshtml", produceOutput);
            }
            else
            {
                return Redirect(processOutput.RedirectUrl);
            }
        }

        /// <summary>
        /// Вход в систему. Отправка.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="action">Действие.</param>
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

            var isLoginMemorizationNeeded =
                processOutput.Status != ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default
                &&
                processOutput.Status != ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Windows;

            if (isLoginMemorizationNeeded)
            {
                var cookieOptions = CreateCookieOptions(
                    false,
                    DateTimeOffset.Now.AddDays(processOutput.RememberLoginDurationInDays)
                    );

                Response.Cookies.Append(
                    processOutput.LoginMethodCookieName,
                    ((int)model.LoginMethod).ToString(),
                    cookieOptions
                    );

                if (model.LoginMethod != ModIdentityServerBaseEnumLoginMethods.WindowsDomain)
                {
                    Response.Cookies.Append(
                        processOutput.LoginUserNameCookieName,
                        model.Username ?? string.Empty,
                        cookieOptions
                        );
                }
                else
                {
                    Response.Cookies.Delete(processOutput.LoginUserNameCookieName);
                }
            }

            return GetLoginResult(processOutput, produceOutput);
        }

        /// <summary>
        /// Выход из системы. Получение.
        /// </summary>
        [HttpGet("Logout")]
        public async Task<IActionResult> LogoutGet(string logoutId)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var output = await GetLogoutGetOutput(logoutId).CoreBaseExtTaskWithCurrentCulture(false);

            //return View("~/Views/Account/Logout.cshtml", result.Data);  // страница подтверждения выхода

            var model = new ModIdentityServerWebMvcPartAccountViewLogoutModel
            {
                LogoutId = output.LogoutId
            };

            return await LogoutPost(model).CoreBaseExtTaskWithCurrentCulture(false);
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
                   produceOutput.AutomaticRedirectAfterSignOut
                   ? (
                       string.IsNullOrWhiteSpace(produceOutput.PostLogoutRedirectUri)
                           ? Redirect("/Account/Login")
                           : Redirect(produceOutput.PostLogoutRedirectUri)
                    )
                   : (IActionResult)View("~/Views/Account/LoggedOut.cshtml", produceOutput),
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
                            new AuthenticationProperties
                            {
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

        private void CorrectCookieOptions(string cookieKey, CookieOptions cookieOptions)
        {
            var cookieValue = Response.CoreWebExtGetCookieValue(cookieKey);

            Response.Cookies.Delete(cookieKey);

            Response.Cookies.Append(cookieKey, cookieValue, cookieOptions);
        }

        private CookieOptions CreateCookieOptions(bool httpOnly, DateTimeOffset? expires = null)
        {
            return new CookieOptions
            {
                Path = "/",
                HttpOnly = httpOnly,
                IsEssential = true,
                SameSite = SameSiteMode.Strict,
                Expires = expires
            };
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput> GetLoginGetProcessOutput(
            string returnUrl,
            string isFirstLogin
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountJobLoginGetProcessResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput
            {
                HttpRequest = Request,
                ReturnUrl = returnUrl
            };

            if (!string.IsNullOrWhiteSpace(isFirstLogin))
            {
                input.IsFirstLogin = isFirstLogin == "true";
            }

            var (execute, onSuccess, onError) = MyModel.BuildActionLoginGetProcess(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return result.Data ?? new ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput();
        }

        private async Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> GetLoginGetProduceOutput(
            string returnUrl
            )
        {
            var result = new ModIdentityServerWebMvcPartAccountCommonJobLoginResult();

            var input = new ModIdentityServerWebMvcPartAccountJobLoginGetProduceInput
            {
                ReturnUrl = returnUrl,
                HttpContext = HttpContext
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionLoginGetProduce(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return result.Data ?? new ModIdentityServerWebMvcPartAccountCommonJobLoginOutput();
        }

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
                HttpContext = HttpContext,
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

        private IActionResult GetLoginResult(
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput processOutput,
            ModIdentityServerWebMvcPartAccountCommonJobLoginOutput produceOutput
            )
        {
            IActionResult result;

            switch (processOutput.Status)
            {
                case ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Index:
                    result = Redirect("~/");
                    break;
                case ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Redirect:
                    result = View(
                        "Redirect",
                        new ModIdentityServerWebMvcViewRedirectModel
                        {
                            RedirectUrl = produceOutput.ReturnUrl
                        });
                    break;
                case ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Return:
                    result = Redirect(produceOutput.ReturnUrl);
                    break;
                case ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Windows:
                    result = Challenge(ModIdentityServerWebMvcSettings.AUTHENTICATION_SCHEME_Windows);
                    break;
                case ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default:
                default:
                    result = View("~/Views/Account/Login.cshtml", produceOutput);
                    break;
            }

            return result;
        }

        private async Task<ModIdentityServerWebMvcPartAccountJobLogoutGetOutput> GetLogoutGetOutput(string logoutId)
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

            return result.Data ?? new ModIdentityServerWebMvcPartAccountJobLogoutGetOutput();
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