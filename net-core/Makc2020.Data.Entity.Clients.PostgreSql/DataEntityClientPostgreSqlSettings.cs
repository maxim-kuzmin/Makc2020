//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Base.Settings;
using System;

namespace Makc2020.Data.Entity.Clients.PostgreSql
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. Настройки.
    /// </summary>
    public sealed class DataEntityClientPostgreSqlSettings : DataBaseSettings
    {
        #region Fields

        private static readonly Lazy<DataEntityClientPostgreSqlSettings> lazy =
            new Lazy<DataEntityClientPostgreSqlSettings>(() => new DataEntityClientPostgreSqlSettings());

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

        private DataEntityClientPostgreSqlSettings()
        {
            var defaults = new DataBaseDefaults
            {
                Schema = "public"
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

            DummyTreeLink = new DataBaseSettingDummyTreeLink(defaults, "DummyTreeLink");

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
