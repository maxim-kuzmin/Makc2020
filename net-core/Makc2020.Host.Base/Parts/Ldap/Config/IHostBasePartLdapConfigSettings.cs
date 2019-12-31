//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Host.Base.Parts.Ldap.Config
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Конфигурация. Настройки.
    /// </summary>
    public interface IHostBasePartLdapConfigSettings
    {
        #region Properties

        /// <summary>
        /// Домен.
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// Хосты.
        /// </summary>
        IEnumerable<string> Hosts { get; }

        /// <summary>
        /// Признак включения SSL.
        /// </summary>
        bool IsSecureSocketLayerEnabled { get; }

        /// <summary>
        /// Порт.
        /// </summary>
        int Port { get; }

        #endregion Properties
    }
}