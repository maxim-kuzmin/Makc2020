//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Контекст.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalContext
    {
        #region Properties

        /// <summary>
        /// Задания.
        /// </summary>
        public ModIdentityServerWebMvcPartExternalJobs Jobs { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModIdentityServerWebMvcPartExternalService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public ModIdentityServerWebMvcPartExternalContext(
            IModIdentityServerWebMvcPartAccountConfigSettings configSettings,
            ModIdentityServerWebMvcPartExternalExternals externals
            )
        {
            Service = new ModIdentityServerWebMvcPartExternalService(
                configSettings
                );

            Jobs = new ModIdentityServerWebMvcPartExternalJobs(
                externals.CoreBaseResourceErrors,
                externals.ResourceErrors,
                Service
                );
        }

        #endregion Constructor
    }
}
