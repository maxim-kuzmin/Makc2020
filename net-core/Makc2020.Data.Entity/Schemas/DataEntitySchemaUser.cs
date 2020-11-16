//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
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

            builder.Property(x => x.AccessFailedCount)
                .HasColumnName(setting.DbColumnNameForAccessFailedCount);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnNameForConcurrencyStamp);

            builder.Property(x => x.Email)
                .HasColumnName(setting.DbColumnNameForEmail);

            builder.Property(x => x.EmailConfirmed)
                .HasColumnName(setting.DbColumnNameForEmailConfirmed);

            builder.Property(x => x.FullName)
                .IsUnicode()
                .HasMaxLength(256)
                .HasColumnName(setting.DbColumnNameForFullName);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.LockoutEnabled)
                .HasColumnName(setting.DbColumnNameForLockoutEnabled);

            builder.Property(x => x.LockoutEnd)
                .HasColumnName(setting.DbColumnNameForLockoutEnd);

            builder.Property(x => x.NormalizedEmail)
                .HasColumnName(setting.DbColumnNameForNormalizedEmail);

            builder.Property(x => x.NormalizedUserName)
                .HasColumnName(setting.DbColumnNameForNormalizedUserName);

            builder.Property(x => x.PasswordHash)
                .HasColumnName(setting.DbColumnNameForPasswordHash);

            builder.Property(x => x.PhoneNumber)
                .HasColumnName(setting.DbColumnNameForPhoneNumber);

            builder.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName(setting.DbColumnNameForPhoneNumberConfirmed);

            builder.Property(x => x.SecurityStamp)
                .HasColumnName(setting.DbColumnNameForSecurityStamp);

            builder.Property(x => x.TwoFactorEnabled)
                .HasColumnName(setting.DbColumnNameForTwoFactorEnabled);

            builder.Property(x => x.UserName)
                .HasColumnName(setting.DbColumnNameForUserName);

            builder.HasIndex(x => x.NormalizedUserName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedUserName);
            builder.HasIndex(x => x.NormalizedEmail).HasDatabaseName(setting.DbIndexForNormalizedEmail);
        }

        #endregion Public methods
    }
}