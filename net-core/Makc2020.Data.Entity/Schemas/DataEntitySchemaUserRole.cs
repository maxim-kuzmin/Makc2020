//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "UserRole".
    /// </summary>
    public class DataEntitySchemaUserRole : DataEntitySchema<DataEntityObjectUserRole>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaUserRole(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectUserRole> builder)
        {
            var setting = DataBaseSettings.UserRole;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.UserId).IsRequired().HasColumnName(setting.DbColumnNameForUserId);
            builder.Property(x => x.RoleId).IsRequired().HasColumnName(setting.DbColumnNameForRoleId);

            builder.HasIndex(x => x.RoleId).HasName(setting.DbIndexForRoleId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserRole)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);

            builder.HasOne(x => x.ObjectRole)
                .WithMany(x => x.ObjectsUserRole)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRole);            
        }

        #endregion Public methods
    }
}