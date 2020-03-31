//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace Makc2020.Core.Base.Data.Queries.Tree.Calculate
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Вычисление. Параметры.
    /// </summary>
    public class CoreBaseDataQueryTreeCalculateParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
