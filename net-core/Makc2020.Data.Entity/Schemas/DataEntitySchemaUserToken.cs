//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "UserToken".
    /// </summary>
    public class DataEntitySchemaUserToken : DataEntitySchema<DataEntityObjectUserToken>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaUserToken(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectUserToken> builder)
        {
            var setting = Settings.UserToken;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(setting.DbColumnNameForLoginProvider);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnNameForName);

            builder.Property(x => x.Value)
                .HasColumnName(setting.DbColumnNameForValue);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnNameForUserId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserToken)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);
        }

        #endregion Public methods
    }
}