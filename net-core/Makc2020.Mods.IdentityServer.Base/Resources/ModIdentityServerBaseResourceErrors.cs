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
        /// Получить строку "Не найдены группы доменного пользователя '{0}'".
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        /// <returns>Строка.</returns>
        public string GetStringDomainUserGroupsNotFound(string userName)
        {
            return string.Format(Localizer["Не найдены группы пользователя домена '{0}'"], userName);
        }

        /// <summary>
        /// Получить строку "Доменный пользователь '{0}' не найден".
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        /// <returns>Строка.</returns>
        public string GetStringDomainUserNotFound(string userName)
        {
            return string.Format(Localizer["Доменный пользователь '{0}' не найден"], userName);
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
        /// Получить строку "Возникла ошибка при поиске групп Active Directory: {0}".
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <returns>Строка.</returns>
        public string GetStringLdapGroupsSearchFailed(string errorMessage)
        {
            return string.Format(Localizer["Возникла ошибка при поиске групп Active Directory: {0}"], errorMessage);
        }

        /// <summary>
        /// Получить строку "Неверные имя или пароль".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLdapLoginFailed()
        {
            return Localizer["Неверные имя или пароль"];
        }

        /// <summary>
        /// Получить строку "У пользователя Active Directory нет групп".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLdapUserHasNoGroups()
        {
            return Localizer["У пользователя Active Directory нет групп"];
        }

        /// <summary>
        /// Получить строку "Роли пользователю назначены, но всё под запретом".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserHasNoRights()
        {
            return Localizer["Роли пользователю назначены, но всё под запретом"];
        }

        /// <summary>
        /// Получить строку "Пользователю не назначены роли".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUserHasNoRoles()
        {
            return Localizer["Пользователю не назначены роли"];
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