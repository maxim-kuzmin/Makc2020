//Author Maxim Kuzmin//makc//

using System;

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Исключение.
    /// </summary>
    public class CoreBaseException : Exception
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message"></param>
        public CoreBaseException(string message)
            : base(message)
        {
        }

        #endregion Constructors
    }
}
