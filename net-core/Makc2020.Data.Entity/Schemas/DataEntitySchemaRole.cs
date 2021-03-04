//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "Role".
    /// </summary>
    public class DataEntitySchemaRole : DataEntitySchema<DataEntityObjectRole>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaRole(DataBaseSettings settings)
            : base(settings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectRole> builder)
        {
            var setting = Settings.Role;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnNameForConcurrencyStamp);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnNameForName);

            builder.Property(x => x.NormalizedName)
                .HasColumnName(setting.DbColumnNameForNormalizedName);

            builder.HasIndex(x => x.NormalizedName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods
    }
}