//Author Maxim Kuzmin//makc//

using System.Data.Common;

namespace Makc2020.Data.Entity.Clients.SqlServer.Queries.Tree.Get
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Запросы. Дерево. Получение. Параметры.
    /// </summary>
    public class DataEntityClientSqlServerQueryTreeGetParameters
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public DbParameter Id { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        public DbParameter Level { get; set; }

        #endregion Properties
    }
}
