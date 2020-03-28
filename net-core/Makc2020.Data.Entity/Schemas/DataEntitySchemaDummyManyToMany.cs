//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "DummyManyToMany".
    /// </summary>
    public class DataEntitySchemaDummyManyToMany : DataEntitySchema<DataEntityObjectDummyManyToMany>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaDummyManyToMany(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectDummyManyToMany> builder)
        {
            var setting = DataBaseSettings.DummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);

            builder.HasIndex(x => x.Name).IsUnique().HasName(setting.DbUniqueIndexForName);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectDummyManyToMany>().HasData(
                Enumerable.Range(1, 10).Select(id => CreateTestDataItem(id)).ToArray()
                );
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityObjectDummyManyToMany CreateTestDataItem(long id)
        {
            return new DataEntityObjectDummyManyToMany
            {
                Id = id,
                Name = $"Name-{id}"
            };
        }

        #endregion Private methods
    }
}
