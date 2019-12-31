//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Base.Resources.Errors
{
    /// <summary>
    /// Ядро. Основа. Ресурсы. Ошибки.
    /// </summary>
    public class CoreBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<CoreBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public CoreBaseResourceErrors(IStringLocalizer<CoreBaseResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования ". URL: {2}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatMessagePartWithUrl()
        {
            return Localizer[". URL: {2}"];
        }

        /// <summary>
        /// Получить строку форматирования "{0}. Код ошибки: {1}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatMessageWithCode()
        {
            return Localizer["{0}. Код ошибки: {1}"];
        }

        /// <summary>
        /// Получить строку "Неизвестная ошибка".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUnknownError()
        {
            return Localizer["Неизвестная ошибка"];
        }

        /// <summary>
        /// Получить строку "Ввод содержит недопустимые значения в свойствах: {0}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatMessageIvalidInput()
        {
            return Localizer["Ввод содержит недопустимые значения в свойствах: {0}"];
        }

        #endregion Public methods
    }
}
