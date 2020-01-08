//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Base.Config.Settings
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Настройки. Ресурс API.
    /// </summary>
    public class ModIdentityServerBaseConfigSettingApiResource : IModIdentityServerBaseConfigSettingApiResource
    {
        #region Properties

        /// <inheritdoc/>
        public string DisplayName { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        #endregion Properties
    }
}