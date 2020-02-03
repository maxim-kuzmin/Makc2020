//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Base;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.SqlServer.Config;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Makc2020.Data.Entity.SqlServer.Db
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. База данных. Фабрика.
    /// </summary>
    public class DataEntitySqlServerDbFactory : DataEntityDbFactory
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySqlServerDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public DataEntitySqlServerDbFactory(
            string connectionString,
            DataBaseSettings dataBaseSettings,
            CoreBaseEnvironment environment
            )
            : base(connectionString, dataBaseSettings, environment)
        {
            Environment = environment;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            var configFilePath = DataEntitySqlServerConfig.CreateFilePath();

            var configSettings = DataEntitySqlServerConfigSettings.Create(configFilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        public sealed override void BuildDbContextOptions(DbContextOptionsBuilder builder)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(assemblyName));
        }

        #endregion Protected methods
    }
}
