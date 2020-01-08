//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Config
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Конфигурация. Настройки.
    /// </summary>
    public class ModIdentityServerWebMvcConfigSettings : IModIdentityServerWebMvcConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Account".
        /// </summary>
        public ModIdentityServerWebMvcPartAccountConfigSettings PartAccount { get; set; }

        /// <inheritdoc/>
        IModIdentityServerWebMvcPartAccountConfigSettings IModIdentityServerWebMvcConfigSettings.PartAccount => PartAccount;

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IModIdentityServerWebMvcConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModIdentityServerWebMvcConfigSettings();

            var configProvider = new ModIdentityServerWebMvcConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}