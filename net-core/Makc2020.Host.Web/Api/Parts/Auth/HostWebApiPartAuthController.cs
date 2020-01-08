//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Host.Web.Api.Parts.Auth
{
    /// <summary>
    /// Хост. Beб. API. Часть "Auth". API. Контроллер.
    /// </summary>
    [ApiController, Route("api/auth")]
    public class HostWebApiPartAuthController : ControllerBase
    {
        #region Properties

        private HostWebApiPartAuthModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public HostWebApiPartAuthController(HostWebApiPartAuthModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("current-user"), HttpGet]
        public async Task<IActionResult> CurrentUserGet([FromQuery] HostBasePartAuthJobCurrentUserGetInput input)
        {
            var result = new HostBasePartAuthJobCurrentUserGetResult();

            input.Principal = User;

            var (execute, onSuccess, onError) = MyModel.BuildActionCurrentUserGet(input);

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
