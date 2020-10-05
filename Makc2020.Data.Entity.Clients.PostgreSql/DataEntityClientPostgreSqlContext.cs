//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Clients.PostgreSql.Db;
using Makc2020.Data.Entity.Db;

namespace Makc2020.Data.Entity.Clients.PostgreSql
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Контекст.
    /// </summary>
    public class DataEntityClientPostgreSqlContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public DataEntityClientPostgreSqlConfig Config { get; private set; }

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public DataEntityDbFactory DbFactory { get; private set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public DataBaseSettings Settings => DataEntityClientPostgreSqlSettings.Instance;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public DataEntityClientPostgreSqlContext(
            DataEntityClientPostgreSqlConfig config,
            DataEntityClientPostgreSqlExternals externals
            )
        {
            Config = config;

            DbFactory = new DataEntityClientPostgreSqlDbFactory(
                Config.Settings.ConnectionString,
                Settings,
                externals.Environment
                );
        }

        #endregion Constructor
    }
}
