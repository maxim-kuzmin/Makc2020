//Author Maxim Kuzmin//makc//

using System.Security.Claims;

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Настройки.
    /// </summary>
    public class HostBasePartAuthSettings
    {
        #region Constants

        /// <summary>
        /// Утверждение "Role".
        /// </summary>
        public const string CLAIM_Role = ClaimsIdentity.DefaultRoleClaimType;

        /// <summary>
        /// Утверждение "User".
        /// Используется для хранения в токене доступа сериализованной в формате JSON
        /// информации о пользователе.        
        /// </summary>
        public const string CLAIM_User = "User";

        /// <summary>
        /// Утверждение "UserName".
        /// </summary>
        public const string CLAIM_UserName = ClaimsIdentity.DefaultNameClaimType;

        /// <summary>
        /// Роль "Administrator".
        /// </summary>
        public const string ROLE_Administrator = "admin";

        /// <summary>
        /// Поставщик входа в систему "Local".
        /// </summary>
        public const string LOGIN_PROVIDER_Local = "Local";

        /// <summary>
        /// Политика "Administrator".
        /// </summary>
        public const string POLICY_Administrator = "Admin";

        /// <summary>
        /// Отображаемое имя поставщика "Local".
        /// </summary>
        public const string PROVIDER_DISPLAY_NAME_Local = "Local";

        /// <summary>
        /// Группа Windows "SiteAdministrator".
        /// </summary>
        public const string WINDOWS_GROUP_SiteAdministrator = "SiteAdministrator";

        #endregion Constants
    }
}
