//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.DummyMain.Base.Config;
using System.IO;

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Конфигурация.
    /// </summary>
    public sealed class ModDummyMainBaseConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IModDummyMainBaseConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModDummyMainBaseConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModDummyMainBaseConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.DummyMain.Base.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModDummyMainBaseConfigProvider CreateProvider(ModDummyMainBaseConfigSettings settings)
        {
            return new ModDummyMainBaseConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}