//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Base;
using Makc2020.Data.Entity.Clients.PostgreSql.Config;
using Makc2020.Data.Entity.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Makc2020.Data.Entity.Clients.PostgreSql.Db
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. База данных. Фабрика.
    /// </summary>
    public class DataEntityClientPostgreSqlDbFactory : DataEntityDbFactory, IDesignTimeDbContextFactory<DataEntityClientPostgreSqlDbContext>
    {
        #region Properties

        /// <summary>
        /// Экземпляр по умолчанию.
        /// </summary>
        public static DataEntityClientPostgreSqlDbFactory Default { get; } = new DataEntityClientPostgreSqlDbFactory();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public DataEntityClientPostgreSqlDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public DataEntityClientPostgreSqlDbFactory(
            string connectionString,
            DataBaseSettings settings,
            CoreBaseEnvironment environment
            )
            : base(connectionString, settings, environment)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public DataEntityClientPostgreSqlDbContext CreateDbContext(string[] args)
        {
            return new DataEntityClientPostgreSqlDbContext(Options, Settings);
        }

        /// <inheritdoc/>
        public sealed override DataEntityDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            var configFilePath = DataEntityClientPostgreSqlConfig.CreateFilePath();

            var configSettings = DataEntityClientPostgreSqlConfigSettings.Create(configFilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override DataBaseSettings CreateSettings()
        {
            return DataEntityClientPostgreSqlSettings.Instance;
        }

        /// <inheritdoc/>
        public sealed override void BuildDbContextOptions(DbContextOptionsBuilder builder)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            builder.UseNpgsql(ConnectionString, b => b.MigrationsAssembly(assemblyName));
        }

        #endregion Protected methods
    }
}
