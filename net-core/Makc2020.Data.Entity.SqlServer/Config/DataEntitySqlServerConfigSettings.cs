//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Data.Entity.SqlServer.Config
{
    /// <summary>
    /// Данные. Entity Framework. База данных MS SQL Server. Конфигурация. Настройки.
    /// </summary>
    public class DataEntitySqlServerConfigSettings : IDataEntitySqlServerConfigSettings
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
        internal static IDataEntitySqlServerConfigSettings Create(
            string configFilePath,
            CoreBaseEnvironment environment
            )
        {
            var result = new DataEntitySqlServerConfigSettings();

            var configProvider = new DataEntitySqlServerConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}