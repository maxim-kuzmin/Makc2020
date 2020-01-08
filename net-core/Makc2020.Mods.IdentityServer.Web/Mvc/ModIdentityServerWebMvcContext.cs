//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External;

namespace Makc2020.Mods.IdentityServer.Web.Mvc
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Контекст.
    /// </summary>
    public class ModIdentityServerWebMvcContext
    {
        #region Properties        

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModIdentityServerWebMvcConfig Config { get; private set; }

        /// <summary>
        /// Часть "Account".
        /// </summary>
        public ModIdentityServerWebMvcPartAccountContext PartAccount { get; set; }

        /// <summary>
        /// Часть "External".
        /// </summary>
        public ModIdentityServerWebMvcPartExternalContext PartExternal { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModIdentityServerWebMvcContext(ModIdentityServerWebMvcConfig config, ModIdentityServerWebMvcExternals externals)
        {
            Config = config;

            PartAccount = new ModIdentityServerWebMvcPartAccountContext(
                Config.Settings.PartAccount,
                externals.PartAccount
                );

            PartExternal = new ModIdentityServerWebMvcPartExternalContext(
                Config.Settings.PartAccount,
                externals.PartExternal
                );
        }

        #endregion Constructor
    }
}
