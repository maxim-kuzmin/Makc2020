//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Logging;

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Модель.
    /// </summary>
    public class CoreWebModel
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
        public CoreWebModel(ILogger extLogger)
        {
            ExtLogger = extLogger;
        }

        #endregion Constructors
    }
}
