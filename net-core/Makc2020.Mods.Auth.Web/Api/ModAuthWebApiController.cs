//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Register;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Web.Api
{
    /// <summary>
    /// Мод "Auth". Веб. API. Контроллер.
    /// </summary>
    [ApiController, Route("api/auth")]
    public class ModAuthWebApiController : ControllerBase
    {
        #region Properties

        private ModAuthWebApiModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModAuthWebApiController(ModAuthWebApiModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Ввод.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("login"), HttpPost]
        public async Task<IActionResult> Login([FromBody] ModAuthBaseCommonJobLoginInput input)
        {
            var result = new ModAuthBaseCommonJobLoginJwtResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionLogin(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("refresh"), HttpPost]
        public async Task<IActionResult> Refresh([FromBody] ModAuthBaseJobRefreshJwtInput input)
        {
            var result = new ModAuthBaseCommonJobLoginJwtResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionRefresh(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Регистрация.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("register"), HttpPost]
        public async Task<IActionResult> Register([FromBody] ModAuthBaseJobRegisterInput input)
        {
            var result = new ModAuthBaseJobRegisterResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionRegister(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        #endregion Public methods
    }
}
