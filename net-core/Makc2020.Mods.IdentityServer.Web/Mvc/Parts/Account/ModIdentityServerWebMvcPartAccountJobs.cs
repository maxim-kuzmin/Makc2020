//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobs
    {
        #region Properties

        /// <summary>
        /// Задание на получение входа в систему.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginGetService JobLoginGet { get; private set; }

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
        /// Задание на отправку выхода из системы.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostService JobLogoutPost { get; private set; }

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
            JobLoginGet = new ModIdentityServerWebMvcPartAccountJobLoginGetService(
                service.GetLogin,
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

            JobLogoutPost = new ModIdentityServerWebMvcPartAccountJobLogoutPostService(
                service.PostLogout,
                coreBaseResourceErrors
                );
        }

        #endregion Constructor
    }
}
