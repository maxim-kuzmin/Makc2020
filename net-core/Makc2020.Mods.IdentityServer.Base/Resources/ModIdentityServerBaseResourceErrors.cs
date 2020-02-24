//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.IdentityServer.Base.Resources.Errors
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Ресурсы. Ошибки.
    /// </summary>
    public class ModIdentityServerBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<ModIdentityServerBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModIdentityServerBaseResourceErrors(IStringLocalizer<ModIdentityServerBaseResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Внешняя аутентификация не пройдена".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringExternalAuthenticationIsFailed()
        {
            return Localizer["Внешняя аутентификация не пройдена"];
        }

        /// <summary>
        /// Получить строку "URL возврата неверен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringReturnUrlIsInvalid()
        {
            return Localizer["URL возврата неверен"];
        }

        /// <summary>
        /// Получить строку "Неизвестный идентификатор пользователя".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUnknownUserId()
        {
            return Localizer["Неизвестный идентификатор пользователя"];
        }

        /// <summary>
        /// Получить строку "Введены неверные учётные данные".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserLoginIsFailed()
        {
            return Localizer["Введены неверные учётные данные"];
        }

        #endregion Public methods
    }
}