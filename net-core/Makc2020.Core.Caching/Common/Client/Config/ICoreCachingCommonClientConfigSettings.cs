//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Caching.Common.Client.Config
{
    /// <summary>
    /// Ядро. Кэширование. Общее. Клиент. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface ICoreCachingCommonClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Окончание срока действия кэша в секундах.
        /// </summary>
        int CacheExpiryInSeconds { get; }

        /// <summary>
        /// Признак включения кэширования.
        /// </summary>
        bool IsCachingEnabled { get; }

        /// <summary>
        /// Префикс ключа кэша.
        /// </summary>
        string CacheKeyPrefix { get; }

        #endregion Properties
    }
}
