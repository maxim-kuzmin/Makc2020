//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Entity.Clients.SqlServer.Config;
using System.IO;

namespace Makc2020.Data.Entity.Clients.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Конфигурация.
    /// </summary>
    public sealed class DataEntityClientSqlServerConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IDataEntityClientSqlServerConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public DataEntityClientSqlServerConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = DataEntityClientSqlServerConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Data.Entity.Clients.SqlServer.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public DataEntityClientSqlServerConfigProvider CreateProvider(DataEntityClientSqlServerConfigSettings settings)
        {
            return new DataEntityClientSqlServerConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}