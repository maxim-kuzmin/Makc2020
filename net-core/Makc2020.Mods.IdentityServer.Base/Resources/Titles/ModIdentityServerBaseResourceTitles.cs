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

        #endregion Public methods
    }
}