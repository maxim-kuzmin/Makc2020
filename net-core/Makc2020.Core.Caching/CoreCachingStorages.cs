//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Core.Caching.Storages;
using Microsoft.Extensions.Caching.Memory;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища.
    /// </summary>
    public class CoreCachingStorages
    {
        #region Properties

        /// <summary>
        /// Глобальное.
        /// </summary>
        public CoreCachingStorageGlobal Global { get; private set; }

        /// <summary>
        /// Локальное.
        /// </summary>
        public CoreCachingStorageLocal Local { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="memoryCache">Кэш в памяти.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="resourceErrors">Ресурс ошибок.</param>
        public CoreCachingStorages(
            IMemoryCache memoryCache,
            ICoreCachingConfigSettings configSettings,
            CoreCachingResourceErrors resourceErrors
            )
        {
            Local = new CoreCachingStorageLocal(memoryCache, configSettings);

            if (configSettings.IsGlobalStorageEnabled)
            {
                Global = new CoreCachingStorageGlobal(Local.Helper, configSettings, resourceErrors);
            }
        }

        #endregion Constructor
    }
}
