//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.LoggedOut
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Виды. После выхода из системы. Модель.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountViewLoggedOutModel
    {
        #region Properties

        /// <summary>
        /// Признак необходимости перенаправления после выхода из системы.
        /// </summary>
        public bool AutomaticRedirectAfterSignOut { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Схема внешней аутентификации.
        /// </summary>
        public string ExternalAuthenticationScheme { get; set; }

        /// <summary>
        /// Идентификатор выхода из системы.
        /// </summary>
        public string LogoutId { get; set; }

        /// <summary>
        /// URL перенаправления после выхода из системы.
        /// </summary>
        public string PostLogoutRedirectUri { get; set; }

        /// <summary>
        /// URL в тэге IFRAME, предназначенном для выхода из системы.
        /// </summary>
        public string SignOutIframeUrl { get; set; }

        /// <summary>
        /// Признак необходимости запустить внешний выход из системы.
        /// </summary>
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;

        #endregion Properties
    }
}