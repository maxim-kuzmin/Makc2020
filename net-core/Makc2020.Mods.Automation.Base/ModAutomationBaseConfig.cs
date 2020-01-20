//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.Automation.Base.Config;
using System.IO;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Конфигурация.
    /// </summary>
    public sealed class ModAutomationBaseConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IModAutomationBaseConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModAutomationBaseConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModAutomationBaseConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.Automation.Base.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModAutomationBaseConfigProvider CreateProvider(ModAutomationBaseConfigSettings settings)
        {
            return new ModAutomationBaseConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}