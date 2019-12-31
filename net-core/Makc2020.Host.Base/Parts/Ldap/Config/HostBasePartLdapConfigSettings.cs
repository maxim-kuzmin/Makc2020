//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Host.Base.Parts.Ldap.Config
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Конфигурация. Настройки.
    /// </summary>
    public class HostBasePartLdapConfigSettings : IHostBasePartLdapConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string Domain { get; set; }

        /// <inheritdoc/>
        public IEnumerable<string> Hosts { get; set; }

        /// <inheritdoc/>
        public bool IsSecureSocketLayerEnabled { get; set; }

        /// <inheritdoc/>
        public int Port { get; set; }

        #endregion Properties
    }
}