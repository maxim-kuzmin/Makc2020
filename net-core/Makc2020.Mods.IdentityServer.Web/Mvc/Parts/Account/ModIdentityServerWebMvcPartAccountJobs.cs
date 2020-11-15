//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobs
    {
        #region Properties

        /// <summary>
        /// Задание на обработку получения входа в систему.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginGetProcessService JobLoginGetProcess { get; private set; }

        /// <summary>
        /// Задание на создание отклика на получение входа в систему.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginGetProduceService JobLoginGetProduce { get; private set; }

        /// <summary>
        /// Задание на обработку отправки данных входа в систему.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginPostProcessService JobLoginPostProcess { get; private set; }

        /// <summary>
        /// Задание на создание отклика на отправку данных входа в систему.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginPostProduceService JobLoginPostProduce { get; private set; }

        /// <summary>
        /// Задание на получение выхода из системы.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLogoutGetService JobLogoutGet { get; private set; }

        /// <summary>
        /// Задание на обработку отправки данных выхода из системы.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostProcessService JobLogoutPostProcess { get; private set; }

        /// <summary>
        /// Задание на создание отклика на отправку данных выхода из системы.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostProduceService JobLogoutPostProduce { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModIdentityServerWebMvcPartAccountJobs(
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModIdentityServerBaseResourceSuccesses resourceSuccesses,
            ModIdentityServerBaseResourceErrors resourceErrors,
            ModIdentityServerWebMvcPartAccountService service
        )
        {
            JobLoginGetProcess = new ModIdentityServerWebMvcPartAccountJobLoginGetProcessService(
                service.GetLoginProcess,
                coreBaseResourceErrors
            );

            JobLoginGetProduce = new ModIdentityServerWebMvcPartAccountJobLoginGetProduceService(
                service.GetLoginProduce,
                coreBaseResourceErrors
            );

            JobLoginPostProcess = new ModIdentityServerWebMvcPartAccountJobLoginPostProcessService(
                service.PostLoginProcess,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );

            JobLoginPostProduce = new ModIdentityServerWebMvcPartAccountJobLoginPostProduceService(
                service.PostLoginProduce,
                coreBaseResourceErrors
                );

            JobLogoutGet = new ModIdentityServerWebMvcPartAccountJobLogoutGetService(
                service.GetLogout,
                coreBaseResourceErrors
                );

            JobLogoutPostProcess = new ModIdentityServerWebMvcPartAccountJobLogoutPostProcessService(
                service.PostLogoutProcess,
                coreBaseResourceErrors
                );

            JobLogoutPostProduce = new ModIdentityServerWebMvcPartAccountJobLogoutPostProduceService(
                service.PostLogoutProduce,
                coreBaseResourceErrors
                );
        }

        #endregion Constructor
    }
}
