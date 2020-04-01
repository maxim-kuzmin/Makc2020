//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Mods.DummyTree.Caching.Config;
using System.IO;

namespace Makc2020.Mods.DummyTree.Caching
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Конфигурация.
    /// </summary>
    public sealed class ModDummyTreeCachingConfig
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
        public ModDummyTreeCachingConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModDummyTreeCachingConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.DummyTree.Caching.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModDummyTreeCachingConfigProvider CreateProvider(ModDummyTreeCachingConfigSettings settings)
        {
            return new ModDummyTreeCachingConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}