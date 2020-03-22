//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Data.Entity.Clients.SqlServer.Config
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Конфигурация. Настройки.
    /// </summary>
    public class DataEntityClientSqlServerConfigSettings : IDataEntityClientSqlServerConfigSettings
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
        internal static IDataEntityClientSqlServerConfigSettings Create(
            string configFilePath,
            CoreBaseEnvironment environment
            )
        {
            var result = new DataEntityClientSqlServerConfigSettings();

            var configProvider = new DataEntityClientSqlServerConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}