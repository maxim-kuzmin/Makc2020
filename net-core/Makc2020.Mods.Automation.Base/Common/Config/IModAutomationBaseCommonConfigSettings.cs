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
        /// Имя исходной сущности.
        /// </summary>
        string SourceEntityName { get; }

        /// <summary>
        /// Исходный путь.
        /// </summary>
        string SourcePath { get; }

        /// <summary>
        /// Имя конечной сущности.
        /// </summary>
        string TargetEntityName { get; }

        /// <summary>
        /// Конечный путь.
        /// </summary>
        string TargetPath { get; }

        #endregion Properties
    }
}