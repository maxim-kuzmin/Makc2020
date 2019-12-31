//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Caching.Common.Client.Config;

namespace Makc2020.Mods.DummyMain.Caching.Config
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Конфигурация. Настройки.
    /// </summary>
    public class ModDummyMainCachingConfigSettings : ICoreCachingCommonClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Окончание срока действия кэша в секундах.
        /// </summary>
        public int CacheExpiryInSeconds { get; set; }

        /// <summary>
        /// Признак включения кэширования.
        /// </summary>
        public bool IsCachingEnabled { get; private set; }

        /// <summary>
        /// Префикс ключа кэша.
        /// </summary>
        public string CacheKeyPrefix { get; private set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static ICoreCachingCommonClientConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModDummyMainCachingConfigSettings();

            var configProvider = new ModDummyMainCachingConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}