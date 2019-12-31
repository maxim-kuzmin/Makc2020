//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Resources.Errors;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Внешнее.
    /// </summary>
    public class CoreCachingExternals
    {
        #region Properties

        /// <summary>
        /// Опции кэша в памяти.
        /// </summary>
        public MemoryCacheOptions MemoryCacheOptions { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<CoreCachingResourceErrors> ResourceErrorsLocalizer { get; set; }

        #endregion Properties
    }
}
