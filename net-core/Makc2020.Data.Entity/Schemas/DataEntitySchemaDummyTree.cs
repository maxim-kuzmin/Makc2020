//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schema
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
            builder.Property(x => x.ParentId);
            builder.Property(x => x.ChildCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.DescendantCount).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.ObjectDummyMainId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyMainId);

            builder.HasOne(x => x.ObjectDummyMain)
                .WithMany(x => x.ObjectsDummyTree)
                .HasForeignKey(x => x.ObjectDummyMainId)
                .HasConstraintName(setting.DbForeignKeyToDummyMain);

            builder.HasOne(x => x.ObjectDummyTreeParent)
                .WithMany(x => x.ObjectsDummyTreeChild)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName(setting.DbForeignKeyToParentDummyTree);

            builder.HasIndex(x => new { x.Id, x.ParentId })
                .IsUnique()
                .HasName(setting.DbUniqueIndexForIdAndParentId);

            builder.HasIndex(x => x.ObjectDummyMainId)
                .HasName(setting.DbIndexForDummyMainId);
        }

        #endregion Public methods
    }
}
