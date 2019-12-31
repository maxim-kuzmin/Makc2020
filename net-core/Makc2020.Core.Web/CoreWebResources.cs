//Author Maxim Kuzmin//makc//

using Makc2020.Core.Web.Resources.Errors;
using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Ресурсы.
    /// </summary>
    public class CoreWebResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public CoreWebResourceErrors Errors { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        public CoreWebResources(
            IStringLocalizer<CoreWebResourceErrors> resourceErrorsLocalizer
            )
        {
            Errors = new CoreWebResourceErrors(resourceErrorsLocalizer);
        }

        #endregion Constructor
    }
}
