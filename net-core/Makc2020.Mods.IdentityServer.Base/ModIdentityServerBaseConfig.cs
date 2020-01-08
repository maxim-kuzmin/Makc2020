//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.IdentityServer.Base.Config;
using System.IO;

namespace Makc2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация.
    /// </summary>
    public sealed class ModIdentityServerBaseConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IModIdentityServerBaseConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModIdentityServerBaseConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModIdentityServerBaseConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.IdentityServer.Base.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModIdentityServerBaseConfigProvider CreateProvider(ModIdentityServerBaseConfigSettings settings)
        {
            return new ModIdentityServerBaseConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}