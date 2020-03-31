//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Tree.Trigger;
using Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Calculate;

namespace Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Trigger
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Запросы. Дерево. Триггер. Построитель.
    /// </summary>
    public class CoreDataClientSqlServerQueryTreeTriggerBuilder : CoreBaseDataQueryTreeTriggerBuilder
    {
        #region Potected methods

        /// <inheritdoc/>
        protected sealed override string CreateSqlForCalculate(string idsSelectQuery)
        {
            return new CoreDataClientSqlServerQueryTreeCalculateBuilder
            {
                IdsSelectQuery = idsSelectQuery,
                LinkTableFieldNameForId = LinkTableFieldNameForId,
                LinkTableFieldNameForParentId = LinkTableFieldNameForParentId,
                TreeTableFieldNameForChildCount = TreeTableFieldNameForChildCount,
                TreeTableFieldNameForDescendantCount = TreeTableFieldNameForDescendantCount,
                TreeTableFieldNameForId = TreeTableFieldNameForId,
                TreeTableFieldNameForParentId = TreeTableFieldNameForParentId
            }.GetResultSql();
        }

        /// <inheritdoc/>
        protected sealed override string CreateSqlForDeclareIdsTable(string tableName, string fieldName)
        {
            return $@"declare {tableName} TABLE ({fieldName} bigint);";
        }

        /// <inheritdoc/>
        protected sealed override string CreateTableNameWithPrefix(string tableNameWithoutPrefix)
        {
            return $@"@{Prefix}{tableNameWithoutPrefix}";
        }

        #endregion Potected methods
    }
}
