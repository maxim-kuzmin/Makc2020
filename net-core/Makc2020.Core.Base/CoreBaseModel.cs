//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Модель.
    /// </summary>
    public class CoreBaseModel
    {
        #region Properties

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected CoreBaseLoggingService AppLogger { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appLogger">Регистратор.</param>
        public CoreBaseModel(CoreBaseLoggingService appLogger)
        {
            AppLogger = appLogger;
        }

        #endregion Constructors
    }
}
