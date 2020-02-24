//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Errors;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Внешнее.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        public ModIdentityServerBaseResourceErrors ResourceErrors { get; set; }

        #endregion Properties
    }
}
