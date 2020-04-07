//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Tree.Calculate;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Calculate
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Запросы. Дерево. Вычисление. Построитель.
    /// </summary>
    public class CoreDataClientSqlServerQueryTreeCalculateBuilder : CoreBaseDataQueryTreeCalculateBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
            var aliasForLink = $"{Prefix}k";
            var aliasForLink1 = $"{Prefix}k1";
            var aliasForLink2 = $"{Prefix}k2";
            var aliasForResult = $"{Prefix}r";
            var aliasForTree = $"{Prefix}t";

            var result = new StringBuilder($@"
while 1 = 1
begin;
	with cte as
	(
		select top 1
			{TreeTableFieldNameForId},
			{TreeTableFieldNameForParentId},
			{TreeTableFieldNameForTreePosition}
		from
			{TreeTableName}
		where
			{TreeTableFieldNameForTreePosition} = 0
	)
	update cte set
		{TreeTableFieldNameForTreePosition} = 
		(
			select
				MAX({aliasForTree}.{TreeTableFieldNameForTreePosition}) + 10
			from
				{TreeTableName} {aliasForTree}
			where
				COALESCE({aliasForTree}.{TreeTableFieldNameForParentId}, 0) = COALESCE(cte.{TreeTableFieldNameForParentId}, 0)
		)
	;

	if @@ROWCOUNT < 1 break;
end;

with cte as
(
	select
		{TreeTableFieldNameForId},
		{TreeTableFieldNameForTreeChildCount},
		{TreeTableFieldNameForTreeDescendantCount},
		{TreeTableFieldNameForTreeLevel},
		{TreeTableFieldNameForTreePath},
		{TreeTableFieldNameForTreeSort}
	from
		{TreeTableName}
)
update cte set
	{TreeTableFieldNameForTreeChildCount} = 
	(
		select
			COUNT_BIG(*)
		from
			{TreeTableName} {aliasForTree}
		where
			{aliasForTree}.{TreeTableFieldNameForParentId} = cte.{TreeTableFieldNameForId}
	),
	{TreeTableFieldNameForTreeDescendantCount} = 
	(
		select
			COUNT_BIG(*)
		from
			{LinkTableName} {aliasForLink}
		where
			{aliasForLink}.{LinkTableFieldNameForParentId} = cte.{TreeTableFieldNameForId}
			and
			{aliasForLink}.{LinkTableFieldNameForParentId} <> {aliasForLink}.{LinkTableFieldNameForId}
	),
	{TreeTableFieldNameForTreeLevel} = 
	(
		select
			COUNT_BIG(*) - 1
		from
			{LinkTableName} {aliasForLink}
		where
			{aliasForLink}.{LinkTableFieldNameForId} = cte.{TreeTableFieldNameForId}
	),
	{TreeTableFieldNameForTreePath} =
	(
		select
			COALESCE({aliasForResult}.Val, N'')
		from
		(
			select
				{aliasForLink1}.{LinkTableFieldNameForId},
				STUFF
				(
					(
						select
							',' + CONVERT(varchar(max), {aliasForLink2}.{LinkTableFieldNameForParentId})
						from
							{LinkTableName} {aliasForLink2}
						where
							{aliasForLink1}.{LinkTableFieldNameForId} = {aliasForLink2}.{LinkTableFieldNameForId}
							and
							{aliasForLink2}.{LinkTableFieldNameForParentId} > 0
							and
							{aliasForLink2}.{LinkTableFieldNameForParentId} <> {aliasForLink2}.{LinkTableFieldNameForId}
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) Val
			from
				{LinkTableName} {aliasForLink1}
			group by
				{aliasForLink1}.{LinkTableFieldNameForId}
		) {aliasForResult}
		where
			{aliasForResult}.{LinkTableFieldNameForId} = cte.{TreeTableFieldNameForId}
	),
	{TreeTableFieldNameForTreeSort} =
	(
		select
			COALESCE({aliasForResult}.Val, N'')
		from
		(
			select
				{aliasForLink1}.{LinkTableFieldNameForId},
				STUFF
				(
					(
						select
							',' + RIGHT('0000000000' + CONVERT(varchar(max), {aliasForTree}.{TreeTableFieldNameForTreePosition}) + '.' + CONVERT(varchar(max), {aliasForLink2}.{LinkTableFieldNameForParentId}), 10)
						from
							{LinkTableName} {aliasForLink2}
							inner join {TreeTableName} {aliasForTree}
								on {aliasForTree}.{TreeTableFieldNameForId} = {aliasForLink2}.{LinkTableFieldNameForParentId}
						where
							{aliasForLink1}.{LinkTableFieldNameForId} = {aliasForLink2}.{LinkTableFieldNameForId}
							and
							{aliasForLink2}.{LinkTableFieldNameForParentId} > 0
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) Val
			from
				{LinkTableName} {aliasForLink1}
			group by
				{aliasForLink1}.{LinkTableFieldNameForId}
		) {aliasForResult}
		where
			{aliasForResult}.{LinkTableFieldNameForId} = cte.{TreeTableFieldNameForId}
	)
");
			var parIds = Parameters.Ids;

			if (parIds.Any() || !string.IsNullOrWhiteSpace(SqlForIdsSelectQuery))
			{
				var sqlForIdsSelectQuery = parIds.Any()
					?
					string.Join(", ", parIds.Select(x => x.ParameterName))
					:
					SqlForIdsSelectQuery;

				result.Append($@"
where
	cte.{TreeTableFieldNameForId} in
	(
		{sqlForIdsSelectQuery}
	)
"
);
			}

			return result.ToString();
        }

        #endregion Public methods
    }
}
