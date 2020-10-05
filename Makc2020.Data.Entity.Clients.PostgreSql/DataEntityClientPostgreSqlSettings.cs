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

        private static readonly Lazy<DataEntityClientPostgreSqlSettings> lazy = new Lazy<DataEntityClientPostgreSqlSettings>(() => new DataEntityClientPostgreSqlSettings());

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
            DummyMain = new DataBaseSettingDummyMain();
            DummyMainDummyManyToMany = new DataBaseSettingDummyMainDummyManyToMany();
            DummyManyToMany = new DataBaseSettingDummyManyToMany();
            DummyOneToMany = new DataBaseSettingDummyOneToMany();
            DummyTree = new DataBaseSettingDummyTree();
            DummyTreeLink = new DataBaseSettingDummyTreeLink();
            Role = new DataBaseSettingRole();
            RoleClaim = new DataBaseSettingRoleClaim();
            User = new DataBaseSettingUser();
            UserClaim = new DataBaseSettingUserClaim();
            UserLogin = new DataBaseSettingUserLogin();
            UserRole = new DataBaseSettingUserRole();
            UserToken = new DataBaseSettingUserToken();
        }

        #endregion Constructors     
    }
}
