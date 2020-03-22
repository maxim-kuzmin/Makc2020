//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Base;
using Makc2020.Data.Entity.Clients.SqlServer.Config;
using Makc2020.Data.Entity.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Makc2020.Data.Entity.Clients.SqlServer.Db
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. База данных. Фабрика.
    /// </summary>
    public class DataEntityClientSqlServerDbFactory : DataEntityDbFactory
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntityClientSqlServerDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public DataEntityClientSqlServerDbFactory(
            string connectionString,
            DataBaseSettings settings,
            CoreBaseEnvironment environment
            )
            : base(connectionString, settings, environment)
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            var configFilePath = DataEntityClientSqlServerConfig.CreateFilePath();

            var configSettings = DataEntityClientSqlServerConfigSettings.Create(configFilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override DataBaseSettings CreateSettings()
        {
            return DataEntityClientSqlServerSettings.Instance;
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
