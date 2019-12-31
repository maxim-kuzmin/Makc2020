//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Внешнее.
    /// </summary>
    public class HostBasePartAuthExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<HostBasePartAuthResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<HostBasePartAuthResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
