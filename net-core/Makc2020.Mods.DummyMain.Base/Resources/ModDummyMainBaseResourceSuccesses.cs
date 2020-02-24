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