//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Caching.Config;
using System.IO;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Конфигурация.
    /// </summary>
    public sealed class CoreCachingConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public ICoreCachingConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public CoreCachingConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = CoreCachingConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Core.Caching.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public CoreCachingConfigProvider CreateProvider(CoreCachingConfigSettings settings)
        {
            return new CoreCachingConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}