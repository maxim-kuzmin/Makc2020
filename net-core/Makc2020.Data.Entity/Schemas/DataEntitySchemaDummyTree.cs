//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "DummyTree".
    /// </summary>
    public class DataEntitySchemaDummyTree : DataEntitySchema<DataEntityObjectDummyTree>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaDummyTree(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectDummyTree> builder)
        {
            var setting = DataBaseSettings.DummyTree;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.ChildCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.DescendantCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(256);
            builder.Property(x => x.ParentId);

            builder.Ignore(x => x.Level);

            builder.HasIndex(x => new { x.Id, x.ParentId }).IsUnique().HasName(setting.DbUniqueIndexForIdAndParentId);

            builder.HasIndex(x => new { x.ParentId, x.Name })
                .IsUnique()
                .HasName(setting.DbUniqueIndexForParentIdAndName);

            builder.HasOne(x => x.ObjectDummyTreeParent)
                .WithMany(x => x.ObjectsDummyTreeChild)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName(setting.DbForeignKeyToParentDummyTree);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectDummyTree>().HasData(
                CreateTestDataItem(1),
                CreateTestDataItem(1, 2),
                CreateTestDataItem(1, 2, 5),
                CreateTestDataItem(1, 2, 6),
                CreateTestDataItem(1, 2, 7),
                CreateTestDataItem(1, 3),
                CreateTestDataItem(1, 3, 8),
                CreateTestDataItem(1, 3, 9),
                CreateTestDataItem(1, 3, 38),
                CreateTestDataItem(1, 4),
                CreateTestDataItem(1, 4, 10),
                CreateTestDataItem(1, 4, 31),
                CreateTestDataItem(1, 4, 32),
                CreateTestDataItem(11),
                CreateTestDataItem(11, 12),
                CreateTestDataItem(11, 12, 15),
                CreateTestDataItem(11, 12, 16),
                CreateTestDataItem(11, 12, 17),
                CreateTestDataItem(11, 13),
                CreateTestDataItem(11, 13, 18),
                CreateTestDataItem(11, 13, 19),
                CreateTestDataItem(11, 13, 39),
                CreateTestDataItem(11, 14),
                CreateTestDataItem(11, 14, 20),
                CreateTestDataItem(11, 14, 33),
                CreateTestDataItem(11, 14, 34),
                CreateTestDataItem(21),
                CreateTestDataItem(21, 22),
                CreateTestDataItem(21, 22, 25),
                CreateTestDataItem(21, 22, 26),
                CreateTestDataItem(21, 22, 27),
                CreateTestDataItem(21, 23),
                CreateTestDataItem(21, 23, 28),
                CreateTestDataItem(21, 23, 29),
                CreateTestDataItem(21, 23, 40),
                CreateTestDataItem(21, 24),
                CreateTestDataItem(21, 24, 35),
                CreateTestDataItem(21, 24, 36),
                CreateTestDataItem(21, 24, 37)
                );
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityObjectDummyTree CreateTestDataItem(params long[] path)
        {
            long id = path.Last();

            long? parentId = null;

            if (path.Length > 1)
            {
                parentId = path[path.Length - 2];
            }

            long childCount = 0;

            if (path.Length < 3)
            {
                childCount = 3;
            }

            long descendantCount = 0;

            if (path.Length == 1)
            {
                descendantCount = 12;
            }
            else if (path.Length == 2)
            {
                descendantCount = 3;
            }

            return new DataEntityObjectDummyTree
            {
                ChildCount = childCount,
                DescendantCount = descendantCount,
                Id = id,
                Name = $"Name-{string.Join("-", path)}",
                ParentId = parentId
            };
        }

        #endregion Private methods
    }
}
