//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Контекст.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountContext
    {
        #region Properties

        /// <summary>
        /// Задания.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobs Jobs { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public ModIdentityServerWebMvcPartAccountContext(
            IModIdentityServerWebMvcPartAccountConfigSettings configSettings,
            ModIdentityServerWebMvcPartAccountExternals externals
            )
        {
            Service = new ModIdentityServerWebMvcPartAccountService(
                configSettings
                );

            Jobs = new ModIdentityServerWebMvcPartAccountJobs(
                externals.CoreBaseResourceErrors,
                externals.ResourceSuccesses,
                externals.ResourceErrors,
                Service
                );
        }

        #endregion Constructor
    }
}
