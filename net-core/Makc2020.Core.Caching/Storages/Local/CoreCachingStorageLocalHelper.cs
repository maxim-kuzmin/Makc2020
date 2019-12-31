//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Config;

namespace Makc2020.Core.Caching.Storages.Local
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища. Локальное. Помощник.
    /// </summary>
    public sealed class CoreCachingStorageLocalHelper
    {
        #region Properties

        /// <summary>
        /// Префикс ключа кэша.
        /// </summary>
        public string CacheKeyPrefix { get; set; }

        /// <summary>
        /// Признак неисправности.
        /// </summary>
        public bool IsFaulty { get; set; }

        /// <summary>
        /// Окончание срока действия кэша в секундах.
        /// </summary>
        public int ExpiryInSeconds { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор помощника для локального хранилища.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public CoreCachingStorageLocalHelper(ICoreCachingConfigSettings configSettings)
        {
            CacheKeyPrefix = configSettings.CacheKeyPrefix;
            ExpiryInSeconds = configSettings.CacheExpiryInSeconds;   
        }

        #endregion Constructors

        #region Рublic methods

        /// <summary>
        /// Преобразовать ключ к ключу данных.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Ключ данных.</returns>
        public string ConvertToDataKey(string key)
        {
            return string.Concat(CacheKeyPrefix, ".Data.", key);
        }

        #endregion Рublic methods
    }
}