//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Data.Entity.Config
{
    /// <summary>
    /// Данные. Entity Framework. Конфигурация. Настройки.
    /// </summary>
    public class DataEntityConfigSettings : IDataEntityConfigSettings
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
        internal static IDataEntityConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new DataEntityConfigSettings();

            var configProvider = new DataEntityConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}