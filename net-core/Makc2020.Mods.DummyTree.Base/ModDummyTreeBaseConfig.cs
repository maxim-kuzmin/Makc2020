//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.DummyTree.Base.Config;
using System.IO;

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Конфигурация.
    /// </summary>
    public sealed class ModDummyTreeBaseConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IModDummyTreeBaseConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModDummyTreeBaseConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModDummyTreeBaseConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.DummyTree.Base.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModDummyTreeBaseConfigProvider CreateProvider(ModDummyTreeBaseConfigSettings settings)
        {
            return new ModDummyTreeBaseConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}