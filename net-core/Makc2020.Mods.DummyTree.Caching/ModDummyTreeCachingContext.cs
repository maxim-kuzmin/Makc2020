//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyTree.Caching
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Контекст.
    /// </summary>
    public class ModDummyTreeCachingContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyTreeCachingConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModDummyTreeCachingJobs Jobs { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModDummyTreeCachingContext(ModDummyTreeCachingConfig config, ModDummyTreeCachingExternals externals)
        {
            Config = config;

            Jobs = new ModDummyTreeCachingJobs(
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
