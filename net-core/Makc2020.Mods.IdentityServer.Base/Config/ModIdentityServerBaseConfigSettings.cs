//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Mods.IdentityServer.Base.Config.Enums;
using Makc2020.Mods.IdentityServer.Base.Config.Settings;

namespace Makc2020.Mods.IdentityServer.Base.Config
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModIdentityServerBaseConfigSettings : IModIdentityServerBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Список API.
        /// </summary>
        public ModIdentityServerBaseConfigSettingApiResource[] ApiResources { get; set; }

        /// <inheritdoc/>
        IModIdentityServerBaseConfigSettingApiResource[] IModIdentityServerBaseConfigSettings.ApiResources => ApiResources;

        /// <summary>
        /// Клиенты.
        /// </summary>
        public ModIdentityServerBaseConfigSettingClient[] Clients { get; set; }

        /// <inheritdoc/>
        IModIdentityServerBaseConfigSettingClient[] IModIdentityServerBaseConfigSettings.Clients => Clients;

        /// <summary>
        /// Ресурсы идентичности.
        /// </summary>
        public ModIdentityServerBaseConfigEnumIdentityResources[] IdentityResources { get; set; }

        /// <inheritdoc/>
        ModIdentityServerBaseConfigEnumIdentityResources[] IModIdentityServerBaseConfigSettings.IdentityResources => IdentityResources;

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IModIdentityServerBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModIdentityServerBaseConfigSettings();

            var configProvider = new ModIdentityServerBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}