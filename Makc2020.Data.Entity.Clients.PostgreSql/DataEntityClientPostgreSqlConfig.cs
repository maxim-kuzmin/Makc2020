//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Entity.Clients.PostgreSql.Config;
using System.IO;

namespace Makc2020.Data.Entity.Clients.PostgreSql
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. Конфигурация.
    /// </summary>
    public sealed class DataEntityClientPostgreSqlConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IDataEntityClientPostgreSqlConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public DataEntityClientPostgreSqlConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = DataEntityClientPostgreSqlConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Data.Entity.Clients.PostgreSql.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public DataEntityClientPostgreSqlConfigProvider CreateProvider(DataEntityClientPostgreSqlConfigSettings settings)
        {
            return new DataEntityClientPostgreSqlConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}