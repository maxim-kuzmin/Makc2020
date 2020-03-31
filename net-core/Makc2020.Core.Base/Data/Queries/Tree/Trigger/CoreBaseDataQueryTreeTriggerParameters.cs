//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace Makc2020.Core.Base.Data.Queries.Tree.Trigger
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Триггер. Параметры.
    /// </summary>
    public class CoreBaseDataQueryTreeTriggerParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
