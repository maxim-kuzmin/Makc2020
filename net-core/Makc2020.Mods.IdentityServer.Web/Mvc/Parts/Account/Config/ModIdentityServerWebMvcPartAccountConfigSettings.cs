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
        public bool AllowLocalLogin { get; set; }

        /// <inheritdoc/>
        public bool AllowLoginWithoutPassword { get; set; }

        /// <inheritdoc/>
        public bool AllowRememberLogin { get; set; }

        /// <inheritdoc/>
        public bool AutomaticRedirectAfterSignOut { get; set; }

        /// <inheritdoc/>
        public string ClientIsFirstLoginParamName { get; }

        /// <inheritdoc/>
        public string ClientIsFirstLoginParamValue { get; }

        /// <inheritdoc/>
        public string ClientLangParamName { get; }

        /// <inheritdoc/>
        public bool IncludeWindowsGroups { get; set; }

        /// <inheritdoc/>
        public string LogOutRoute { get; set; }

        /// <inheritdoc/>
        public int RememberLoginDurationInDays { get; set; }

        /// <inheritdoc/>
        public bool ShowLogoutPrompt { get; set; }

        /// <inheritdoc/>
        public string UserSessionCountRoute { get; set; }

        /// <inheritdoc/>
        public string WebApiUrlAddress { get; set; }

        #endregion Properties
    }
}