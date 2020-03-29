//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace Makc2020.Data.Entity.Clients.SqlServer.Queries.Tree.Trigger
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Запросы. Дерево. Триггер. Параметры.
    /// </summary>
    public class DataEntityClientSqlServerQueryTreeTriggerParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
