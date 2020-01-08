//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Внешний поставщик.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountExternalProvider
    {
        #region Properties

        /// <summary>
        /// Отображаемое имя.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Схема аутентификации.
        /// </summary>
        public string AuthenticationScheme { get; set; }

        #endregion Properties
    }
}