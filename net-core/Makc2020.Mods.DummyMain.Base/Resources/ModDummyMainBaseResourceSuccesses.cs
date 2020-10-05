//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.DummyMain.Base.Resources.Successes
{
    /// <summary>
    /// Мод "DummyMain". Основа. Ресурсы. Успехи.
    /// </summary>
    public class ModDummyMainBaseResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<ModDummyMainBaseResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModDummyMainBaseResourceSuccesses(IStringLocalizer<ModDummyMainBaseResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Объект с наименованием '{0}' удалён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatIsDeleted()
        {
            return Localizer["Объект с наименованием '{0}' удалён"];
        }

        /// <summary>
        /// Получить строку форматирования "Объекты удалены. Наименования удалённых объектов: '{0}'".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatAreDeleted()
        {
            return Localizer["Объекты удалены. Наименования удалённых объектов: '{0}'"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с наименованием '{0}' вставлен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatIsInserted()
        {
            return Localizer["Объект с наименованием '{0}' вставлен"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с наименованием '{0}' обновлён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatIsUpdated()
        {
            return Localizer["Объект с наименованием '{0}' обновлён"];
        }

        #endregion Public methods
    }
}