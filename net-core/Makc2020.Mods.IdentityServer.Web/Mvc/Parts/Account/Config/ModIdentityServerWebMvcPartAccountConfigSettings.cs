//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Конфигурация. Настройки.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountConfigSettings : IModIdentityServerWebMvcPartAccountConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public bool AllowLocalLogin { get; set;  }

        /// <inheritdoc/>
        public bool AllowRememberLogin { get; set; }

        /// <inheritdoc/>
        public int RememberLoginDurationInDays { get; set; }

        /// <inheritdoc/>
        public bool ShowLogoutPrompt { get; set; }

        /// <inheritdoc/>
        public bool AutomaticRedirectAfterSignOut { get; set; }

        /// <inheritdoc/>
        public string WindowsAuthenticationSchemeName { get; set; }

        /// <inheritdoc/>
        public bool IncludeWindowsGroups { get; set; }

        #endregion Properties
    }
}