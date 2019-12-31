//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Auth.Base.Resources.Errors
{
    /// <summary>
    /// Мод "Auth". Основа. Ресурсы. Ошибки.
    /// </summary>
    public class ModAuthBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<ModAuthBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModAuthBaseResourceErrors(IStringLocalizer<ModAuthBaseResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Введены неверные учётные данные".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserLoginIsFailed()
        {
            return Localizer["Введены неверные учётные данные"];
        }

        /// <summary>
        /// Получить строку "Не удалось обновить токен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringTokenRefreshIsFailed()
        {
            return Localizer["Не удалось обновить токен"];
        }

        /// <summary>
        /// Получить строку "Не удалось зарегистрировать пользователя".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserRegistrationIsFailed()
        {
            return Localizer["Не удалось зарегистрировать пользователя"];
        }

        #endregion Public methods
    }
}