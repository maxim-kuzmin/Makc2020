//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Logging;

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
        protected ILogger ExtLogger { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        public CoreBaseModel(ILogger extLogger)
        {
            ExtLogger = extLogger;
        }

        #endregion Constructors
    }
}
