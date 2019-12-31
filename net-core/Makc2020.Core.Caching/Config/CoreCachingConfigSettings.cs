//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;

namespace Makc2020.Core.Caching.Config
{
    /// <summary>
    /// Ядро. Кэширование. Конфигурация. Настройки.
    /// </summary>
    public class CoreCachingConfigSettings : ICoreCachingConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public int ConnectTimeout { get; set; }

        /// <inheritdoc/>
        public int DbIndex { get; set; }

        /// <inheritdoc/>
        public int CacheExpiryInSeconds { get; set; }

        /// <inheritdoc/>
        public string Host { get; set; }

        /// <inheritdoc/>
        public string Hosts { get; set; }

        /// <inheritdoc/>
        public bool IsCachingEnabled { get; set; }

        /// <inheritdoc/>
        public bool IsGlobalStorageEnabled { get; set; }

        /// <inheritdoc/>
        public string CacheKeyPrefix { get; set; }

        /// <inheritdoc/>
        public string Password { get; set; }

        /// <inheritdoc/>
        public int Port { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Абсолютный путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static ICoreCachingConfigSettings Create(
            string configFilePath,
            CoreBaseEnvironment environment
            )
        {
            var result = new CoreCachingConfigSettings();

            var configProvider = new CoreCachingConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}