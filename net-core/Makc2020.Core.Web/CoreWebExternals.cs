//Author Maxim Kuzmin//makc//

using Makc2020.Core.Web.Resources.Errors;
using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Внешнее.
    /// </summary>
    public class CoreWebExternals
    {
        #region Properties

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<CoreWebResourceErrors> ResourceErrorsLocalizer { get; set; }

        #endregion Properties
    }
}
