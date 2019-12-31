//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schema
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "User".
    /// </summary>
    public class DataEntitySchemaUser : DataEntitySchema<DataEntityObjectUser>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaUser(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectUser> builder)
        {
            var setting = DataBaseSettings.User;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.FullName).IsUnicode().HasMaxLength(256);

            builder.HasIndex(x => x.NormalizedUserName)
                .IsUnique()
                .HasName(setting.DbUniqueIndexForNormalizedUserName);

            builder.HasIndex(x => x.NormalizedEmail)
                .HasName(setting.DbIndexForNormalizedEmail);
        }

        #endregion Public methods
    }
}