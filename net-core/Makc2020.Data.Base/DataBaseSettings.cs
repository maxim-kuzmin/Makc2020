//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Settings;
using System;

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Настройки.
    /// </summary>
    public sealed class DataBaseSettings
    {
        #region Fields

        private static readonly Lazy<DataBaseSettings> lazy = new Lazy<DataBaseSettings>(() => new DataBaseSettings());

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

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DataBaseSettingDummyMain DummyMain { get; private set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DataBaseSettingDummyMainDummyManyToMany DummyMainDummyManyToMany { get; private set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DataBaseSettingDummyManyToMany DummyManyToMany { get; private set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DataBaseSettingDummyOneToMany DummyOneToMany { get; private set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DataBaseSettingDummyTree DummyTree { get; private set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public DataBaseSettingRole Role { get; private set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public DataBaseSettingRoleClaim RoleClaim { get; private set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public DataBaseSettingUser User { get; private set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public DataBaseSettingUserClaim UserClaim { get; private set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public DataBaseSettingUserLogin UserLogin { get; private set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public DataBaseSettingUserRole UserRole { get; private set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public DataBaseSettingUserToken UserToken { get; private set; }

        #endregion Properties

        #region Constructors

        private DataBaseSettings()
        {
            DummyMain = new DataBaseSettingDummyMain();
            DummyMainDummyManyToMany = new DataBaseSettingDummyMainDummyManyToMany();
            DummyManyToMany = new DataBaseSettingDummyManyToMany();
            DummyOneToMany = new DataBaseSettingDummyOneToMany();
            DummyTree = new DataBaseSettingDummyTree();
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
