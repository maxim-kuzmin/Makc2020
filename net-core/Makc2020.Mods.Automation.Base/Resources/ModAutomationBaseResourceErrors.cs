//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Automation.Base.Resources.Errors
{
    /// <summary>
    /// Мод "Automation". Основа. Ресурсы. Ошибки.
    /// </summary>
    public class ModAutomationBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<ModAutomationBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModAutomationBaseResourceErrors(IStringLocalizer<ModAutomationBaseResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Значение поля \"{0}\" не уникально".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatFieldValueIsNotUnique()
        {
            return Localizer["Значение поля \"{0}\" не уникально"];
        }

        #endregion Public methods
    }
}