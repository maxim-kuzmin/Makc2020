//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Data.Entity.Clients.PostgreSql.Config
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. Конфигурация. Настройки.
    /// </summary>
    public class DataEntityClientPostgreSqlConfigSettings : IDataEntityClientPostgreSqlConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string ConnectionString { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IDataEntityClientPostgreSqlConfigSettings Create(
            string configFilePath,
            CoreBaseEnvironment environment
            )
        {
            var result = new DataEntityClientPostgreSqlConfigSettings();

            var configProvider = new DataEntityClientPostgreSqlConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}