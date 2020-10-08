//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Base.Settings;
using System;

namespace Makc2020.Data.Entity.Clients.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Настройки.
    /// </summary>
    public sealed class DataEntityClientSqlServerSettings : DataBaseSettings
    {
        #region Fields

        private static readonly Lazy<DataEntityClientSqlServerSettings> lazy =
            new Lazy<DataEntityClientSqlServerSettings>(() => new DataEntityClientSqlServerSettings());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static DataBaseSettings Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        #endregion Properties

        #region Constructors

        private DataEntityClientSqlServerSettings()
        {
            var defaults = new DataBaseDefaults
            {
                ColumnNameForId = "Id",
                ColumnNameForName = "Name",
                ColumnNameForParentId = "ParentId",
                ColumnNameForTreeChildCount = "TreeChildCount",
                ColumnNameForTreeDescendantCount = "TreeDescendantCount",
                ColumnNameForTreeLevel = "TreeLevel",
                ColumnNameForTreePath = "TreePath",
                ColumnNameForTreePosition = "TreePosition",
                ColumnNameForTreeSort = "TreeSort",
                ColumnNamePartsSeparator = "",
                ForeignKeyPrefix = "FK",
                FullNamePartsSeparator = ".",
                IndexPrefix = "IX",
                NamePartsSeparator = "_",
                PrimaryKeyPrefix = "PK",
                Schema = "dbo",
                UniqueIndexPrefix = "UX"
            };

            DummyOneToMany = new DataBaseSettingDummyOneToMany(defaults, "DummyOneToMany");

            DummyMain = new DataBaseSettingDummyMain(DummyOneToMany, defaults, "DummyMain");

            DummyManyToMany = new DataBaseSettingDummyManyToMany(defaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new DataBaseSettingDummyMainDummyManyToMany(
                DummyMain,
                DummyManyToMany,
                defaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new DataBaseSettingDummyTree(defaults, "DummyTree");

            DummyTreeLink = new DataBaseSettingDummyTreeLink(DummyTree, defaults, "DummyTreeLink");

            Role = new DataBaseSettingRole(defaults, "Role");

            RoleClaim = new DataBaseSettingRoleClaim(Role, defaults, "RoleClaim");

            User = new DataBaseSettingUser(defaults, "User");

            UserClaim = new DataBaseSettingUserClaim(User, defaults, "UserClaim");

            UserLogin = new DataBaseSettingUserLogin(User, defaults, "UserLogin");

            UserRole = new DataBaseSettingUserRole(Role, User, defaults, "UserRole");

            UserToken = new DataBaseSettingUserToken(User, defaults, "UserToken");
        }

        #endregion Constructors     
    }
}
