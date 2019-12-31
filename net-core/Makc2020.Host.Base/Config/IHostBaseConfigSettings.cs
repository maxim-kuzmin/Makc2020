//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth.Config;
using Makc2020.Host.Base.Parts.Ldap.Config;

namespace Makc2020.Host.Base.Config
{
    /// <summary>
    /// Хост. Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IHostBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Auth".
        /// </summary>
        IHostBasePartAuthConfigSettings PartAuth { get; }

        /// <summary>
        /// Часть "LDAP".
        /// </summary>
        IHostBasePartLdapConfigSettings PartLdap { get; }

        #endregion Properties
    }
}