//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace Makc2020.Data.Entity.Clients.SqlServer.Queries.Tree.Calculate
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Запросы. Дерево. Вычисление. Параметры.
    /// </summary>
    public class DataEntityClientSqlServerQueryTreeCalculateParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
