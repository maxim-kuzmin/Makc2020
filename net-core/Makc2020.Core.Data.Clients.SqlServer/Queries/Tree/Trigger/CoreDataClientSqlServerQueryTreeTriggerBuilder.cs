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
			var aliasForIds = $"[{Prefix}ids]";
			var aliasForAncestors = $"[{Prefix}k]";
			var aliasForTree = $"[{Prefix}t]";

			var cteForAll = $"[{Prefix}cte_All]";
			var cteForAncestors = $"[{Prefix}cte_Link]";

			var linkTableFieldNameForId = $"[{LinkTableFieldNameForId}]";
			var linkTableFieldNameForParentId = $"[{LinkTableFieldNameForParentId}]";

			var linkTableName = $"[{LinkTableSchema}].[{LinkTableNameWithoutSchema}]";

			var tableNameForIds = $"@{Prefix}Ids";
			var tableNameForIdsAncestor = $"@{Prefix}IdsAncestor";
			var tableNameForIdsBroken = $"@{Prefix}IdsBroken";
			var tableNameForIdsCalculated = $"@{Prefix}IdsCalculated";
			var tableNameForIdsDescendant = $"@{Prefix}IdsDescendant";
			var tableNameForIdsLinked = $"@{Prefix}IdsLinked";

			var treeTableFieldNameForId = $"[{TreeTableFieldNameForId}]";
			var treeTableFieldNameForParentId = $"[{TreeTableFieldNameForParentId}]";

			var treeTableName = $"[{TreeTableSchema}].[{TreeTableNameWithoutSchema}]";

			var val = "[val]";

			var sqlForIdsSelectQuery = string.Empty;

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
				sqlForIdsSelectQuery = $"select {treeTableFieldNameForId} from {treeTableName}";
			}

			var sqlForCalculate = CreateSqlForCalculate($"select distinct {val} from {tableNameForIdsCalculated}");

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

declare {tableNameForIds} table ({val} bigint);
declare {tableNameForIdsAncestor} table ({val} bigint);
declare {tableNameForIdsBroken} table ({val} bigint);
declare {tableNameForIdsCalculated} table ({val} bigint);
declare {tableNameForIdsDescendant} table ({val} bigint);
declare {tableNameForIdsLinked} table ({val} bigint);		

insert into {tableNameForIds}
(
    {val}
)
{sqlForIdsSelectQuery}
;

-- Добавляем узлы к разрушенным узлам.
insert into {tableNameForIdsBroken}
(
	{val}
)
select
	{val}
from
	{tableNameForIds}
;

-- Удаление или обновление.
if {variableNameForAction} <> {valueForActionInsert}
begin;
	-- Запоминаем идентификаторы предков удалённых или обновлённых узлов.
	insert into {tableNameForIdsAncestor}
	(
		{val}
	)
	select distinct
		{linkTableFieldNameForParentId}
	from
		{linkTableName}
	where
		{linkTableFieldNameForParentId} > 0
		and 
		{linkTableFieldNameForId} <> {linkTableFieldNameForParentId}
		and
		{linkTableFieldNameForId} in (select {val} from {tableNameForIds})
	;
end;

-- Обновление.
if {variableNameForAction} = {valueForActionUpdate}
begin;
	-- Запоминаем идентификаторы потомков обновлённых узлов.
	insert into {tableNameForIdsDescendant}
	(
		{val}
	)
	select distinct
		{linkTableFieldNameForId}
	from
		{linkTableName}
	where
		{linkTableFieldNameForId} <> {linkTableFieldNameForParentId}
		and
		{linkTableFieldNameForParentId} in (select {val} from {tableNameForIds})
	;

	-- Добавляем потомков обновлённых узлов к разрушенным узлам.
	insert into {tableNameForIdsBroken}
	(
		{val}
	)
	select
		{val}
	from
		{tableNameForIdsDescendant}
	;

	-- Добавляем потомков обновлённых узлов к связываемым узлам.
	insert into {tableNameForIdsLinked}
	(
		{val}
	)
	select
		{val}
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
		{val}
	)
	select
		{val}
	from
		{tableNameForIds}
	;

	-- Добавляем родителей вставленных или обновлённых узлов к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		{val}
	)
	select distinct
		{treeTableFieldNameForParentId}
	from
		{treeTableName}
	where
		{treeTableFieldNameForParentId} is not null
		and
		{treeTableFieldNameForId} in (select {val} from {tableNameForIds})
	;

	-- Запоминаем идентификаторы предков родителей вставленных или обновлённых узлов.
	insert into {tableNameForIdsAncestor}
	(
		{val}
	)
	select distinct
		{linkTableFieldNameForParentId}
	from
		{linkTableName}
	where
		{linkTableFieldNameForParentId} > 0
		and
		{linkTableFieldNameForId} <> {linkTableFieldNameForParentId}
		and
		{linkTableFieldNameForId} in (select {val} from {tableNameForIdsCalculated})
	;

	-- Добавляем вставленные или обновлённые узлы к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		{val}
	)
	select
		{val}
	from
		{tableNameForIds}
	;
