//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Core.Base.Execution
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Результат.
    /// </summary>
    public class CoreBaseExecutionResult
    {
        #region Properties

        /// <summary>
        /// Признак успешности выполнения.
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// Сообщения об ошибках.
        /// </summary>
        public HashSet<string> ErrorMessages { get; set; }

        /// <summary>
        /// Сообщения об успехах.
        /// </summary>
        public HashSet<string> SuccessMessages { get; set; }

        /// <summary>
        /// Сообщения о предупреждениях.
        /// </summary>
        public HashSet<string> WarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public CoreBaseExecutionResult()
        {
            ErrorMessages = new HashSet<string>();
            SuccessMessages = new HashSet<string>();
            WarningMessages = new HashSet<string>();
        }

        #endregion Constructors
    }
}
