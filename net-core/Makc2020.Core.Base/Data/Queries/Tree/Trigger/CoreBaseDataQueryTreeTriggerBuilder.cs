//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Data.Queries.Tree.Get;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Base.Data.Queries.Tree.Trigger
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Триггер. Построитель.
    /// </summary>
    public abstract class CoreBaseDataQueryTreeTriggerBuilder
    {
        #region Properties

        /// <summary>
        /// Действие.
        /// </summary>
        public CoreBaseCommonEnumSqlTriggerActions Action { get; set; }

        /// <summary>
        /// Запрос выборки идентификаторов.
        /// </summary>
        public string IdsSelectQuery { get; set; }

        /// <summary>
        /// Имя поля таблицы связи для идентификатора родителя.
        /// </summary>
        public string LinkTableFieldNameForId { get; set; } = "Id";

        /// <summary>
        /// Псевдоним поля таблицы связи для уровня.
        /// </summary>
        public string LinkTableFieldAliasForLevel { get; set; } = "Level";

        /// <summary>
        /// Имя поля таблицы связи для идентификатора родителя.
        /// </summary>
        public string LinkTableFieldNameForParentId { get; set; } = "ParentId";

        /// <summary>
        /// Имя таблицы связи.
        /// </summary>
        public string LinkTableName { get; set; }

        /// <summary>
        /// Параметры.
        /// </summary>
        public CoreBaseDataQueryTreeTriggerParameters Parameters { get; private set; }
            = new CoreBaseDataQueryTreeTriggerParameters();

        /// <summary>
        /// Префикс.
        /// </summary>
        public string Prefix { get; set; } = "TreeTrigger_";

        /// <summary>
        /// Имя поля таблицы дерева для числа детей.
        /// </summary>
        public string TreeTableFieldNameForChildCount { get; set; } = "ChildCount";

        /// <summary>
        /// Имя поля таблицы дерева для числа потомков.
        /// </summary>
        public string TreeTableFieldNameForDescendantCount { get; set; } = "DescendantCount";

        /// <summary>
        /// Имя поля таблицы дерева для идентификатора.
        /// </summary>
        public string TreeTableFieldNameForId { get; set; } = "Id";

        /// <summary>
        /// Имя поля таблицы дерева для идентификатора родителя.
        /// </summary>
        public string TreeTableFieldNameForParentId { get; set; } = "ParentId";

        /// <summary>
        /// Имя таблицы дерева.
        /// </summary>
        public string TreeTableName { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public string GetResultSql()
        {
            var parIds = Parameters.Ids;

            if (!parIds.Any() && string.IsNullOrWhiteSpace(IdsSelectQuery))
            {
                return null;
            }

            var cteForIds = $"{Prefix}cte_Ids";
            var cteForLink = $"{Prefix}cte_Link";

            var aliasForIds = $"{Prefix}ids";
            var aliasForLink = $"{Prefix}k";
            var aliasForResult = $"{Prefix}r";
            var aliasForTree = $"{Prefix}t";

            var fieldNameForVal = "Val";

            var tableNameForIdsAncestor = CreateTableNameWithPrefix("IdsAncestor");
            var tableNameForIdsBroken = CreateTableNameWithPrefix("IdsBroken");
            var tableNameForIdsCalculated = CreateTableNameWithPrefix("IdsCalculated");
            var tableNameForIdsDescendant = CreateTableNameWithPrefix("IdsDescendant");

            var sqlForCalculate = CreateSqlForCalculate($"select {fieldNameForVal} from {tableNameForIdsCalculated}");
            var sqlForGetAncestors = CreateSqlForGet(CoreBaseCommonEnumTreeAxis.Ancestor);
            var sqlForGetDescendants = CreateSqlForGet(CoreBaseCommonEnumTreeAxis.Descendant);

            var result = new StringBuilder($@"
{CreateSqlForDeclareIdsTable(tableNameForIdsAncestor, fieldNameForVal)}
{CreateSqlForDeclareIdsTable(tableNameForIdsBroken, fieldNameForVal)}
{CreateSqlForDeclareIdsTable(tableNameForIdsCalculated, fieldNameForVal)}
{CreateSqlForDeclareIdsTable(tableNameForIdsDescendant, fieldNameForVal)}
");

            result.Append($"insert into {tableNameForIdsBroken} ({fieldNameForVal}) ");

            if (parIds.Any())
            {
                result.Append("values (");
                result.Append(string.Join(", ", parIds.Select(x => x.ParameterName)));
                result.Append(")");
            }
            else
            {
                result.Append(IdsSelectQuery);
            }

            if (Action != CoreBaseCommonEnumSqlTriggerActions.Insert)
            {
                result.Append($@"
-- Запоминаем идентификаторы предков удалённых узлов.
insert into {tableNameForIdsAncestor}
select 
	{aliasForTree}.{TreeTableFieldNameForId}
from
    ({sqlForGetAncestors}) {aliasForTree}
	inner join {tableNameForIdsBroken} {aliasForIds}
        on {aliasForIds}.{fieldNameForVal} = {aliasForTree}.{TreeTableFieldNameForId}
;

-- Запоминаем идентификаторы потомков удалённых узлов.
insert into {tableNameForIdsDescendant}
select 
	{aliasForTree}.{TreeTableFieldNameForId}
from 
	({sqlForGetDescendants}) {aliasForTree}
	inner join {tableNameForIdsBroken} {aliasForIds}
        on {aliasForIds}.{fieldNameForVal} = {aliasForTree}.{TreeTableFieldNameForId}
;
");
            }

            switch (Action)
            {
                case CoreBaseCommonEnumSqlTriggerActions.Delete:
                    result.Append($@"
-- Удаляем потомков удалённых узлов.
delete t 
from	
	{TreeTableName} {aliasForTree}
	inner join {tableNameForIdsDescendant} {aliasForIds}
        on {aliasForIds}.{fieldNameForVal} = {aliasForTree}.{TreeTableFieldNameForId}
;

insert into {tableNameForIdsCalculated}
(
    {fieldNameForVal}
)
select {fieldNameForVal} from {tableNameForIdsAncestor}
;
");
                    break;
                case CoreBaseCommonEnumSqlTriggerActions.Insert:
                    result.Append($@"
insert into {tableNameForIdsCalculated}
(
    {fieldNameForVal}
)
select distinct
    {aliasForTree}.{TreeTableFieldNameForParentId}
from
    {TreeTableName} {aliasForTree}
    inner join {tableNameForIdsBroken} {aliasForIds}
        on {aliasForIds}.{fieldNameForVal} = {aliasForTree}.{TreeTableFieldNameForId}
;
");
                    break;
                case CoreBaseCommonEnumSqlTriggerActions.Update:
                    result.Append($@"
if exists(select * from {tableNameForIdsDescendant})
begin;
	-- Удаляем связи потомков разрушенных узлов.
	delete {aliasForLink}
	from 
		{LinkTableName} {aliasForLink}
		inner join {tableNameForIdsDescendant} {aliasForIds}
            on {aliasForIds}.{fieldNameForVal} = {aliasForLink}.{LinkTableFieldNameForId}
	;					
end;

-- Удаляем связи разрушенных узлов.
delete {aliasForLink} 
from 
	{LinkTableName} {aliasForLink}
	inner join {tableNameForIdsBroken} {aliasForIds}
        on {aliasForIds}.{fieldNameForVal} = {aliasForLink}.{LinkTableFieldNameForId}
;

insert into {tableNameForIdsCalculated}
(
    {fieldNameForVal}
)
select {fieldNameForVal} from {tableNameForIdsBroken}
union
select {fieldNameForVal} from {tableNameForIdsAncestor}
union
select {fieldNameForVal} from {tableNameForIdsDescendant}
;
");
                    break;
            }

            result.Append($@"
-- Вставляем связи разрушенных узлов и их потомков.
with {cteForIds} as 
(
	select {fieldNameForVal} from {tableNameForIdsBroken} 
	union
	select {fieldNameForVal} from {tableNameForIdsDescendant} 
),
{cteForLink} as
(
	select
		{LinkTableFieldNameForId} = {aliasForTree}.{TreeTableFieldNameForId},
		{LinkTableFieldNameForParentId} = coalesce({aliasForTree}.{TreeTableFieldNameForParentId}, 0),
		{LinkTableFieldAliasForLevel} = 0
	from
		{TreeTableName} {aliasForTree}
		inner join {cteForIds} {aliasForIds}
            on {aliasForIds}.{fieldNameForVal} = {aliasForTree}.{TreeTableFieldNameForId}
	union all
	select
		{LinkTableFieldNameForId} = {aliasForLink}.{LinkTableFieldNameForId},
		{LinkTableFieldNameForParentId} = ISNULL({aliasForTree}.{TreeTableFieldNameForParentId}, 0),
		{LinkTableFieldAliasForLevel} = {aliasForLink}.{LinkTableFieldAliasForLevel} + 1
	from 
		{TreeTableName} {aliasForTree}
		inner join {cteForLink} {aliasForLink}
            on {aliasForLink}.{LinkTableFieldNameForParentId} = {aliasForTree}.{TreeTableFieldNameForId}
)
insert into {LinkTableName}
(
	{LinkTableFieldNameForId},
	{LinkTableFieldNameForParentId},
	{LinkTableFieldAliasForLevel}
)
select
	{LinkTableFieldNameForId},
	{LinkTableFieldNameForParentId},
	{LinkTableFieldAliasForLevel}
from
	{cteForLink}
order by
	{LinkTableFieldNameForId},
	{LinkTableFieldNameForParentId}
;

{sqlForCalculate}
");

            return result.ToString();
        }

        #endregion Public methods

        #region Potected methods

        /// <summary>
        /// Создать SQL для вычисления.
        /// </summary>
        /// <param name="sqlForIdsSelect">SQL для выборку идентификаторов.</param>
        /// <returns>SQL.</returns>
        protected abstract string CreateSqlForCalculate(string sqlForIdsSelect);

        /// <summary>
        /// Создать SQL для объявления таблицы идентификаторов.
        /// </summary>
        /// <param name="tableName">Имя таблицы.</param>
        /// <param name="fieldName">Имя поля.</param>
        /// <returns>SQL.</returns>
        protected abstract string CreateSqlForDeclareIdsTable(string tableName, string fieldName);

        /// <summary>
        /// Создать имя таблицы с префиксом.
        /// </summary>
        /// <param name="tableNameWithoutPrefix">Имя таблицы без префикса.</param>
        /// <returns>Имя таблицы.</returns>
        protected abstract string CreateTableNameWithPrefix(string tableNameWithoutPrefix);

        #endregion Potected methods

        #region Private methods

        private string CreateSqlForGet(CoreBaseCommonEnumTreeAxis axis)
        {
            var builder = new CoreBaseDataQueryTreeGetBuilder
            {
                Axis = axis,
                LinkTableFieldAliasForLevel = LinkTableFieldAliasForLevel,
                LinkTableFieldNameForId = LinkTableFieldNameForId,
                LinkTableFieldNameForParentId = LinkTableFieldNameForParentId,
                TreeTableFieldNameForId = TreeTableFieldNameForId,
                TreeTableFieldNameForParentId = TreeTableFieldNameForParentId
            };

            builder.TreeTableFiealdAliasesByNames.Add(
                TreeTableFieldNameForId,
                TreeTableFieldNameForId
                );

            return builder.GetResultSql();
        }

        #endregion Private methods
    }
}
