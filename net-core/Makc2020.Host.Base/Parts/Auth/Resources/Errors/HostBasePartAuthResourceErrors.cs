//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base.Parts.Auth.Resources.Errors
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Ресурсы. Ошибки.
    /// </summary>
    public class HostBasePartAuthResourceErrors
    {
        #region Properties

        private IStringLocalizer<HostBasePartAuthResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public HostBasePartAuthResourceErrors(IStringLocalizer<HostBasePartAuthResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Не удалось создать пользователя".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFailedToCreateUser()
        {
            return Localizer["Не удалось создать пользователя"];
        }

        /// <summary>
        /// Получить строку "Не удалось получить текущего пользователя".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFailedToGetCurrentUser()
        {
            return Localizer["Не удалось получить текущего пользователя"];
        }

        /// <summary>
        /// Получить строку "Не удалось добавить в базу данных пользователей из конфигурационных настроек".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserSeedIsFailed()
        {
            return Localizer["Не удалось добавить в базу данных пользователей из конфигурационных настроек"];
        }

        #endregion Public methods
    }
}