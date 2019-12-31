//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Converting;
using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Ресурсы.
    /// </summary>
    public class CoreBaseResources
    {
        #region Properties

        /// <summary>
        /// Преобразование.
        /// </summary>
        public CoreBaseResourceConverting Converting { get; private set; }

        /// <summary>
        /// Ошибки.
        /// </summary>
        public CoreBaseResourceErrors Errors { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceConvertingLocalizer">Локализатор ресурсов преобразования.</param>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        public CoreBaseResources(
            IStringLocalizer<CoreBaseResourceConverting> resourceConvertingLocalizer,
            IStringLocalizer<CoreBaseResourceErrors> resourceErrorsLocalizer
            )
        {
            Converting = new CoreBaseResourceConverting(resourceConvertingLocalizer);
            Errors = new CoreBaseResourceErrors(resourceErrorsLocalizer);
        }

        #endregion Constructor
    }
}
