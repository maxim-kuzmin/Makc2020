//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Core.Web.Mvc;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Модель.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountModel : CoreWebMvcModel
    {
        #region Properties

        private ModIdentityServerWebMvcPartAccountJobLoginGetService AppJobLoginGet { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLoginPostService AppJobLoginPost { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLogoutGetService AppJobLogoutGet { get; set; }

        private ModIdentityServerWebMvcPartAccountJobLogoutPostService AppJobLogoutPost { get; set; }

        private IClientStore ExtClientStore { get; set; }

        private IEventService ExtEvents { get; set; }

        private IIdentityServerInteractionService ExtInteraction { get; set; }

        private IAuthenticationSchemeProvider ExtSchemeProvider { get; set; }

        private SignInManager<DataEntityObjectUser> ExtSignInManager { get; set; }

        private UserManager<DataEntityObjectUser> ExtUserManager { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appJobLoginGet">Задание на получение входа в систему.</param>
        /// <param name="appJobLoginPost">Задание на отправку входа в систему.</param>
        /// <param name="appJobLogoutGet">Задание на получение выхода из системы.</param>
        /// <param name="appJobLogoutPost">Задание на отправку выхода из системы.</param>
        /// <param name="extClientStore">Хранилище клиентов.</param>
        /// <param name="extEvents">События.</param>
        /// <param name="extInteraction">Взаимодействие.</param>
        /// <param name="extLogger">Регистратор.</param>
        /// <param name="extSchemeProvider">Поставщик схем.</param>
        /// <param name="extSignInManager">Менеджер входа в систему.</param>
        /// <param name="extUserManager">Менеджер пользователей.</param>
        /// <param name="extViewEngine">Средство создания представлений.</param>
        public ModIdentityServerWebMvcPartAccountModel(
            ModIdentityServerWebMvcPartAccountJobLoginGetService appJobLoginGet,
            ModIdentityServerWebMvcPartAccountJobLoginPostService appJobLoginPost,
            ModIdentityServerWebMvcPartAccountJobLogoutGetService appJobLogoutGet,
            ModIdentityServerWebMvcPartAccountJobLogoutPostService appJobLogoutPost,
            IClientStore extClientStore,
            IEventService extEvents,
            IIdentityServerInteractionService extInteraction,
            ILogger<ModIdentityServerWebMvcPartAccountModel> extLogger,
            IAuthenticationSchemeProvider extSchemeProvider,
            SignInManager<DataEntityObjectUser> extSignInManager,
            UserManager<DataEntityObjectUser> extUserManager,
            ICompositeViewEngine extViewEngine
            )
            : base(extLogger, extViewEngine)
        {
            AppJobLoginGet = appJobLoginGet;
            AppJobLoginPost = appJobLoginPost;
            AppJobLogoutGet = appJobLogoutGet;
            AppJobLogoutPost = appJobLogoutPost;
            ExtClientStore = extClientStore;
            ExtEvents = extEvents;
            ExtInteraction = extInteraction;
            ExtSchemeProvider = extSchemeProvider;
            ExtSignInManager = extSignInManager;
            ExtUserManager = extUserManager;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Вход в систему. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onError
            ) BuildActionLoginGet(ModIdentityServerWebMvcPartAccountJobLoginGetInput input)
        {
            input.СlientStore = ExtClientStore;
            input.Interaction = ExtInteraction;
            input.SchemeProvider = ExtSchemeProvider;

            var job = AppJobLoginGet;

            Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вход в систему. Отправка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountCommonJobLoginResult> onError
            ) BuildActionLoginPost(ModIdentityServerWebMvcPartAccountJobLoginPostInput input)
        {
            input.СlientStore = ExtClientStore;
            input.Events = ExtEvents;
            input.Interaction = ExtInteraction;
            input.SchemeProvider = ExtSchemeProvider;
            input.SignInManager = ExtSignInManager;
            input.UserManager = ExtUserManager;

            var job = AppJobLoginPost;

            Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountCommonJobLoginResult result)
            {
                job.OnError(ex, ExtLogger, result);

                foreach (var errorMessage in result.ErrorMessages)
                {
                    input.ModelState.AddModelError(string.Empty, errorMessage);
                }
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
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLogoutGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Выход из системы. Отправка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModIdentityServerWebMvcPartAccountJobLogoutPostOutput>> execute,
            Action<ModIdentityServerWebMvcPartAccountJobLogoutPostResult> onSuccess,
            Action<Exception, ModIdentityServerWebMvcPartAccountJobLogoutPostResult> onError
            ) BuildActionLogoutPost(ModIdentityServerWebMvcPartAccountJobLogoutPostInput input)
        {
            input.Events = ExtEvents;
            input.Interaction = ExtInteraction;
            input.SignInManager = ExtSignInManager;

            var job = AppJobLogoutPost;

            Task<ModIdentityServerWebMvcPartAccountJobLogoutPostOutput> execute() => job.Execute(input);

            void onSuccess(ModIdentityServerWebMvcPartAccountJobLogoutPostResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModIdentityServerWebMvcPartAccountJobLogoutPostResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods
    }
}