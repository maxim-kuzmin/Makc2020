//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base.Parts.Auth.Resources.Successes
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Ресурсы. Успехи.
    /// </summary>
    public class HostBasePartAuthResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<HostBasePartAuthResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public HostBasePartAuthResourceSuccesses(IStringLocalizer<HostBasePartAuthResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования "Пользователь создан".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringCurrentUserIsCreated()
        {
            return Localizer["Пользователь создан"];
        }

        /// <summary>
        /// Получить строку форматирования "Текущий пользователь получен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringCurrentUserIsReceived()
        {
            return Localizer["Текущий пользователь получен"];
        }

        #endregion Public methods
    }
}