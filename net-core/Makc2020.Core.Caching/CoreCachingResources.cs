//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Resources.Errors;
using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Ресурсы.
    /// </summary>
    public class CoreCachingResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public CoreCachingResourceErrors Errors { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов успехов.</param>
        public CoreCachingResources(
            IStringLocalizer<CoreCachingResourceErrors> resourceErrorsLocalizer
            )
        {
            Errors = new CoreCachingResourceErrors(resourceErrorsLocalizer);
        }

        #endregion Constructor
    }
}
