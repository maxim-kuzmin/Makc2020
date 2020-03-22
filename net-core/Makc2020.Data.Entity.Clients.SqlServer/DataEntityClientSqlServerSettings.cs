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

        private static readonly Lazy<DataEntityClientSqlServerSettings> lazy = new Lazy<DataEntityClientSqlServerSettings>(() => new DataEntityClientSqlServerSettings());

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
