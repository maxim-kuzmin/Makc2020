//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Mods.DummyMain.Base.Config
{
    /// <summary>
    /// Мод "DummyMain". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModDummyMainBaseConfigSettings : IModDummyMainBaseConfigSettings
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
        internal static IModDummyMainBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModDummyMainBaseConfigSettings();

            var configProvider = new ModDummyMainBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}