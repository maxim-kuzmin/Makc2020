//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Auth.Base.Resources.Successes
{
    /// <summary>
    /// Мод "Auth". Основа. Ресурсы. Успехи.
    /// </summary>
    public class ModAuthBaseResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<ModAuthBaseResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModAuthBaseResourceSuccesses(IStringLocalizer<ModAuthBaseResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Пользователь зарегистрирован".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserIsRegistered()
        {
            return Localizer["Пользователь зарегистрирован"];
        }

        /// <summary>
        /// Получить строку форматирования "Вход выполнен успешно".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginIsSuccessful()
        {
            return Localizer["Вход выполнен успешно"];
        }

        /// <summary>
        /// Получить строку форматирования "Токен обновлён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringTokenIsRefreshed()
        {
            return Localizer["Токен обновлён"];
        }

        #endregion Public methods
    }
}