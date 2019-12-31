//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Config;
using Makc2020.Core.Caching.Storages.Local;
using Microsoft.Extensions.Caching.Memory;

namespace Makc2020.Core.Caching.Storages
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища. Локальное
    /// </summary>
    public class CoreCachingStorageLocal
    {
        #region Properties

        /// <summary>
        /// Помощник.
        /// </summary>
        public CoreCachingStorageLocalHelper Helper { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public CoreCachingStorageLocalService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="memoryCache">Кэш в памяти.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public CoreCachingStorageLocal(IMemoryCache memoryCache, ICoreCachingConfigSettings configSettings)
        {
            Helper = new CoreCachingStorageLocalHelper(configSettings);
            Service = new CoreCachingStorageLocalService(Helper, memoryCache);
        }

        #endregion Constructor
    }
}
