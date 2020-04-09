//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Data.Queries.Tree.Trigger;
using Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Calculate;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Trigger
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Запросы. Дерево. Триггер. Построитель.
    /// </summary>
    public class CoreDataClientSqlServerQueryTreeTriggerBuilder : CoreBaseDataQueryTreeTriggerBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
			var aliasForIds = $"{Prefix}ids";
			var aliasForAncestors = $"{Prefix}k";
			var aliasForTree = $"{Prefix}t";

			var cteForAll = $"{Prefix}cte_All";
			var cteForAncestors = $"{Prefix}cte_Link";

			var tableNameForIds = $"@{Prefix}Ids";
            var tableNameForIdsAncestor = $"@{Prefix}IdsAncestor";
            var tableNameForIdsBroken = $"@{Prefix}IdsBroken";
            var tableNameForIdsCalculated = $"@{Prefix}IdsCalculated";
            var tableNameForIdsDescendant = $"@{Prefix}IdsDescendant";
            var tableNameForIdsLinked = $"@{Prefix}IdsLinked";			

			string sqlForIdsSelectQuery = string.Empty;

            var parIds = Parameters.Ids;

            if (parIds.Any() || !string.IsNullOrWhiteSpace(SqlForIdsSelectQuery))
            {
                sqlForIdsSelectQuery = parIds.Any()
                    ?
                    "values (" + string.Join("), (", parIds.Select(x => x.ParameterName)) + ")"
                    :
                    SqlForIdsSelectQuery;
            }
            else
            {
                sqlForIdsSelectQuery = $"select {TreeTableFieldNameForId} from {TreeTableName}";
            }
            
            var sqlForCalculate = CreateSqlForCalculate($"select distinct Val from {tableNameForIdsCalculated}");

			var variableNameForAction = $"@{Prefix}Action";

			var valueForActionDelete = "'D'";
			var valueForActionInsert = "'I'";
			var valueForActionUpdate = "'U'";

			var variableValueForAction = "''";

			switch (Action)
			{
				case CoreBaseCommonEnumSqlTriggerActions.Delete:
					variableValueForAction = valueForActionDelete;
						break;
				case CoreBaseCommonEnumSqlTriggerActions.Insert:
					variableValueForAction = valueForActionInsert;
					break;
				case CoreBaseCommonEnumSqlTriggerActions.Update:
					variableValueForAction = valueForActionUpdate;
					break;
			}

			var result = new StringBuilder($@"
declare {variableNameForAction} char = {variableValueForAction};

declare {tableNameForIds} table (Val bigint);
declare {tableNameForIdsAncestor} table (Val bigint);
declare {tableNameForIdsBroken} table (Val bigint);
declare {tableNameForIdsCalculated} table (Val bigint);
declare {tableNameForIdsDescendant} table (Val bigint);
declare {tableNameForIdsLinked} table (Val bigint);		

insert into {tableNameForIds}
(
    Val
)
{sqlForIdsSelectQuery}
;

-- Добавляем узлы к разрушенным узлам.
insert into {tableNameForIdsBroken}
(
	Val
)
select
	Val
from
	{tableNameForIds}
;

-- Удаление или обновление.
if {variableNameForAction} <> {valueForActionInsert}
begin;
	-- Запоминаем идентификаторы предков удалённых или обновлённых узлов.
	insert into {tableNameForIdsAncestor}
	(
		Val
	)
	select distinct
		{LinkTableFieldNameForParentId}
	from
		{LinkTableName}
	where
		{LinkTableFieldNameForParentId} > 0
		and 
		{LinkTableFieldNameForId} <> {LinkTableFieldNameForParentId}
		and
		{LinkTableFieldNameForId} in (select Val from {tableNameForIds})
	;
end;

-- Обновление.
if {variableNameForAction} = {valueForActionUpdate}
begin;
	-- Запоминаем идентификаторы потомков обновлённых узлов.
	insert into {tableNameForIdsDescendant}
	(
		Val
	)
	select distinct
		{LinkTableFieldNameForId}
	from
		{LinkTableName}
	where
		{LinkTableFieldNameForId} <> {LinkTableFieldNameForParentId}
		and
		{LinkTableFieldNameForParentId} in (select Val from {tableNameForIds})
	;

	-- Добавляем потомков обновлённых узлов к разрушенным узлам.
	insert into {tableNameForIdsBroken}
	(
		Val
	)
	select
		Val
	from
		{tableNameForIdsDescendant}
	;

	-- Добавляем потомков обновлённых узлов к связываемым узлам.
	insert into {tableNameForIdsLinked}
	(
		Val
	)
	select
		Val
	from
		{tableNameForIdsDescendant}
	;
end;

-- Вставка или обновление.
if {variableNameForAction} <> {valueForActionDelete}
begin;
	-- Добавляем вставленные или обновлённые узлы к связываемым узлам.
	insert into {tableNameForIdsLinked}
	(
		Val
	)
	select
		Val
	from
		{tableNameForIds}
	;

	-- Добавляем родителей вставленных или обновлённых узлов к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		Val
	)
	select distinct
		{TreeTableFieldNameForParentId}
	from
		{TreeTableName}
	where
		{TreeTableFieldNameForParentId} is not null
		and
		{TreeTableFieldNameForId} in (select Val from {tableNameForIds})
	;

	-- Запоминаем идентификаторы предков родителей вставленных или обновлённых узлов.
	insert into {tableNameForIdsAncestor}
	(
		Val
	)
	select distinct
		{LinkTableFieldNameForParentId}
	from
		{LinkTableName}
	where
		{LinkTableFieldNameForParentId} > 0
		and
		{LinkTableFieldNameForId} <> {LinkTableFieldNameForParentId}
		and
		{LinkTableFieldNameForId} in (select Val from {tableNameForIdsCalculated})
	;

	-- Добавляем вставленные или обновлённые узлы к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		Val
	)
	select
		Val
	from
		{tableNameForIds}
	;
