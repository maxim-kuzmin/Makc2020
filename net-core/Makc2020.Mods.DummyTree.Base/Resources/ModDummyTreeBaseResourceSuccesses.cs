//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

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
        /// Получить строку форматирования "Объект с Id = {0} удалён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatObjectWithIdIsDeleted()
        {
            return Localizer["Объект с Id = {0} удалён"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с Id = {0} вставлен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatObjectWithIdIsInserted()
        {
            return Localizer["Объект с Id = {0} вставлен"];
        }

        /// <summary>
        /// Получить строку форматирования "Объект с Id = {0} обновлён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatObjectWithIdIsUpdated()
        {
            return Localizer["Объект с Id = {0} обновлён"];
        }

        #endregion Public methods
    }
}