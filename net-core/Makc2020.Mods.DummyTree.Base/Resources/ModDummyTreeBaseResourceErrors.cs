//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.DummyTree.Base.Resources.Errors
{
    /// <summary>
    /// Мод "DummyTree". Основа. Ресурсы. Ошибки.
    /// </summary>
    public class ModDummyTreeBaseResourceErrors
    {
        #region Properties

        private IStringLocalizer<ModDummyTreeBaseResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModDummyTreeBaseResourceErrors(IStringLocalizer<ModDummyTreeBaseResourceErrors> localizer)
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