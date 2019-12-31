//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "DummyMainDummyManyToMany".
    /// </summary>
    public class DataEntitySchemaDummyMainDummyManyToMany : DataEntitySchema<DataEntityObjectDummyMainDummyManyToMany>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaDummyMainDummyManyToMany(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectDummyMainDummyManyToMany> builder)
        {
            var setting = DataBaseSettings.DummyMainDummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.ObjectDummyMainId, x.ObjectDummyManyToManyId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ObjectDummyMainId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyMainId);

            builder.Property(x => x.ObjectDummyManyToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyManyToManyId);

            builder.HasOne(x => x.ObjectDummyMain)
                .WithMany(x => x.ObjectsDummyMainDummyManyToMany)
                .HasForeignKey(x => x.ObjectDummyMainId)
                .HasConstraintName(setting.DbForeignKeyToDummyMain);

            builder.HasOne(x => x.ObjectDummyManyToMany)
                .WithMany(x => x.ObjectsDummyMainDummyManyToMany)
                .HasForeignKey(x => x.ObjectDummyManyToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyManyToMany);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectDummyMainDummyManyToMany>().HasData(
                Enumerable.Range(1, 100).SelectMany(id => CreateTestDataItem(id)).ToArray()
                );
        }

        #endregion Public methods

        #region Private methods

        private static List<DataEntityObjectDummyMainDummyManyToMany> CreateTestDataItem(long id)
        {
            var result = new List<DataEntityObjectDummyMainDummyManyToMany>();

            foreach (var linkedId in Enumerable.Range(1, 10))
            {
                var isEven = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10) % 2 == 0;

                if (isEven) continue;

                var item = new DataEntityObjectDummyMainDummyManyToMany
                {
                    ObjectDummyMainId = id,
                    ObjectDummyManyToManyId = linkedId,
                };

                result.Add(item);
            }

            return result;
        }

        #endregion Private methods
    }
}