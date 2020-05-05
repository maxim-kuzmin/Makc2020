//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Web;
using Makc2020.Host.Web.Api;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Register;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Web.Api
{
    /// <summary>
    /// Мод "Auth". Веб. API. Модель.
    /// </summary>
    public class ModAuthWebApiModel : HostWebApiModel<HostWebState>
    {
        #region Properties

        private ModAuthBaseJobLoginJwtService AppJobLogin { get; set; }

        private ModAuthBaseJobRefreshJwtService AppJobRefresh { get; set; }

        private ModAuthBaseJobRegisterService AppJobRegister { get; set; }

        private UserManager<DataEntityObjectUser> ExtUserManager { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="appJobLogin">Задание на вход в систему.</param>
        /// <param name="appJobRefresh">Задание на обновление.</param>
        /// <param name="appJobRegister">Задание на регистрацию.</param>
        /// <param name="appLogger">Регистратор.</param>
        /// <param name="extUserManager">Менеджер пользователей.</param>
        public ModAuthWebApiModel(
            ModAuthBaseJobLoginJwtService appJobLogin,
            ModAuthBaseJobRefreshJwtService appJobRefresh,
            ModAuthBaseJobRegisterService appJobRegister,
            CoreBaseLoggingServiceWithCategoryName<ModAuthWebApiController> appLogger,
            UserManager<DataEntityObjectUser> extUserManager
            )
            : base(appLogger)
        {            
            AppJobLogin = appJobLogin;
            AppJobRefresh = appJobRefresh;
            AppJobRegister = appJobRegister;
            ExtUserManager = extUserManager;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Вход в систему".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModAuthBaseCommonJobLoginJwtOutput>> execute,
            Action<ModAuthBaseCommonJobLoginJwtResult> onSuccess,
            Action<Exception, ModAuthBaseCommonJobLoginJwtResult> onError
            ) BuildActionLogin(ModAuthBaseCommonJobLoginInput input)
        {
            input.UserManager = ExtUserManager;

            var job = AppJobLogin;

            Task<ModAuthBaseCommonJobLoginJwtOutput> execute() => job.Execute(input);

            void onSuccess(ModAuthBaseCommonJobLoginJwtResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModAuthBaseCommonJobLoginJwtResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Обновление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModAuthBaseCommonJobLoginJwtOutput>> execute,
            Action<ModAuthBaseCommonJobLoginJwtResult> onSuccess,
            Action<Exception, ModAuthBaseCommonJobLoginJwtResult> onError
            ) BuildActionRefresh(ModAuthBaseJobRefreshJwtInput input)
        {
            input.UserManager = ExtUserManager;

            var job = AppJobRefresh;

            Task<ModAuthBaseCommonJobLoginJwtOutput> execute() => job.Execute(input);

            void onSuccess(ModAuthBaseCommonJobLoginJwtResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModAuthBaseCommonJobLoginJwtResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Регистрация".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<HostBasePartAuthUser>> execute,
            Action<ModAuthBaseJobRegisterResult> onSuccess,
            Action<Exception, ModAuthBaseJobRegisterResult> onError
            ) BuildActionRegister(ModAuthBaseJobRegisterInput input)
        {
            input.UserManager = ExtUserManager;

            var job = AppJobRegister;

            Task<HostBasePartAuthUser> execute() => job.Execute(input);

            void onSuccess(ModAuthBaseJobRegisterResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModAuthBaseJobRegisterResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods
    }
}
