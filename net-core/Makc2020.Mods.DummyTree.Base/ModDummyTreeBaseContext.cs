//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Контекст.
    /// </summary>
    public class ModDummyTreeBaseContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyTreeBaseConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModDummyTreeBaseJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModDummyTreeBaseResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModDummyTreeBaseService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModDummyTreeBaseContext(ModDummyTreeBaseConfig config, ModDummyTreeBaseExternals externals)
        {
            Config = config;
            
            Resources = new ModDummyTreeBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            Service = new ModDummyTreeBaseService(
                Config.Settings,
                externals.CoreBaseDataProvider,
                externals.DataBaseSettings,
                externals.DataEntityDbFactory
                );

            Jobs = new ModDummyTreeBaseJobs(
                externals.CoreBaseResourceErrors,
                externals.DataBaseSettings,
                Resources.Successes,
                Resources.Errors,
                Service
                );
        }

        #endregion Constructor
    }
}
