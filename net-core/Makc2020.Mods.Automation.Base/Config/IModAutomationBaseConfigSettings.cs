//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.Automation.Base.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModAutomationBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Путь к папке с кодом "Javascript".
        /// </summary>
        string PathToJavascriptCodeFolder { get; }

        /// <summary>
        /// Путь к папке с кодом ".NET Core".
        /// </summary>
        string PathToNetCoreCodeFolder { get; }

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