//Author Maxim Kuzmin//makc//

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
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Роли.
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        #endregion Properties
    }
}
