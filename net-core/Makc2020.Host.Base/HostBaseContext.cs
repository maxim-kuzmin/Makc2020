//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Ldap;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Контекст.
    /// </summary>
    public class HostBaseContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public HostBaseConfig Config { get; private set; }

        /// <summary>
        /// Часть "Auth".
        /// </summary>
        public HostBasePartAuthContext PartAuth { get; private set; }

        /// <summary>
        /// Часть "LDAP".
        /// </summary>
        public HostBasePartLdapContext PartLdap { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="сonfig">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public HostBaseContext(HostBaseConfig сonfig, HostBaseExternals externals)
        {
            Config = сonfig;

            PartAuth = new HostBasePartAuthContext(сonfig.Settings.PartAuth, externals.PartAuth);
            PartLdap = new HostBasePartLdapContext(сonfig.Settings.PartLdap, externals.PartLdap);
        }

        #endregion Constructor
    }
}
