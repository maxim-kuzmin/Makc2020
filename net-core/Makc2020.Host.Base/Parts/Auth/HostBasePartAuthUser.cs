//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth.Value.Objects;
using System.Collections.Generic;

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Пользователь.
    /// </summary>
    public class HostBasePartAuthUser
    {
        #region Properties

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Роли.
        /// </summary>
        public IEnumerable<HostBasePartAuthValueObjectRole> Roles { get; set; }

        /// <summary>
        /// Идентификатор сессии.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Идентификаторы пользователей.
        /// </summary>
        public IEnumerable<long> UserIds { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        #endregion Properties
    }
}
