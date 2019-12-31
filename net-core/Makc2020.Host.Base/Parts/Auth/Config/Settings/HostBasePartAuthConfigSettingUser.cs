//Author Maxim Kuzmin//makc//

namespace Makc2020.Host.Base.Parts.Auth.Config.Settings
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Конфигурация. Настройки. Пользователь.
    /// </summary>
    public class HostBasePartAuthConfigSettingUser : IHostBasePartAuthConfigSettingUser
    {
        #region Properties

        /// <inheritdoc/>
        public string Email { get; set; }

        /// <inheritdoc/>
        public string FullName { get; set; }

        /// <inheritdoc/>
        public string Password { get; set; }

        /// <inheritdoc/>
        public string UserName { get; set; }

        #endregion Properties
    }
}