//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Host.Web;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Security.Headers;
using Makc2020.Mods.IdentityServer.Web.Mvc.Views.Redirect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    [ModIdentityServerWebMvcSecurityHeaders]
    [AllowAnonymous]
    [Route("External")]
    public abstract class ModIdentityServerWebMvcPartExternalController : Controller
    {
        #region Properties

        private ModIdentityServerWebMvcPartExternalModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModIdentityServerWebMvcPartExternalController(ModIdentityServerWebMvcPartExternalModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обратный вызов. Получение.
        /// </summary>
        [HttpGet("Callback")]
        public async Task<IActionResult> CallbackGet()
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModIdentityServerWebMvcPartExternalJobCallbackGetResult();

            var input = new ModIdentityServerWebMvcPartExternalJobCallbackGetInput
            {
                HttpContext = HttpContext
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionCallbackGet(input);

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
                ModIdentityServerWebMvcPartExternalJobCallbackGetEnumStatuses.Redirect =>
                    View(
                        "Redirect",
                        new ModIdentityServerWebMvcViewRedirectModel
                        {
                            RedirectUrl = result.Data.ReturnUrl
                        }),

                _ =>
                    Redirect(result.Data.ReturnUrl)
            };
        }

        /// <summary>
        /// Вызов. Получение.
        /// </summary>
        [HttpGet("Challenge")]
        public async Task<IActionResult> ChallengeGet(string provider, string returnUrl)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModIdentityServerWebMvcPartExternalJobChallengeGetResult();

            var input = new ModIdentityServerWebMvcPartExternalJobChallengeGetInput
            {
                HttpContext = HttpContext,
                Provider = provider,
                RedirectUrl = Url.Action("Callback"),
                ReturnUrl = returnUrl,
                UrlHelper = Url
            };

            var (execute, onSuccess, onError) = MyModel.BuildActionChallengeGet(input);

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
                ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses.Redirect =>
                    Redirect(input.RedirectUrl),
                ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses.Windows =>
                    Challenge(input.Provider),
                _ =>
                    Challenge(result.Data.AuthenticationProperties, input.Provider)
            };
        }

        #endregion Public methods
    }
}