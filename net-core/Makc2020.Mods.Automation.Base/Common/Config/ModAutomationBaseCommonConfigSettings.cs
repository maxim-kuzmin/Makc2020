//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.Automation.Base.Common.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Конфигурация. Настройки.
    /// </summary>
    public class ModAutomationBaseCommonConfigSettings : IModAutomationBaseCommonConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string Path { get; set; }

        /// <inheritdoc/>
        public string SourceEntityName { get; set; }

        /// <inheritdoc/>
        public string TargetEntityName { get; set; }

        #endregion Properties
    }
}