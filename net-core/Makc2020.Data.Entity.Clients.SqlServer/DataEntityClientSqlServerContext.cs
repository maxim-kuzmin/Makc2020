//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Clients.SqlServer.Db;

namespace Makc2020.Data.Entity.Clients.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Контекст.
    /// </summary>
    public class DataEntityClientSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public DataEntityClientSqlServerConfig Config { get; private set; }

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public DataEntityDbFactory DbFactory { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public DataEntityClientSqlServerContext(
            DataEntityClientSqlServerConfig config,
            DataEntityClientSqlServerExternals externals
            )
        {
            Config = config;

            DbFactory = new DataEntityClientSqlServerDbFactory(
                Config.Settings.ConnectionString,
                externals.DataBaseSettings,
                externals.Environment
                );
        }

        #endregion Constructor
    }
}
