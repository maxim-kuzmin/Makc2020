//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.IdentityServer.Base.Resources.Titles
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Ресурсы. Заголовки.
    /// </summary>
    public class ModIdentityServerBaseResourceTitles
    {
        #region Properties

        private IStringLocalizer<ModIdentityServerBaseResourceTitles> Localizer { get; }
        
        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModIdentityServerBaseResourceTitles(IStringLocalizer<ModIdentityServerBaseResourceTitles> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Ошибки".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringErrors()
        {
            return Localizer["Ошибки"];
        }

        /// <summary>
        /// Получить строку "Вход в систему".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLogin()
        {
            return Localizer["Вход в систему"];
        }

        /// <summary>
        /// Получить строку "Войти".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginAction()
        {
            return Localizer["Войти"];
        }

        /// <summary>
        /// Получить строку "Способ входа в систему".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginMethod()
        {
            return Localizer["Способ входа в систему"];
        }

        /// <summary>
        /// Получить строку "LDAP".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginMethodLdap()
        {
            return Localizer["LDAP"];
        }

        /// <summary>
        /// Получить строку "Local".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginMethodLocal()
        {
            return Localizer["Local"];
        }

        /// <summary>
        /// Получить строку "Windows".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginMethodWindows()
        {
            return Localizer["Windows"];
        }

        /// <summary>
        /// Получить строку "Выйти".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLogout()
        {
            return Localizer["Выйти"];
        }

        /// <summary>
        /// Получить строку "Сейчас будет произведен выход со страницы".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLogoutDescription()
        {
            return Localizer["Сейчас будет произведен выход со страницы"];
        }

        /// <summary>
        /// Получить строку "Вы точно хотите выйти из системы?".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLogoutQuestion()
        {
            return Localizer["Вы точно хотите выйти из системы?"];
        }

        /// <summary>
        /// Получить строку "Пароль".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringPassword()
        {
            return Localizer["Пароль"];
        }

        /// <summary>
        /// Получить строку "Запомнить мой вход в систему".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringRememberMyLogin()
        {
            return Localizer["Запомнить мой вход в систему"];
        }

        /// <summary>
        /// Получить строку "Имя пользователя".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUsername()
        {
            return Localizer["Имя пользователя"];
        }

        /// <summary>
        /// Получить строку "Да".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringYes()
        {
            return Localizer["Да"];
        }

        #endregion Public methods
    }
}