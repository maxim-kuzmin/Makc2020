//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Makc2020.Data.Entity.Clients.SqlServer.Db
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. База данных. Контекст.
    /// </summary>
    public class DataEntityClientSqlServerDbContext : DataEntityDbContext
    {
        #region Properties

        private DataBaseSettings Settings { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public DataEntityClientSqlServerDbContext()
            : this(
                  DataEntityClientSqlServerDbFactory.Default.Options,
                  DataEntityClientSqlServerDbFactory.Default.Settings
                  )
        {
        }

        /// <inheritdoc/>
        public DataEntityClientSqlServerDbContext(DbContextOptions<DataEntityDbContext> options)
            : this(options, DataEntityClientSqlServerDbFactory.Default.Settings)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        /// <param name="settings">Настройки.</param>
        public DataEntityClientSqlServerDbContext(
            DbContextOptions<DataEntityDbContext> options,
            DataBaseSettings settings
            )
            : base(options)
        {
            Settings = settings;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Обработать событие создания модели.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyMain(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyManyToMany(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyMainDummyManyToMany(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyOneToMany(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyTree(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyTreeLink(Settings));

            modelBuilder.ApplyConfiguration(new DataEntitySchemaRole(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaRoleClaim(Settings));

            modelBuilder.ApplyConfiguration(new DataEntitySchemaUser(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserClaim(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserLogin(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserRole(Settings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserToken(Settings));
        }

        #endregion Protected methods
    }
}