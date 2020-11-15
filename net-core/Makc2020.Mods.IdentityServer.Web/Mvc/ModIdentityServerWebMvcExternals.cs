//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account;

namespace Makc2020.Mods.IdentityServer.Web.Mvc
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Внешнее.
    /// </summary>
    public class ModIdentityServerWebMvcExternals
    {
        #region Properties

        /// <summary>
        /// Часть "Account".
        /// </summary>
        public ModIdentityServerWebMvcPartAccountExternals PartAccount { get; set; }

        #endregion Properties
    }
}
