//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Exceptions;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Common.Jobs.List.Delete
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Список. Удаление. Ввод.
    /// </summary>
    public class CoreBaseCommonJobListDeleteInput
    {
        #region Properties

        /// <summary>
        /// Удалённые элементы.
        /// </summary>
        public IEnumerable<string> DeletedItems { get; set; }

        /// <summary>
        /// Исключение.
        /// </summary>
        public CoreBaseCommonExceptionNonDeleted Exception { get; set; }

        #endregion Properties
    }
}