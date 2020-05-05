//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Logging;

namespace Makc2020.Core.Base.Logging
{
    /// <summary>
    /// Ядро. Основа. Логирование. Сервис с именем категории.
    /// </summary>
    /// <typeparam name="TCategoryName">Тип, чьё имя используется как имя категории.</typeparam>
    public class CoreBaseLoggingServiceWithCategoryName<TCategoryName> : CoreBaseLoggingService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        public CoreBaseLoggingServiceWithCategoryName(ILogger<TCategoryName> extLogger)
            : base(extLogger)
        {
        }

        #endregion Constructors
    }
}
