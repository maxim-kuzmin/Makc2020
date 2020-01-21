//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.Automation.Base.Common.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModAutomationBaseCommonConfigSettings
    {
        #region Properties

        /// <summary>
        /// Путь.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Имя исходной сущности.
        /// </summary>
        string SourceEntityName { get; }

        /// <summary>
        /// Имя целевой сущности.
        /// </summary>
        string TargetEntityName { get; }

        #endregion Properties
    }
}