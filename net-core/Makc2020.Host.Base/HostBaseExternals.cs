//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Ldap;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Внешнее.
    /// </summary>
    public class HostBaseExternals
    {
        #region Properties

        /// <summary>
        /// Часть "Auth".
        /// </summary>
        public HostBasePartAuthExternals PartAuth { get; set; }

        /// <summary>
        /// Часть "LDAP".
        /// </summary>
        public HostBasePartLdapExternals PartLdap { get; set; }

        #endregion Properties
    }
}
