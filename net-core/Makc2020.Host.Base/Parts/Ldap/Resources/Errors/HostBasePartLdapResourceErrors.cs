//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base.Parts.Ldap.Resources.Errors
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Ресурсы. Ошибки.
    /// </summary>
    public class HostBasePartLdapResourceErrors
    {
        #region Properties

        private IStringLocalizer<HostBasePartLdapResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public HostBasePartLdapResourceErrors(IStringLocalizer<HostBasePartLdapResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Не удалось войти в систему".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFailedToLogin()
        {
            return Localizer["Не удалось войти в систему"];
        }

        #endregion Public methods
    }
}