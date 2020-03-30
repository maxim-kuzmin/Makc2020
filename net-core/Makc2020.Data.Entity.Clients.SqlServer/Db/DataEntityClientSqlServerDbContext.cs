﻿//Author Maxim Kuzmin//makc//

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

        private DataBaseSettings DataBaseSettings { get; set; }

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
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        public DataEntityClientSqlServerDbContext(
            DbContextOptions<DataEntityDbContext> options,
            DataBaseSettings dataBaseSettings
            )
            : base(options)
        {
            DataBaseSettings = dataBaseSettings;
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

            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyMain(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyManyToMany(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyMainDummyManyToMany(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyOneToMany(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyTree(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaDummyTreeLink(DataBaseSettings));

            modelBuilder.ApplyConfiguration(new DataEntitySchemaRole(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaRoleClaim(DataBaseSettings));

            modelBuilder.ApplyConfiguration(new DataEntitySchemaUser(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserClaim(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserLogin(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserRole(DataBaseSettings));
            modelBuilder.ApplyConfiguration(new DataEntitySchemaUserToken(DataBaseSettings));

#if TEST || DEBUG
            SeedTestData(modelBuilder);
#endif
        }

        #endregion Protected methods
    }
}