//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Web.Api;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Host.Web.Api.Parts.Auth
{
    /// <summary>
    /// Хост. Beб. Аутентификация. API. Контроллер.
    /// </summary>
    [Route("api/auth")]
    public class HostWebPartAuthApiController : CoreWebApiController
    {
        #region Properties

        private UserManager<DataEntityObjectUser> UserManager { get; set; }

        private HostBasePartAuthJobCurrentUserGetService JobCurrentUserGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="jobCurrentUserGet">Задание на получение текущего пользователя.</param>
        /// <param name="jobLogin">Задание на вход в систему.</param>
        /// <param name="jobRefresh">Задание на обновление.</param>
        /// <param name="jobRegister">Задание на регистрацию.</param>
        public HostWebPartAuthApiController(
            ILogger<HostWebPartAuthApiController> logger,
            UserManager<DataEntityObjectUser> userManager,
            HostBasePartAuthJobCurrentUserGetService jobCurrentUserGet
            )
            : base(logger)
        {
            UserManager = userManager;
            JobCurrentUserGet = jobCurrentUserGet;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("current-user"), HttpGet]
        public async Task<IActionResult> CurrentUserGet(HostBasePartAuthJobCurrentUserGetInput input)
        {
            var result = new CoreBaseExecutionResultWithData<HostBasePartAuthUser>();

            input.Principal = User;
            input.UserManager = UserManager;

            var job = JobCurrentUserGet;

            try
            {
                result.Data = await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        #endregion Public methods
    }
}
