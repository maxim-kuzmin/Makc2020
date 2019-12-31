//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Контекст.
    /// </summary>
    public class ModDummyMainBaseContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyMainBaseConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModDummyMainBaseJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModDummyMainBaseResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModDummyMainBaseService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModDummyMainBaseContext(ModDummyMainBaseConfig config, ModDummyMainBaseExternals externals)
        {
            Config = config;
            
            Resources = new ModDummyMainBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            Service = new ModDummyMainBaseService(
                Config.Settings,
                externals.CoreBaseDataProvider,
                externals.DataEntityDbFactory
                );

            Jobs = new ModDummyMainBaseJobs(
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
