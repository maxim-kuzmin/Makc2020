//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.IdentityServer.Web.Mvc.Config;
using System.IO;

namespace Makc2020.Mods.IdentityServer.Web.Mvc
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Конфигурация.
    /// </summary>
    public sealed class ModIdentityServerWebMvcConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IModIdentityServerWebMvcConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ModIdentityServerWebMvcConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ModIdentityServerWebMvcConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Mod.IdentityServer.Web.Mvc.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ModIdentityServerWebMvcConfigProvider CreateProvider(ModIdentityServerWebMvcConfigSettings settings)
        {
            return new ModIdentityServerWebMvcConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}