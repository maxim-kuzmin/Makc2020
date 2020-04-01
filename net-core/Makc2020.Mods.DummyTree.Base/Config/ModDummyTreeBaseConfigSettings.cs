//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Mods.DummyTree.Base.Config
{
    /// <summary>
    /// Мод "DummyTree". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModDummyTreeBaseConfigSettings : IModDummyTreeBaseConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public int DbCommandTimeout { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IModDummyTreeBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModDummyTreeBaseConfigSettings();

            var configProvider = new ModDummyTreeBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}