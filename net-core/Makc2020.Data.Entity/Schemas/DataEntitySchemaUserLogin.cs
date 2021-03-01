//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "UserLogin".
    /// </summary>
    public class DataEntitySchemaUserLogin : DataEntitySchema<DataEntityObjectUserLogin>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaUserLogin(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectUserLogin> builder)
        {
            var setting = Settings.UserLogin;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey })
                .HasName(setting.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(setting.DbColumnNameForLoginProvider);

            builder.Property(x => x.ProviderDisplayName)
                .HasColumnName(setting.DbColumnNameForProviderDisplayName);

            builder.Property(x => x.ProviderKey)
                .HasColumnName(setting.DbColumnNameForProviderKey);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnNameForUserId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(setting.DbIndexForUserId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserLogin)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);
        }

        #endregion Public methods
    }
}