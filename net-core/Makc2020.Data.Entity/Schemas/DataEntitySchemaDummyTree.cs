//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(setting.DbMaxLengthForName)
                .HasColumnName(setting.DbColumnNameForName);

            builder.Property(x => x.ParentId)                
                .HasColumnName(setting.DbColumnNameForParentId);

            builder.Property(x => x.TreeChildCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreeChildCount);
            
            builder.Property(x => x.TreeDescendantCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreeDescendantCount);

            builder.Property(x => x.TreeLevel)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreeLevel);

            builder.Property(x => x.TreePath)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(setting.DbMaxLengthForTreePath)
                .HasDefaultValue(string.Empty)
                .HasColumnName(setting.DbColumnNameForTreePath);

            builder.Property(x => x.TreePosition)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreePosition);

            builder.Property(x => x.TreeSort)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(setting.DbMaxLengthForTreeSort)
                .HasDefaultValue(string.Empty)
                .HasColumnName(setting.DbColumnNameForTreeSort);

            builder.HasIndex(x => x.Name).HasName(setting.DbIndexForName);
            builder.HasIndex(x => x.TreeSort).HasName(setting.DbIndexForTreeSort);

            builder.HasOne(x => x.ObjectDummyTreeParent)
                .WithMany(x => x.ObjectsDummyTreeChild)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName(setting.DbForeignKeyToParentDummyTree);
        }

        #endregion Public methods
    }
}
