//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Base.Config.Settings
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Настройки. Ресурс API. Интерфейс.
    /// </summary>
    public interface IModIdentityServerBaseConfigSettingApiResource
    {
        #region Properties

        /// <summary>
        /// Имя для отображения.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        string Name { get; }


        #endregion Properties
    }
}