//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth.Config.Settings;

namespace Makc2020.Host.Base.Parts.Auth.Config
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Конфигурация. Настройки.
    /// </summary>
    public interface IHostBasePartAuthConfigSettings
    {
        #region Properties

        /// <summary>
        /// Группы.
        /// </summary>
        IHostBasePartAuthConfigSettingGroups Groups { get; }

        /// <summary>
        /// Пользователи.
        /// </summary>
        IHostBasePartAuthConfigSettingUser[] Users { get; }

        #endregion Properties
    }
}