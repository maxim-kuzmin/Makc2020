//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Web.Api;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Web.Api
{
    /// <summary>
    /// Мод "Auth". Веб. Основа. API. Контроллер.
    /// </summary>
    [Route("api/auth")]
    public class ModAuthWebApiController : CoreWebApiController
    {
        #region Properties

        private UserManager<DataEntityObjectUser> UserManager { get; set; }

        private ModAuthBaseJobLoginJwtService JobLogin { get; set; }

        private ModAuthBaseJobRefreshJwtService JobRefresh { get; set; }

        private ModAuthBaseJobRegisterService JobRegister { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="jobLogin">Задание на вход в систему.</param>
        /// <param name="jobRefresh">Задание на обновление.</param>
        /// <param name="jobRegister">Задание на регистрацию.</param>
        public ModAuthWebApiController(
            ILogger<ModAuthWebApiController> logger,
            UserManager<DataEntityObjectUser> userManager,
            ModAuthBaseJobLoginJwtService jobLogin,
            ModAuthBaseJobRefreshJwtService jobRefresh,
            ModAuthBaseJobRegisterService jobRegister
            )
            : base(logger)
        {
            UserManager = userManager;
            JobLogin = jobLogin;
            JobRefresh = jobRefresh;
            JobRegister = jobRegister;
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
            var result = new CoreBaseExecutionResultWithData<ModAuthBaseCommonJobLoginJwtOutput>();

            input.UserManager = UserManager;

            var job = JobLogin;

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

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("refresh"), HttpPost]
        public async Task<IActionResult> Refresh([FromBody] ModAuthBaseJobRefreshJwtInput input)
        {
            var result = new CoreBaseExecutionResultWithData<ModAuthBaseCommonJobLoginJwtOutput>();

            input.UserManager = UserManager;

            var job = JobRefresh;

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

        /// <summary>
        /// Регистрация.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("register"), HttpPost]
        public async Task<IActionResult> Register([FromBody] ModAuthBaseJobRegisterInput input)
        {
            var result = new CoreBaseExecutionResultWithData<HostBasePartAuthUser>();

            input.UserManager = UserManager;

            var job = JobRegister;

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
