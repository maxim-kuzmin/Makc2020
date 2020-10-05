//Author Maxim Kuzmin//makc//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Base.Common.Exceptions
{
    /// <summary>
    /// Ядро. Основа. Общее. Исключения. Неудалённое.
    /// </summary>
    public class CoreBaseCommonExceptionNonDeleted : Exception
    {
        #region Properties

        /// <summary>
        /// Элементы, удаление которых вызвало исключение.
        /// </summary>
        public IEnumerable<string> FailedItems { get; private set; }

        /// <summary>
        /// Элементы, удаление которых невозможно из-за наличия связей.
        /// </summary>
        public IEnumerable<string> RelatedItems { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="failedItems">Элементы, удаление которых вызвало исключение.</param>
        /// <param name="relatedItems">Элементы, удаление которых невозможно из-за наличия связей.</param>
        /// <param name="exception">Исключение.</param>
        public CoreBaseCommonExceptionNonDeleted(IEnumerable<string> failedItems, IEnumerable<string> relatedItems, Exception exception)
            : base(CreateMessage(failedItems, relatedItems), exception)
        {
            FailedItems = failedItems;
            RelatedItems = relatedItems;
        }

        #endregion Constructors

        #region Private methods

        private static string CreateMessage(IEnumerable<string> failedItems, IEnumerable<string> relatedItems)
        {
            var result = new StringBuilder();

            if (failedItems != null && failedItems.Any())
            {
                result.Append("FailedItems: ");
                result.Append(string.Join(", ", failedItems));
            }

            if (relatedItems != null && relatedItems.Any())
            {
                result.Append("RelatedItems: ");
                result.Append(string.Join(", ", relatedItems));
            }

            return result.ToString();
        }

        #endregion Private methods
    }
}
