//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Задания.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalJobs
    {
        #region Properties

        /// <summary>
        /// Задание на получение обратного вызова.
        /// </summary>
        public ModIdentityServerWebMvcPartExternalJobCallbackGetService JobCallbackGet { get; private set; }

        /// <summary>
        /// Задание на получение вызова.
        /// </summary>
        public ModIdentityServerWebMvcPartExternalJobChallengeGetService JobChallengeGet { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModIdentityServerWebMvcPartExternalJobs(
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModIdentityServerBaseResourceErrors resourceErrors,
            ModIdentityServerWebMvcPartExternalService service
            )
        {
            JobCallbackGet = new ModIdentityServerWebMvcPartExternalJobCallbackGetService(
                service.GetCallback,
                coreBaseResourceErrors,
                resourceErrors
                );

            JobChallengeGet = new ModIdentityServerWebMvcPartExternalJobChallengeGetService(
                service.GetChallenge,
                coreBaseResourceErrors,
                resourceErrors
                );
        }

        #endregion Constructor
    }
}
