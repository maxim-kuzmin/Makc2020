//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace Makc2020.Mods.DummyTree.Base.Resources.Successes
{
    /// <summary>
    /// Мод "DummyTree". Основа. Ресурсы. Успехи.
    /// </summary>
    public class ModDummyTreeBaseResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<ModDummyTreeBaseResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModDummyTreeBaseResourceSuccesses(IStringLocalizer<ModDummyTreeBaseResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Вычисление завершено".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringCalculationIsCompleted()
        {
            return Localizer["Вычисление завершено"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с наименованием 'Имя объекта' удалён".
        /// <param name="objectName">Имя объекта.</param>
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringIsDeleted(string objectName)
        {
            return string.Format(
                Localizer["Объект с наименованием '{0}' удалён"],
                objectName
                );
        }

        /// <summary>
        /// Получить строку форматирования "Объекты удалены.
        /// Наименования удалённых объектов: 'Имена объектов[0]', ..., 'Имена объектов[N]'".
        /// </summary>
        /// <param name="objectNames">Имена объектов.</param>
        /// <returns>Строка.</returns>
        public string GetStringAreDeleted(IEnumerable<string> objectNames)
        {
            return string.Format(
                Localizer["Объекты удалены. Наименования удалённых объектов: '{0}'"],
                string.Join("', '", objectNames)
                );
        }

        /// <summary>
        /// Получить строку форматирования "Объект с наименованием 'Имя объекта' вставлен".
        /// </summary>
        /// <param name="objectName">Имя объекта.</param>
        /// <returns>Строка.</returns>
        public string GetStringIsInserted(string objectName)
        {
            return string.Format(
                Localizer["Объект с наименованием '{0}' вставлен"],
                objectName
                );
        }

        /// <summary>
        /// Получить строку форматирования "Объект с наименованием 'Имя объекта' обновлён".
        /// </summary>
        /// <param name="objectName">Имя объекта.</param>
        /// <returns>Строка.</returns>
        public string GetStringIsUpdated(string objectName)
        {
            return string.Format(
                Localizer["Объект с наименованием '{0}' обновлён"],
                objectName
                );
        }

        #endregion Public methods
    }
}