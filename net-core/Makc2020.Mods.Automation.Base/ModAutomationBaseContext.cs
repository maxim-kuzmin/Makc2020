//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Контекст.
    /// </summary>
    public class ModAutomationBaseContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModAutomationBaseConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModAutomationBaseJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModAutomationBaseResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModAutomationBaseService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModAutomationBaseContext(ModAutomationBaseConfig config, ModAutomationBaseExternals externals)
        {
            Config = config;
            
            Resources = new ModAutomationBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            Service = new ModAutomationBaseService(
                Config.Settings
                );

            Jobs = new ModAutomationBaseJobs(
                externals.CoreBaseResourceErrors,
                Resources.Successes,
                Resources.Errors,
                Service
                );
        }

        #endregion Constructor
    }
}
