//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Web.Resources.Errors
{
    /// <summary>
    /// Ядро. Веб. Ресурсы. Ошибки.
    /// </summary>
    public class CoreWebResourceErrors
    {
        #region Properties

        private IStringLocalizer<CoreWebResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public CoreWebResourceErrors(IStringLocalizer<CoreWebResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Доступ запрещён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringHttp403()
        {
            return Localizer["Доступ запрещён"];
        }

        /// <summary>
        /// Получить строку "Страница не найдена".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringHttp404()
        {
            return Localizer["Страница не найдена"];
        }

        #endregion Public methods
    }
}