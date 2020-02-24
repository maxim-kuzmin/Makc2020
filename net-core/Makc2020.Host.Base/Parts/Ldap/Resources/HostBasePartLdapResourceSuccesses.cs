//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base.Parts.Ldap.Resources.Successes
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Ресурсы. Успехи.
    /// </summary>
    public class HostBasePartLdapResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<HostBasePartLdapResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public HostBasePartLdapResourceSuccesses(IStringLocalizer<HostBasePartLdapResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Вход выполнен успешно".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginIsSuccessful()
        {
            return Localizer["Вход выполнен успешно"];
        }

        #endregion Public methods
    }
}