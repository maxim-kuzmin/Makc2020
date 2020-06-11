//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Core.Base.Logging;
using Makc2020.Core.Web.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Makc2020.Host.Base.Parts.Ldap.Jobs.Login;
using Makc2020.Host.Web;
using Makc2020.Host.Web.Mvc;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Модель.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountModel : HostWebMvcModel<HostWebState>
    {
        #region Properties

        private HostBasePartLdapJobLoginService AppJobLdapLogin { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLoginGetProcessService AppJobLoginGetProcess { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLoginGetProduceService AppJobLoginGetProduce { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLoginPostProcessService AppJobLoginPostProcess { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLoginPostProduceService AppJobLoginPostProduce { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLogoutGetService AppJobLogoutGet { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLogoutPostProcessService AppJobLogoutPostProcess { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLogoutPostProduceService AppJobLogoutPostProduce { get; set; }

        private HostBasePartAuthJobUserEntityCreateService AppJobUserEntityCreate { get; set; }

        private IClientStore ExtClientStore { get; set; }

        private IEventService ExtEvents { get; set; }

        private IIdentityServerInteractionService ExtInteraction { get; set; }

        private RoleManager<DataEntityObjectRole> ExtRoleManager { get; set; }

        private IAuthenticationSchemeProvider ExtSchemeProvider { get; set; }

        private SignInManager<DataEntityObjectUser> ExtSignInManager { get; set; }

        private UserManager<DataEntityObjectUser> ExtUserManager { get; set; }


        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appJobLdapLogin">Задание на вход в систему через LDAP.</param>
        /// <param name="appJobLoginGetProcess">Задание на обработку получения входа в систему.</param>
        /// <param name="appJobLoginGetProduce">Задание на создание отклика на получение входа в систему.</param>
        /// <param name="appJobLoginPostProcess">Задание на обработку отправки данных входа в систему.</param>
        /// <param name="appJobLoginPostProduce">Задание на создание отклика на отправку данных входа в систему.</param>
        /// <param name="appJobLogoutGet">Задание на получение выхода из системы.</param>
        /// <param name="appJobLogoutPostProcess">Задание на обработку отправки данных выхода из системы.</param>
        /// <param name="appJobLogoutPostProduce">Задание на создание отклика на отправку данных выхода из системы.</param>
        /// <param name="appJobUserEntityCreate">Задание на создание сущности пользователя.</param>
        /// /// <param name="appLogger">Регистратор.</param>
        /// <param name="extClientStore">Хранилище клиентов.</param>
        /// <param name="extEvents">События.</param>
        /// <param name="extInteraction">Взаимодействие.</param>        
        /// <param name="extRoleManager">Менеджер ролей.</param>
        /// <param name="extSchemeProvider">Поставщик схем.</param>
        /// <param name="extSignInManager">Менеджер входа в систему.</param>
        /// <param name="extUserManager">Менеджер пользователей.</param>
        /// <param name="extViewEngine">Средство создания представлений.</param>
        public ModIdentityServerWebMvcPartAccountModel(
            HostBasePartLdapJobLoginService appJobLdapLogin,
            ModIdentityServerWebMvcPartAccountJobLoginGetProcessService appJobLoginGetProcess,
            ModIdentityServerWebMvcPartAccountJobLoginGetProduceService appJobLoginGetProduce,
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessService appJobLoginPostProcess,
            ModIdentityServerWebMvcPartAccountJobLoginPostProduceService appJobLoginPostProduce,
            ModIdentityServerWebMvcPartAccountJobLogoutGetService appJobLogoutGet,
            ModIdentityServerWebMvcPartAccountJobLogoutPostProcessService appJobLogoutPostProcess,
            ModIdentityServerWebMvcPartAccountJobLogoutPostProduceService appJobLogoutPostProduce,
            HostBasePartAuthJobUserEntityCreateService appJobUserEntityCreate,
            CoreBaseLoggingServiceWithCategoryName<ModIdentityServerWebMvcPartAccountModel> appLogger,
            IClientStore extClientStore,
            IEventService extEvents,
            IIdentityServerInteractionService extInteraction,
            RoleManager<DataEntityObjectRole> extRoleManager,
            IAuthenticationSchemeProvider extSchemeProvider,
            SignInManager<DataEntityObjectUser> extSignInManager,
            UserManager<DataEntityObjectUser> extUserManager,
            ICompositeViewEngine extViewEngine
        )
            : base(appLogger, extViewEngine)
        {
            AppJobLdapLogin = appJobLdapLogin;
            AppJobLoginGetProcess = appJobLoginGetProcess;
            AppJobLoginGetProduce = appJobLoginGetProduce;
            AppJobLoginPostProcess = appJobLoginPostProcess;
            AppJobLoginPostProduce = appJobLoginPostProduce;
            AppJobLogoutGet = appJobLogoutGet;
            AppJobLogoutPostProcess = appJobLogoutPostProcess;
            AppJobLogoutPostProduce = appJobLogoutPostProduce;
            AppJobUserEntityCreate = appJobUserEntityCreate;
            ExtClientStore = extClientStore;
            ExtEvents = extEvents;
            ExtInteraction = extInteraction;
            ExtRoleManager = extRoleManager;
            ExtSchemeProvider = extSchemeProvider;
            ExtSignInManager = extSignInManager;
            ExtUserManager = extUserManager;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Вход в систему. Получение. Обработка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountJobLoginGetProcessResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountJobLoginGetProcessResult> onError
            ) BuildActionLoginGetProcess(ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput input)
        {
            var job = AppJobLoginGetProcess;

            Task<ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountJobLoginGetProcessResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLoginGetProcessResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вход в систему. Получение. Создание отклика".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onError
            ) BuildActionLoginGetProduce(ModIdentityServerWebMvcPartAccountJobLoginGetProduceInput input)
        {
            input.СlientStore = ExtClientStore;
            input.Interaction = ExtInteraction;
            input.SchemeProvider = ExtSchemeProvider;

            var job = AppJobLoginGetProduce;

            Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вход в систему. Отправка. Обработка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountJobLoginPostProcessResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountJobLoginPostProcessResult> onError
            ) BuildActionLoginPostProcess(ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput input)
        {
            input.СlientStore = ExtClientStore;
            input.Events = ExtEvents;
            input.Interaction = ExtInteraction;
            input.JobLdapLogin = AppJobLdapLogin;
            input.JobUserEntityCreate = AppJobUserEntityCreate;
            input.Logger = AppLogger;
            input.RoleManager = ExtRoleManager;
            input.SchemeProvider = ExtSchemeProvider;
            input.SignInManager = ExtSignInManager;
            input.UserManager = ExtUserManager;

            var job = AppJobLoginPostProcess;

            Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountJobLoginPostProcessResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLoginPostProcessResult result)
            {
                job.OnError(ex, AppLogger, result);

                input.ModelState.CoreWebExtModelStateFill(result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вход в систему. Отправка. Создание отклика".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onError
            ) BuildActionLoginPostProduce(ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput input)
        {
            input.СlientStore = ExtClientStore;
            input.Interaction = ExtInteraction;
            input.SchemeProvider = ExtSchemeProvider;

            var job = AppJobLoginPostProduce;

            Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnError(ex, AppLogger, result);

                input.ModelState.CoreWebExtModelStateFill(result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Выход из системы. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountJobLogoutGetOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountJobLogoutGetResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountJobLogoutGetResult> onError
            ) BuildActionLogoutGet(ModIdentityServerWebMvcPartAccountJobLogoutGetInput input)
        {
            input.Interaction = ExtInteraction;

            var job = AppJobLogoutGet;

            Task<ModIdentityServerWebMvcPartAccountJobLogoutGetOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountJobLogoutGetResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLogoutGetResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Выход из системы. Отправка. Обработка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountJobLogoutPostProcessResult> onError
            ) BuildActionLogoutPostProcess(ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput input)
        {
            input.Events = ExtEvents;
            input.Interaction = ExtInteraction;
            input.SignInManager = ExtSignInManager;

            var job = AppJobLogoutPostProcess;

            Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountJobLogoutPostProcessResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLogoutPostProcessResult result)
            {
                job.OnError(ex, AppLogger, result);

                input.ModelState.CoreWebExtModelStateFill(result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Выход из системы. Отправка. Создание отклика".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountJobLogoutPostProduceResult> onError
            ) BuildActionLogoutPostProduce(ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput input)
        {
            input.Interaction = ExtInteraction;

            var job = AppJobLogoutPostProduce;

            Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountJobLogoutPostProduceResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLogoutPostProduceResult result)
            {
                job.OnError(ex, AppLogger, result);

                input.ModelState.CoreWebExtModelStateFill(result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods
    }
}