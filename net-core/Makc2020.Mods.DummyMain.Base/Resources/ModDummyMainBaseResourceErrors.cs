//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.DummyMain.Base.Resources.Errors
{
    /// <summary>
    /// Мод "DummyMain". Основа. Ресурсы. Ошибки.
    /// </summary>
    public class ModDummyMainBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<ModDummyMainBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModDummyMainBaseResourceErrors(IStringLocalizer<ModDummyMainBaseResourceErrors> localizer)
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