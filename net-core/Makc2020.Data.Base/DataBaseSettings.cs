//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Settings;

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Настройки.
    /// </summary>
    public abstract class DataBaseSettings
    {
        #region Properties

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DataBaseSettingDummyMain DummyMain { get; protected set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DataBaseSettingDummyMainDummyManyToMany DummyMainDummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DataBaseSettingDummyManyToMany DummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DataBaseSettingDummyOneToMany DummyOneToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DataBaseSettingDummyTree DummyTree { get; protected set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DataBaseSettingDummyTreeLink DummyTreeLink { get; protected set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public DataBaseSettingRole Role { get; protected set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public DataBaseSettingRoleClaim RoleClaim { get; protected set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public DataBaseSettingUser User { get; protected set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public DataBaseSettingUserClaim UserClaim { get; protected set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public DataBaseSettingUserLogin UserLogin { get; protected set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public DataBaseSettingUserRole UserRole { get; protected set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public DataBaseSettingUserToken UserToken { get; protected set; }

        #endregion Properties
    }
}