end;

-- Добавляем предков к вычисляемым узлам.
insert into {tableNameForIdsCalculated}
(
	Val
)
select
	Val
from
	{tableNameForIdsAncestor}
;

-- Обновление.
if {variableNameForAction} = {valueForActionUpdate}
begin;
	-- Добавляем потомков обновлённых узлов к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		Val
	)
	select
		Val
	from
		{tableNameForIdsDescendant}
	;
end;

-- Удаляем связи разрушенных узлов.
delete from	{LinkTableName}
where
	{LinkTableFieldNameForId} in (select Val from {tableNameForIdsBroken})
;		

-- Добавляем связи разрушенных узлов.
with {cteForAncestors} as
(
	select
		{TreeTableFieldNameForId} = {aliasForTree}.{TreeTableFieldNameForId},
		{TreeTableFieldNameForParentId} = COALESCE({aliasForTree}.{TreeTableFieldNameForParentId}, 0)
	from
		{TreeTableName} {aliasForTree}
		inner join {tableNameForIdsLinked} {aliasForIds}
            on {aliasForTree}.{TreeTableFieldNameForId} = {aliasForIds}.Val
	union all
	select
		{TreeTableFieldNameForId} = {aliasForAncestors}.{TreeTableFieldNameForId},
		{TreeTableFieldNameForParentId} = COALESCE({aliasForTree}.{TreeTableFieldNameForParentId}, 0)
	from 
		{TreeTableName} {aliasForTree}
		inner join {cteForAncestors} {aliasForAncestors}
            on {aliasForTree}.{TreeTableFieldNameForId} = {aliasForAncestors}.{TreeTableFieldNameForParentId}
),
{cteForAll} as 
(
	select
		{TreeTableFieldNameForId} = {aliasForTree}.{TreeTableFieldNameForId},
		{TreeTableFieldNameForParentId} = {aliasForTree}.{TreeTableFieldNameForId}
	from
		{TreeTableName} {aliasForTree}
		inner join {tableNameForIdsLinked} {aliasForIds}
			on {aliasForTree}.{TreeTableFieldNameForId} = {aliasForIds}.Val
	union all
	select
		{TreeTableFieldNameForId}, 
		{TreeTableFieldNameForParentId}
	from 
		{cteForAncestors}
)
insert into {LinkTableName}
(
	{LinkTableFieldNameForId},
	{LinkTableFieldNameForParentId}
)
select
	{TreeTableFieldNameForId}, 
	{TreeTableFieldNameForParentId}
from
	{cteForAll}
;

{sqlForCalculate}        
");

            return result.ToString();
        }

        #endregion Public methods

        #region Private methods

        private string CreateSqlForCalculate(string sqlForIdsSelectQuery)
        {
            return new CoreDataClientSqlServerQueryTreeCalculateBuilder
            {                
                LinkTableFieldNameForId = LinkTableFieldNameForId,
                LinkTableFieldNameForParentId = LinkTableFieldNameForParentId,
                LinkTableName = LinkTableName,
                SqlForIdsSelectQuery = sqlForIdsSelectQuery,
                TreeTableFieldNameForId = TreeTableFieldNameForId,
                TreeTableFieldNameForParentId = TreeTableFieldNameForParentId,
                TreeTableFieldNameForTreeChildCount = TreeTableFieldNameForTreeChildCount,
                TreeTableFieldNameForTreeDescendantCount = TreeTableFieldNameForTreeDescendantCount,
                TreeTableFieldNameForTreeLevel = TreeTableFieldNameForTreeLevel,
                TreeTableFieldNameForTreePath = TreeTableFieldNameForTreePath,
                TreeTableFieldNameForTreePosition = TreeTableFieldNameForTreePosition,
                TreeTableFieldNameForTreeSort = TreeTableFieldNameForTreeSort,
                TreeTableName = TreeTableName                
            }.GetResultSql();
        }

        #endregion Private methods
    }
}
