//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Entity.SqlServer.Config;
using System.IO;

namespace Makc2020.Data.Entity.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Конфигурация.
    /// </summary>
    public sealed class DataEntitySqlServerConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IDataEntitySqlServerConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public DataEntitySqlServerConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = DataEntitySqlServerConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Data.Entity.SqlServer.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public DataEntitySqlServerConfigProvider CreateProvider(DataEntitySqlServerConfigSettings settings)
        {
            return new DataEntitySqlServerConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}