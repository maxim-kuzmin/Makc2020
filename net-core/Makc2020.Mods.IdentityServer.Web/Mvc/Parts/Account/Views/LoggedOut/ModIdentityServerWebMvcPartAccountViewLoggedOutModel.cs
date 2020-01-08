//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.LoggedOut
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Виды. После выхода из системы. Модель.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountViewLoggedOutModel
    {
        #region Properties

        public bool AutomaticRedirectAfterSignOut { get; set; }

        public string ClientName { get; set; }

        public string ExternalAuthenticationScheme { get; set; }

        public string LogoutId { get; set; }

        public string PostLogoutRedirectUri { get; set; }
        
        public string SignOutIframeUrl { get; set; }
               
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
        
        #endregion Properties
    }
}