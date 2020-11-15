//Author Maxim Kuzmin//makc//

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Настройки.
    /// </summary>
    public class HostBasePartAuthSettings
    {
        #region Constants

        /// <summary>
        /// Иденетификатор сессии.
        /// </summary>
        public const string CLAIM_SessionId = "SessionId";

        /// <summary>
        /// Утверждение "User".
        /// Используется для хранения в токене доступа сериализованной в формате JSON
        /// информации о пользователе.        
        /// </summary>
        public const string CLAIM_User = "User";

        /// <summary>
        /// Иденетификаторы пользователей.
        /// </summary>
        public const string CLAIM_UserIds = "UserIds";

        /// <summary>
        /// Утверждение "UserName".
        /// </summary>
        public const string CLAIM_UserName = "UserName";

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

        #endregion Constants
    }
}
