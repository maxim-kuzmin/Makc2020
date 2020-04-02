//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "DummyTreeLink".
    /// </summary>
    public class DataEntitySchemaDummyTreeLink : DataEntitySchema<DataEntityObjectDummyTreeLink>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaDummyTreeLink(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectDummyTreeLink> builder)
        {
            var setting = DataBaseSettings.DummyTreeLink;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.Id, x.ParentId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ParentId).IsRequired();

            builder.Property(x => x.Level).IsRequired();

            builder.HasOne(x => x.ObjectDummyTree)
                .WithMany(x => x.ObjectsDummyTreeLink)
                .HasForeignKey(x => x.Id)
                .HasConstraintName(setting.DbForeignKeyToDummyTree);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectDummyTreeLink>().HasData(
                CreateTestDataItem(0, 1, 0),

                CreateTestDataItem(0, 2, 1),
                CreateTestDataItem(1, 2, 0),

                CreateTestDataItem(0, 5, 2),
                CreateTestDataItem(1, 5, 1),
                CreateTestDataItem(2, 5, 0),

                CreateTestDataItem(0, 6, 2),
                CreateTestDataItem(1, 6, 1),
                CreateTestDataItem(2, 6, 0),

                CreateTestDataItem(0, 7, 2),
                CreateTestDataItem(1, 7, 1),
                CreateTestDataItem(2, 7, 0),

                CreateTestDataItem(0, 3, 1),
                CreateTestDataItem(1, 3, 0),

                CreateTestDataItem(0, 8, 2),
                CreateTestDataItem(1, 8, 1),
                CreateTestDataItem(3, 8, 0),

                CreateTestDataItem(0, 9, 2),
                CreateTestDataItem(1, 9, 1),
                CreateTestDataItem(3, 9, 0),

                CreateTestDataItem(0, 38, 2),
                CreateTestDataItem(1, 38, 1),
                CreateTestDataItem(3, 38, 0),

                CreateTestDataItem(0, 4, 1),
                CreateTestDataItem(1, 4, 0),

                CreateTestDataItem(0, 10, 2),
                CreateTestDataItem(1, 10, 1),
                CreateTestDataItem(4, 10, 0),

                CreateTestDataItem(0, 31, 2),
                CreateTestDataItem(1, 31, 1),
                CreateTestDataItem(4, 31, 0),

                CreateTestDataItem(0, 32, 2),
                CreateTestDataItem(1, 32, 1),
                CreateTestDataItem(4, 32, 0),

                CreateTestDataItem(0, 11, 0),

                CreateTestDataItem(0, 12, 1),
                CreateTestDataItem(11, 12, 0),

                CreateTestDataItem(0, 15, 2),
                CreateTestDataItem(11, 15, 1),
                CreateTestDataItem(12, 15, 0),

                CreateTestDataItem(0, 16, 2),
                CreateTestDataItem(11, 16, 1),
                CreateTestDataItem(12, 16, 0),

                CreateTestDataItem(0, 17, 2),
                CreateTestDataItem(11, 17, 1),
                CreateTestDataItem(12, 17, 0),

                CreateTestDataItem(0, 13, 1),
                CreateTestDataItem(11, 13, 0),

                CreateTestDataItem(0, 18, 2),
                CreateTestDataItem(11, 18, 1),
                CreateTestDataItem(13, 18, 0),

                CreateTestDataItem(0, 19, 2),
                CreateTestDataItem(11, 19, 1),
                CreateTestDataItem(13, 19, 0),

                CreateTestDataItem(0, 39, 2),
                CreateTestDataItem(11, 39, 1),
                CreateTestDataItem(13, 39, 0),

                CreateTestDataItem(0, 14, 1),
                CreateTestDataItem(11, 14, 0),

                CreateTestDataItem(0, 20, 2),
                CreateTestDataItem(11, 20, 1),
                CreateTestDataItem(14, 20, 0),

                CreateTestDataItem(0, 33, 2),
                CreateTestDataItem(11, 33, 1),
                CreateTestDataItem(14, 33, 0),

                CreateTestDataItem(0, 34, 2),
                CreateTestDataItem(11, 34, 1),
                CreateTestDataItem(14, 34, 0),

                CreateTestDataItem(0, 21, 0),

                CreateTestDataItem(0, 22, 1),
                CreateTestDataItem(21, 22, 0),

                CreateTestDataItem(0, 25, 2),
                CreateTestDataItem(21, 25, 1),
                CreateTestDataItem(22, 25, 0),

                CreateTestDataItem(0, 26, 2),
                CreateTestDataItem(21, 26, 1),
                CreateTestDataItem(22, 26, 0),

                CreateTestDataItem(0, 27, 2),
                CreateTestDataItem(21, 27, 1),
                CreateTestDataItem(22, 27, 0),

                CreateTestDataItem(0, 23, 1),
                CreateTestDataItem(21, 23, 0),

                CreateTestDataItem(0, 28, 2),
                CreateTestDataItem(21, 28, 1),
                CreateTestDataItem(23, 28, 0),

                CreateTestDataItem(0, 29, 2),
                CreateTestDataItem(21, 29, 1),
                CreateTestDataItem(23, 29, 0),

                CreateTestDataItem(0, 40, 2),
                CreateTestDataItem(21, 40, 1),
                CreateTestDataItem(23, 40, 0),

                CreateTestDataItem(0, 24, 1),
                CreateTestDataItem(21, 24, 0),

                CreateTestDataItem(0, 35, 2),
                CreateTestDataItem(21, 35, 1),
                CreateTestDataItem(24, 35, 0),

                CreateTestDataItem(0, 36, 2),
                CreateTestDataItem(21, 36, 1),
                CreateTestDataItem(24, 36, 0),

                CreateTestDataItem(0, 37, 2),
                CreateTestDataItem(21, 37, 1),
                CreateTestDataItem(24, 37, 0)
                );
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityObjectDummyTreeLink CreateTestDataItem(long parentId, long id, long level)
        {            
            return new DataEntityObjectDummyTreeLink
            {
                Id = id,
                Level = level,
                ParentId = parentId
            };
        }

        #endregion Private methods
    }
}
