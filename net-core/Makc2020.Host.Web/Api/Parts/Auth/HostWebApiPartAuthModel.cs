//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Host.Web.Api.Parts.Auth
{
    /// <summary>
    /// Хост. Beб. API. Часть "Auth". API. Модель.
    /// </summary>
    public class HostWebApiPartAuthModel : HostWebApiModel<HostWebState>
    {
        #region Properties

        private HostBasePartAuthJobCurrentUserGetService AppJobCurrentUserGet { get; set; }

        private UserManager<DataEntityObjectUser> ExtUserManager { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="appJobCurrentUserGet">Задание на получение текущего пользователя.</param>
        /// <param name="extLogger">Регистратор.</param>
        /// <param name="extUserManager">Менеджер пользователей.</param>
        public HostWebApiPartAuthModel(
            HostBasePartAuthJobCurrentUserGetService appJobCurrentUserGet,
            ILogger<HostWebApiPartAuthController> extLogger,
            UserManager<DataEntityObjectUser> extUserManager         
            )
            : base(extLogger)
        {            
            AppJobCurrentUserGet = appJobCurrentUserGet;
            ExtUserManager = extUserManager;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Текущий пользователь. Получить".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<HostBasePartAuthUser>> execute,
            Action<HostBasePartAuthJobCurrentUserGetResult> onSuccess,
            Action<Exception, HostBasePartAuthJobCurrentUserGetResult> onError
            ) BuildActionCurrentUserGet(HostBasePartAuthJobCurrentUserGetInput input)
        {
            input.UserManager = ExtUserManager;

            var job = AppJobCurrentUserGet;

            Task<HostBasePartAuthUser> execute() => job.Execute(input);

            void onSuccess(HostBasePartAuthJobCurrentUserGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, HostBasePartAuthJobCurrentUserGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods
    }
}
