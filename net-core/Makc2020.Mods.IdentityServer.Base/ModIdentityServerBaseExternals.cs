//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Внешнее.
    /// </summary>
    public class ModIdentityServerBaseExternals
    {
        #region Properties

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModIdentityServerBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModIdentityServerBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
