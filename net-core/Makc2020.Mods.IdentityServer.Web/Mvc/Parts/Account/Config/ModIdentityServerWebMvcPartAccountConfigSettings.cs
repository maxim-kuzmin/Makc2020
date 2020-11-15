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
        public bool AllowLoginWithoutPassword { get; set; }

        /// <inheritdoc/>
        public bool AutomaticRedirectAfterSignOut { get; set; }

        /// <inheritdoc/>
        public string ClientIsFirstLoginParamName { get; set; }

        /// <inheritdoc/>
        public string ClientIsFirstLoginParamValue { get; set; }

        /// <inheritdoc/>
        public string ClientLangParamName { get; set; }

        /// <inheritdoc/>
        public int DbCommandTimeout { get; set; }

        /// <inheritdoc/>
        public bool IsWindowsAuthenticationMandatory { get; set; }

        /// <inheritdoc/>
        public string LoginMethodCookieName { get; set; }

        /// <inheritdoc/>
        public string LoginUserNameCookieName { get; set; }

        /// <inheritdoc/>
        public int RememberLoginDurationInDays { get; set; }

        /// <inheritdoc/>
        public bool ShowLogoutPrompt { get; set; }

        #endregion Properties
    }
}