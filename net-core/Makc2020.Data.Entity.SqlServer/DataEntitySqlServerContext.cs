//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.SqlServer.Db;

namespace Makc2020.Data.Entity.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Контекст.
    /// </summary>
    public class DataEntitySqlServerContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public DataEntitySqlServerConfig Config { get; private set; }

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
        public DataEntitySqlServerContext(
            DataEntitySqlServerConfig config,
            DataEntitySqlServerExternals externals
            )
        {
            Config = config;

            DbFactory = new DataEntitySqlServerDbFactory(
                Config.Settings.ConnectionString,
                externals.DataBaseSettings,
                externals.Environment
                );
        }

        #endregion Constructor
    }
}
