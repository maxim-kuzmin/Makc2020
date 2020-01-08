//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Config.Enums;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Base.Config.Settings
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Настройки. Клиент.
    /// </summary>
    public class ModIdentityServerBaseConfigSettingClient : IModIdentityServerBaseConfigSettingClient
    {
        #region Properties

        /// <inheritdoc/>
        public ICollection<string> AllowedCorsOrigins { get; set; }

        /// <inheritdoc/>
        public ModIdentityServerBaseConfigEnumGrantTypes AllowedGrantTypes { get; set; }

        /// <inheritdoc/>
        public bool AllowOfflineAccess { get; set; }

        /// <inheritdoc/>
        public ICollection<string> AllowedScopes { get; set; }

        /// <inheritdoc/>
        public string ClientId { get; set; }

        /// <inheritdoc/>
        public string ClientName { get; set; }

        /// <inheritdoc/>
        public string ClientUri { get; set; }

        /// <inheritdoc/>
        public bool RequireClientSecret { get; set; }

        /// <inheritdoc/>
        public bool RequireConsent { get; set; }

        /// <inheritdoc/>
        public bool RequirePkce { get; set; }

        /// <inheritdoc/>
        public ICollection<string> RedirectUris { get; set; }

        /// <inheritdoc/>
        public ICollection<string> PostLogoutRedirectUris { get; set; }

        #endregion Properties
    }
}