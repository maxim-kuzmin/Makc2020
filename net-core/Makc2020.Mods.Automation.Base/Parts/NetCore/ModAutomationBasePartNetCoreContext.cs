//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Parts.NetCore.Config;

namespace Makc2020.Mods.Automation.Base.Parts.NetCore
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "NetCore". Контекст.
    /// </summary>
    public class ModAutomationBasePartNetCoreContext
    {
        #region Properties

        /// <summary>
        /// Задания.
        /// </summary>
        public ModAutomationBasePartNetCoreJobs Jobs { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModAutomationBasePartNetCoreService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public ModAutomationBasePartNetCoreContext(
            IModAutomationBasePartNetCoreConfigSettings configSettings,
            ModAutomationBasePartNetCoreExternals externals
            )
        {
            Service = new ModAutomationBasePartNetCoreService();

            Jobs = new ModAutomationBasePartNetCoreJobs(
                externals.CoreBaseResourceErrors,
                externals.ResourceSuccesses,
                externals.ResourceErrors,
                configSettings,
                Service
                );
        }

        #endregion Constructor
    }
}
