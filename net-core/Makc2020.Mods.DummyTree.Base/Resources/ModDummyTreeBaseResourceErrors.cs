//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;
using System.Collections;
using System.Collections.Generic;

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
        /// Получить строку "Значение поля 'Имя поля' не уникально".
        /// </summary>
        /// <param name="fieldName">Имя поля.</param>
        /// <returns>Строка.</returns>
        public string GetStringFieldValueIsNotUnique(string fieldName)
        {
            return string.Format(Localizer["Значение поля '{0}' не уникально"], fieldName);
        }

        /// <summary>
        /// Получить строку "Сочетание значений полей 'Имена полей[0]', ..., 'Имена полей[N]' не уникально".
        /// </summary>
        /// <param name="fieldNames">Имена полей.</param>
        /// <returns>Строка.</returns>
        public string GetStringFieldValuesCombinationIsNotUnique(IEnumerable<string> fieldNames)
        {
            return string.Format(
                Localizer["Сочетание значений полей '{0}' не уникально"],
                string.Join("', '", fieldNames)
                );
        }

        /// <summary>
        /// Получить строку "Нельзя удалить объект с наименованием 'Имя объекта',
        /// так как есть связанные с ним сущности".
        /// </summary>
        /// <param name="objectName">Имя объекта.</param>
        /// <returns>Строка.</returns>
        public string GetStringCannotBeDeletedBecauseHasRelatedData(string objectName)
        {
            return string.Format(
                Localizer["Нельзя удалить объект с наименованием '{0}', так как есть связанные с ним сущности"],
                objectName
                );
        }

        /// <summary>
        /// Получить строку "Нельзя удалить объекты, так как есть связанные с ними сущности.
        /// Наименования объектов: 'Имена объектов[0]', ..., 'Имена объектов[N]'".
        /// </summary>
        /// <param name="objectNames">Имена объектов.</param>
        /// <returns>Строка.</returns>
        public string GetStringCannotBeDeletedBecauseHaveRelatedData(IEnumerable<string> objectNames)
        {
            return string.Format(
                Localizer["Нельзя удалить объекты, так как есть связанные с ними сущности. Наименования объектов: '{0}'"],
                string.Join("', '", objectNames)
                );
        }

        /// <summary>
        /// Получить строку форматирования "Не удалось удалить объекты с наименованиями:
        /// 'Имена объектов[0]', ..., 'Имена объектов[N]'".
        /// </summary>
        /// <param name="objectNames">Имена объектов.</param>
        /// <returns>Строка.</returns>
        public string GetStringAreFailedToDelete(IEnumerable<string> objectNames)
        {
            return string.Format(
                Localizer["Не удалось удалить объекты с наименованиями: '{0}'"],
                string.Join("', '", objectNames)
                );

        }

        /// <summary>
        /// Получить строку форматирования "Не удалось удалить объект с наименованием 'Имя объекта'".
        /// </summary>
        /// <param name="objectName">Имя объекта.</param>
        /// <returns>Строка.</returns>
        public string GetStringIsFailedToDelete(string objectName)
        {
            return string.Format(
                Localizer["Не удалось удалить объект с наименованием '{0}'"],
                objectName
                );
        }

        #endregion Public methods
    }
}