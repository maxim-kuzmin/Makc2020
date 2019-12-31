//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Mods.DummyMain.Caching.Config;
using System.IO;

namespace Makc2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Конфигурация.
    /// </summary>
    public sealed class ModDummyMainCachingConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public ICoreCachingCommonClientConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModDummyMainCachingConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModDummyMainCachingConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.DummyMain.Caching.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModDummyMainCachingConfigProvider CreateProvider(ModDummyMainCachingConfigSettings settings)
        {
            return new ModDummyMainCachingConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}