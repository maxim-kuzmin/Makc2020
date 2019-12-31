//Author Maxim Kuzmin//makc//

namespace Makc2020.Host.Base.Parts.Auth.Config.Settings
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IHostBasePartAuthConfigSettingUser
    {
        #region Properties

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Пароль.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Имя для входа в систему.
        /// </summary>
        string UserName { get; }


        #endregion Properties
    }
}