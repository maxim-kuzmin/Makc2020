//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
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
                .HasColumnName(setting.DbColumnNameForObjectDummyMainId);

            builder.Property(x => x.ObjectDummyManyToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForObjectDummyManyToManyId);

            builder.HasIndex(x => x.ObjectDummyManyToManyId).HasDatabaseName(setting.DbIndexForObjectDummyManyToManyId);

            builder.HasOne(x => x.ObjectDummyMain)
                .WithMany(x => x.ObjectsDummyMainDummyManyToMany)
                .HasForeignKey(x => x.ObjectDummyMainId)
                .HasConstraintName(setting.DbForeignKeyToDummyMain);

            builder.HasOne(x => x.ObjectDummyManyToMany)
                .WithMany(x => x.ObjectsDummyMainDummyManyToMany)
                .HasForeignKey(x => x.ObjectDummyManyToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyManyToMany);
        }

        #endregion Public methods
    }
}