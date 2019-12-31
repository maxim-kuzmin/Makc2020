//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Контекст.
    /// </summary>
    public class ModDummyMainCachingContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyMainCachingConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModDummyMainCachingJobs Jobs { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModDummyMainCachingContext(ModDummyMainCachingConfig config, ModDummyMainCachingExternals externals)
        {
            Config = config;

            Jobs = new ModDummyMainCachingJobs(
                externals.CoreBaseResourceErrors,
                externals.Cache,
                Config.Settings,
                externals.CoreCachingResourceErrors,
                externals.DataBaseSettings,
                externals.ResourceSuccesses,
                externals.ResourceErrors,
                externals.Service
                );
        }

        #endregion Constructor
    }
}
