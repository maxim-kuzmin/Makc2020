//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(256);

            builder.HasIndex(x => x.Name).IsUnique().HasName(setting.DbUniqueIndexForName);
        }

        #endregion Public methods
    }
}
