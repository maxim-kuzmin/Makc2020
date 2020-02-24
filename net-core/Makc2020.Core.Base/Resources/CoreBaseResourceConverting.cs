//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Base.Resources.Converting
{
    /// <summary>
    /// Ядро. Основа. Ресурсы. Преобразование.
    /// </summary>
    public class CoreBaseResourceConverting
    {
        #region Properties

        private IStringLocalizer<CoreBaseResourceConverting> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public CoreBaseResourceConverting(IStringLocalizer<CoreBaseResourceConverting> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "dd.MM.yyyy".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringDateFormat()
        {
            return Localizer["dd.MM.yyyy"];
        }

        #endregion Public methods
    }
}