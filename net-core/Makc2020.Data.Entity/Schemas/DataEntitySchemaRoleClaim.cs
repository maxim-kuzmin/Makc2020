﻿//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "RoleClaim".
    /// </summary>
    public class DataEntitySchemaRoleClaim : DataEntitySchema<DataEntityObjectRoleClaim>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaRoleClaim(DataBaseSettings settings)
            : base(settings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectRoleClaim> builder)
        {
            var setting = Settings.RoleClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(setting.DbColumnNameForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(setting.DbColumnNameForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.RoleId)
                .HasColumnName(setting.DbColumnNameForRoleId);

            builder.HasIndex(x => x.RoleId).IsUnique().HasDatabaseName(setting.DbUniqueIndexForRoleId);

            builder.HasOne(x => x.ObjectRole)
                .WithMany(x => x.ObjectsRoleClaim)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRole);
        }

        #endregion Public methods
    }
}