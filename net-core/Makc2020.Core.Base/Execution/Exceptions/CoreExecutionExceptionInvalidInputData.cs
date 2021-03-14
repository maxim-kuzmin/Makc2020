//Author Maxim Kuzmin//makc//

using System;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Execution.Exceptions
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Исключения. Недействительный ввод.
    /// </summary>
    public class CoreExecutionExceptionInvalidInput : Exception
    {
        #region Properties

        /// <summary>
        /// Список свойств с недействительными значениями.
        /// </summary>
        public List<string> InvalidProperties { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="invalidProperties">Список свойств с недействительными значениями.</param>
        public CoreExecutionExceptionInvalidInput(List<string> invalidProperties)
            : base(CreateErrorMessage(invalidProperties))
        {
            InvalidProperties = invalidProperties;
        }

        #endregion Constructors

        #region Private methods

        private static string CreateErrorMessage(List<string> invalidProperties)
        {
            return $"Invalid properties: {string.Join(", ", invalidProperties)}";
        }

        #endregion Private methods
    }
}