end;

-- Добавляем предков к вычисляемым узлам.
insert into {tableNameForIdsCalculated}
(
	{val}
)
select
	{val}
from
	{tableNameForIdsAncestor}
;

-- Обновление.
if {variableNameForAction} = {valueForActionUpdate}
begin;
	-- Добавляем потомков обновлённых узлов к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		{val}
	)
	select
		{val}
	from
		{tableNameForIdsDescendant}
	;
end;

-- Удаляем связи разрушенных узлов.
delete from	{linkTableName}
where
	{linkTableFieldNameForId} in (select {val} from {tableNameForIdsBroken})
;		

-- Добавляем связи разрушенных узлов.
with {cteForAncestors} as
(
	select
		{treeTableFieldNameForId} = {aliasForTree}.{treeTableFieldNameForId},
		{treeTableFieldNameForParentId} = COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0)
	from
		{treeTableName} {aliasForTree}
		inner join {tableNameForIdsLinked} {aliasForIds}
            on {aliasForTree}.{treeTableFieldNameForId} = {aliasForIds}.{val}
	union all
	select
		{treeTableFieldNameForId} = {aliasForAncestors}.{treeTableFieldNameForId},
		{treeTableFieldNameForParentId} = COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0)
	from 
		{treeTableName} {aliasForTree}
		inner join {cteForAncestors} {aliasForAncestors}
            on {aliasForTree}.{treeTableFieldNameForId} = {aliasForAncestors}.{treeTableFieldNameForParentId}
),
{cteForAll} as 
(
	select
		{treeTableFieldNameForId} = {aliasForTree}.{treeTableFieldNameForId},
		{treeTableFieldNameForParentId} = {aliasForTree}.{treeTableFieldNameForId}
	from
		{treeTableName} {aliasForTree}
		inner join {tableNameForIdsLinked} {aliasForIds}
			on {aliasForTree}.{treeTableFieldNameForId} = {aliasForIds}.{val}
	union all
	select
		{treeTableFieldNameForId}, 
		{treeTableFieldNameForParentId}
	from 
		{cteForAncestors}
)
insert into {linkTableName}
(
	{linkTableFieldNameForId},
	{linkTableFieldNameForParentId}
)
select
	{treeTableFieldNameForId}, 
	{treeTableFieldNameForParentId}
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
				LinkTableNameWithoutSchema = LinkTableNameWithoutSchema,
				LinkTableSchema = LinkTableSchema,
				SqlForIdsSelectQuery = sqlForIdsSelectQuery,
				TreeTableFieldNameForId = TreeTableFieldNameForId,
				TreeTableFieldNameForParentId = TreeTableFieldNameForParentId,
				TreeTableFieldNameForTreeChildCount = TreeTableFieldNameForTreeChildCount,
				TreeTableFieldNameForTreeDescendantCount = TreeTableFieldNameForTreeDescendantCount,
				TreeTableFieldNameForTreeLevel = TreeTableFieldNameForTreeLevel,
				TreeTableFieldNameForTreePath = TreeTableFieldNameForTreePath,
				TreeTableFieldNameForTreePosition = TreeTableFieldNameForTreePosition,
				TreeTableFieldNameForTreeSort = TreeTableFieldNameForTreeSort,
				TreeTableNameWithoutSchema = TreeTableNameWithoutSchema,
				TreeTableSchema = TreeTableSchema
			}.GetResultSql();
		}

		#endregion Private methods
	}
}
