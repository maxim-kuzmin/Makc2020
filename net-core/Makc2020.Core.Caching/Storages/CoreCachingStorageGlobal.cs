//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Core.Caching.Storages.Global;
using Makc2020.Core.Caching.Storages.Local;

namespace Makc2020.Core.Caching.Storages
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища. Глобальное
    /// </summary>
    public class CoreCachingStorageGlobal
    {
        #region Properties

        /// <summary>
        /// Помощник.
        /// </summary>
        public CoreCachingStorageGlobalHelper Helper { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public CoreCachingStorageGlobalService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localStorageHelper">Помощник локального хранилища.</param>        
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="resourceErrors">Ресурс ошибок.</param>
        public CoreCachingStorageGlobal(
            CoreCachingStorageLocalHelper localStorageHelper,
            ICoreCachingConfigSettings configSettings,
            CoreCachingResourceErrors resourceErrors
            )
        {
            Helper = new CoreCachingStorageGlobalHelper(localStorageHelper, configSettings, resourceErrors);
            Service = new CoreCachingStorageGlobalService(Helper);
        }

        #endregion Constructor
    }
}
