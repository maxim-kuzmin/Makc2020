//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "DummyMain".
    /// </summary>
    public class DataEntitySchemaDummyMain : DataEntitySchema<DataEntityObjectDummyMain>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaDummyMain(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectDummyMain> builder)
        {
            var setting = DataBaseSettings.DummyMain;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);            

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(setting.DbMaxLengthForName)
                .HasColumnName(setting.DbColumnNameForName);

            builder.Property(x => x.ObjectDummyOneToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForObjectDummyOneToManyId);

            builder.Property(x => x.PropBoolean).IsRequired();
            builder.Property(x => x.PropBooleanNullable);
            builder.Property(x => x.PropDate).IsRequired();
            builder.Property(x => x.PropDateNullable);
            builder.Property(x => x.PropDateTimeOffset).IsRequired();
            builder.Property(x => x.PropDateTimeOffsetNullable);
            builder.Property(x => x.PropDecimal).IsRequired();
            builder.Property(x => x.PropDecimalNullable);
            builder.Property(x => x.PropInt32).IsRequired();
            builder.Property(x => x.PropInt32Nullable);
            builder.Property(x => x.PropInt64).IsRequired();
            builder.Property(x => x.PropInt64Nullable);
            builder.Property(x => x.PropString).IsRequired().IsUnicode();
            builder.Property(x => x.PropStringNullable).IsUnicode();

            builder.HasIndex(x => x.Name).IsUnique().HasName(setting.DbUniqueIndexForName);

            builder.HasOne(x => x.ObjectDummyOneToMany)
                .WithMany(x => x.ObjectsDummyMain)
                .HasForeignKey(x => x.ObjectDummyOneToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyOneToMany);
        }

        #endregion Public methods
    }
}