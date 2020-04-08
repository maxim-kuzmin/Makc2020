//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(x => x.Id).IsRequired().HasColumnName(setting.DbColumnNameForId);
            builder.Property(x => x.ParentId).IsRequired().HasColumnName(setting.DbColumnNameForParentId);
        }

        #endregion Public methods
    }
}
