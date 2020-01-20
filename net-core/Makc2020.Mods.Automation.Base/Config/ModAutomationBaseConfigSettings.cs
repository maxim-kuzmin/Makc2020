//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Mods.Automation.Base.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModAutomationBaseConfigSettings : IModAutomationBaseConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string PathToJavascriptCodeFolder { get; set; }

        /// <inheritdoc/>
        public string PathToNetCoreCodeFolder { get; set; }

        /// <inheritdoc/>
        public string SourceEntityName { get; set; }

        /// <inheritdoc/>
        public string TargetEntityName { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IModAutomationBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModAutomationBaseConfigSettings();

            var configProvider = new ModAutomationBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}