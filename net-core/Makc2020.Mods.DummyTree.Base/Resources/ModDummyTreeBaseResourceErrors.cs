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
        /// Получить строку форматирования "Значение поля '{0}' не уникально".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatFieldValueIsNotUnique()
        {
            return Localizer["Значение поля '{0}' не уникально"];
        }

        /// <summary>
        /// Получить строку форматирования "Сочетание значений полей \"{0}\" не уникально".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFieldValuesCombinationIsNotUnique(params string[] fieldNames)
        {
            return string.Format(
                Localizer["Сочетание значений полей '{0}' не уникально"],
                string.Join("', '", fieldNames)
                );
        }

        /// <summary>
        /// Получить строку форматирования "Нельзя удалить объект с наименованием '{0}', так как есть связанные с ним сущности".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatHasRelatedData()
        {
            return Localizer["Нельзя удалить объект с наименованием '{0}', так как есть связанные с ним сущности"];
        }

        /// <summary>
        /// Получить строку форматирования "Нельзя удалить объекты, так как есть связанные с ними сущности. Наименования объектов: '{0}'".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatHaveRelatedData()
        {
            return Localizer["Нельзя удалить объекты, так как есть связанные с ними сущности. Наименования объектов: '{0}'"];
        }

        /// <summary>
        /// Получить строку форматирования "Не удалось удалить объекты с наименованиями: '{0}'".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatAreFailedToDelete()
        {
            return Localizer["Не удалось удалить объекты с наименованиями: '{0}'"];
        }

        /// <summary>
        /// Получить строку форматирования "Не удалось удалить объект с наименованием '{0}'".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatIsFailedToDelete()
        {
            return Localizer["Не удалось удалить объект с наименованием '{0}'"];
        }

        #endregion Public methods
    }
}