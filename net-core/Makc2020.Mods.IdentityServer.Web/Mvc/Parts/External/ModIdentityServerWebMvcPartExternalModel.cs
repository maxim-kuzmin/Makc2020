//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Core.Base.Logging;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Makc2020.Host.Web;
using Makc2020.Host.Web.Mvc;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Модель.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalModel : HostWebMvcModel<HostWebState>
    {
        #region Properties        

        private ModIdentityServerWebMvcPartExternalJobCallbackGetService AppJobCallbackGet { get; set; }

        private ModIdentityServerWebMvcPartExternalJobChallengeGetService AppJobChallengeGet { get; set; }

        private HostBasePartAuthJobUserEntityCreateService AppJobUserEntityCreate { get; set; }

        private IClientStore ExtClientStore { get; set; }

        private IEventService ExtEvents { get; set; }

        private IIdentityServerInteractionService ExtInteraction { get; set; }

        private RoleManager<DataEntityObjectRole> ExtRoleManager { get; set; }

        private SignInManager<DataEntityObjectUser> ExtSignInManager { get; set; }

        private UserManager<DataEntityObjectUser> ExtUserManager { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appJobCallbackGet">Задание на получение обратного вызова.</param>
        /// <param name="appJobChallengeGet">Задание на отправку вызова.</param>
        /// <param name="appJobUserEntityCreate">Задание на создание сущности пользователя.</param>
        /// <param name="extClientStore">Хранилище клиентов.</param>
        /// <param name="extEvents">События.</param>
        /// <param name="extInteraction">Взаимодействие.</param>
        /// <param name="appLogger">Регистратор.</param>
        /// <param name="extRoleManager">Менеджер ролей.</param>
        /// <param name="extSignInManager">Менеджер входа в систему.</param>
        /// <param name="extUserManager">Менеджер пользователей.</param>
        /// <param name="extViewEngine">Средство создания представлений.</param>
        public ModIdentityServerWebMvcPartExternalModel(
            ModIdentityServerWebMvcPartExternalJobCallbackGetService appJobCallbackGet,
            ModIdentityServerWebMvcPartExternalJobChallengeGetService appJobChallengeGet,
            HostBasePartAuthJobUserEntityCreateService appJobUserEntityCreate,
            CoreBaseLoggingServiceWithCategoryName<ModIdentityServerWebMvcPartExternalModel> appLogger,
            IClientStore extClientStore,
            IEventService extEvents,
            IIdentityServerInteractionService extInteraction,            
            RoleManager<DataEntityObjectRole> extRoleManager,
            SignInManager<DataEntityObjectUser> extSignInManager,
            UserManager<DataEntityObjectUser> extUserManager,
            ICompositeViewEngine extViewEngine
            )
            : base(appLogger, extViewEngine)
        {
            AppJobCallbackGet = appJobCallbackGet;
            AppJobChallengeGet = appJobChallengeGet;
            AppJobUserEntityCreate = appJobUserEntityCreate;
            ExtClientStore = extClientStore;
            ExtEvents = extEvents;
            ExtInteraction = extInteraction;
            ExtRoleManager = extRoleManager;
            ExtSignInManager = extSignInManager;
            ExtUserManager = extUserManager;
        }

        #endregion Constructors

        #region Public methods
        
        /// <summary>
        /// Построить действие "Обратный вызов. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartExternalJobCallbackGetOutput>> execute,
            Action<ModIdentityServerWebMvcPartExternalJobCallbackGetResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartExternalJobCallbackGetResult> onError            
            ) BuildActionCallbackGet(ModIdentityServerWebMvcPartExternalJobCallbackGetInput input)
        {
            input.ClientStore = ExtClientStore;
            input.Events = ExtEvents;
            input.Interaction = ExtInteraction;
            input.JobUserEntityCreate = AppJobUserEntityCreate;
            input.Logger = AppLogger;
            input.RoleManager = ExtRoleManager;
            input.SignInManager = ExtSignInManager;
            input.UserManager = ExtUserManager;            

            var job = AppJobCallbackGet;

            Task<ModIdentityServerWebMvcPartExternalJobCallbackGetOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartExternalJobCallbackGetResult result)
            {                
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartExternalJobCallbackGetResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вызов. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartExternalJobChallengeGetOutput>> execute,
            Action<ModIdentityServerWebMvcPartExternalJobChallengeGetResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartExternalJobChallengeGetResult> onError
            ) BuildActionChallengeGet(ModIdentityServerWebMvcPartExternalJobChallengeGetInput input)
        {
            input.Interaction = ExtInteraction;
            
            var job = AppJobChallengeGet;

            Task< ModIdentityServerWebMvcPartExternalJobChallengeGetOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartExternalJobChallengeGetResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartExternalJobChallengeGetResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods
    }
}