//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.Automation.Base.Parts.Angular.Config;
using Makc2020.Mods.Automation.Base.Parts.NetCore.Config;

namespace Makc2020.Mods.Automation.Base.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModAutomationBaseConfigSettings : IModAutomationBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Angular".
        /// </summary>
        public ModAutomationBasePartAngularConfigSettings PartAngular { get; set; }

        /// <inheritdoc/>
        IModAutomationBasePartAngularConfigSettings IModAutomationBaseConfigSettings.PartAngular => PartAngular;

        /// <summary>
        /// Часть "NetCore".
        /// </summary>
        public ModAutomationBasePartNetCoreConfigSettings PartNetCore { get; set; }

        /// <inheritdoc/>
        IModAutomationBasePartNetCoreConfigSettings IModAutomationBaseConfigSettings.PartNetCore => PartNetCore;

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