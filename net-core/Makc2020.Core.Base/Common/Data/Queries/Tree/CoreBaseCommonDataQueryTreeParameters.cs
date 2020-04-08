//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace Makc2020.Core.Base.Common.Data.Queries.Tree
{
    /// <summary>
    /// Ядро. Основа. Общее. Данные. Запросы. Дерево. Параметры.
    /// </summary>
    public class CoreBaseCommonDataQueryTreeParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
