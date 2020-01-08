//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Контекст.
    /// </summary>
    public class ModIdentityServerBaseContext
    {
        #region Properties        

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModIdentityServerBaseConfig Config { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModIdentityServerBaseResources Resources { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModIdentityServerBaseContext(ModIdentityServerBaseConfig config, ModIdentityServerBaseExternals externals)
        {
            Config = config;

            Resources = new ModIdentityServerBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer,
                externals.ResourceTitlesLocalizer
                );
        }

        #endregion Constructor
    }
}
