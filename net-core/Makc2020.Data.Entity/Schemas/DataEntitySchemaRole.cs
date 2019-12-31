//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "Role".
    /// </summary>
    public class DataEntitySchemaRole : DataEntitySchema<DataEntityObjectRole>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaRole(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectRole> builder)
        {
            var setting = DataBaseSettings.Role;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);            

            builder.HasIndex(x => x.NormalizedName)
                .IsUnique()
                .HasName(setting.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods
    }
}