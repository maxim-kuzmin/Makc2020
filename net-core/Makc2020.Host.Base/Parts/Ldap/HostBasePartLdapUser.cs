//Author Maxim Kuzmin//makc//

using Novell.Directory.Ldap;

namespace Makc2020.Host.Base.Parts.Ldap
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Пользователь.
    /// </summary>
    public class HostBasePartLdapUser
    {
        #region Properties

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Ldap соединение пользователя.
        /// </summary>
        public LdapConnection LdapConnection { get; set; }

        #endregion Properties
    }
}
