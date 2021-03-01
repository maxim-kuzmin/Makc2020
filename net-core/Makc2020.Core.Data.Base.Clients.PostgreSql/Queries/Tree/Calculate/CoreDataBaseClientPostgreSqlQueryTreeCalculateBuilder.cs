//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Tree.Calculate;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Data.Base.Clients.PostgreSql.Queries.Tree.Calculate
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. PostgreSQL. Запросы. Дерево. Вычисление. Построитель.
    /// </summary>
    public class CoreDataBaseClientPostgreSqlQueryTreeCalculateBuilder : CoreBaseDataQueryTreeCalculateBuilder
	{
		#region Public methods

		/// <inheritdoc/>
		public sealed override string GetResultSql()
		{
			var aliasForLink = $"\"{Prefix}k\"";
			var aliasForLink1 = $"\"{Prefix}k1\"";
			var aliasForLink2 = $"\"{Prefix}k2\"";
			var aliasForResult = $"\"{Prefix}r\"";
			var aliasForTree = $"\"{Prefix}t\"";

			var cte = "\"cte\"";

			var linkTableFieldNameForId = $"\"{LinkTableFieldNameForId}\"";
			var linkTableFieldNameForParentId = $"\"{LinkTableFieldNameForParentId}\"";

			var linkTableName = $"\"{LinkTableSchema}\".\"{LinkTableNameWithoutSchema}\"";
			
			var treeTableFieldNameForId = $"\"{TreeTableFieldNameForId}\"";
			var treeTableFieldNameForParentId = $"\"{TreeTableFieldNameForParentId}\"";
			var treeTableFieldNameForTreeChildCount = $"\"{TreeTableFieldNameForTreeChildCount}\"";
			var treeTableFieldNameForTreeDescendantCount = $"\"{TreeTableFieldNameForTreeDescendantCount}\"";
			var treeTableFieldNameForTreeLevel = $"\"{TreeTableFieldNameForTreeLevel}\"";
			var treeTableFieldNameForTreePath = $"\"{TreeTableFieldNameForTreePath}\"";
			var treeTableFieldNameForTreePosition = $"\"{TreeTableFieldNameForTreePosition}\"";
			var treeTableFieldNameForTreeSort = $"\"{TreeTableFieldNameForTreeSort}\"";

			var treeTableName = $"\"{TreeTableSchema}\".\"{TreeTableNameWithoutSchema}\"";

			var val = "\"val\"";

			var result = new StringBuilder($@"
do $$
begin
	loop
		with {cte} as
		(
			select
				{treeTableFieldNameForId},
				{treeTableFieldNameForParentId},
				{treeTableFieldNameForTreePosition}
			from
				{treeTableName}
			where
				{treeTableFieldNameForTreePosition} = 0
			limit 1
		)
		update {treeTableName} set
			{treeTableFieldNameForTreePosition} = 
			(
				select
					MAX({aliasForTree}.{treeTableFieldNameForTreePosition}) + 10
				from
					{treeTableName} {aliasForTree}
				where
					COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0) = COALESCE({cte}.{treeTableFieldNameForParentId}, 0)
			)
		from
			{cte}
		where
			{treeTableName}.{treeTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		;

		if not FOUND then
			exit;
		end if;
	end loop;

	with {cte} as
	(
		select
			{treeTableFieldNameForId},
			{treeTableFieldNameForTreeChildCount},
			{treeTableFieldNameForTreeDescendantCount},
			{treeTableFieldNameForTreeLevel},
			{treeTableFieldNameForTreePath},
			{treeTableFieldNameForTreeSort}
		from
			{treeTableName}
	)
	update {treeTableName} set
		{treeTableFieldNameForTreeChildCount} = 
		(
			select
				COUNT(*)
			from
				{treeTableName} {aliasForTree}
			where
				{aliasForTree}.{treeTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
		),
		{treeTableFieldNameForTreeDescendantCount} = 
		(
			select
				COUNT(*)
			from
				{linkTableName} {aliasForLink}
			where
				{aliasForLink}.{linkTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
				and
				{aliasForLink}.{linkTableFieldNameForParentId} <> {aliasForLink}.{linkTableFieldNameForId}
		),
		{treeTableFieldNameForTreeLevel} = 
		(
			select
				COUNT(*) - 1
			from
				{linkTableName} {aliasForLink}
			where
				{aliasForLink}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		),
		{treeTableFieldNameForTreePath} =
		(
			select
				COALESCE({aliasForResult}.{val}, '')
			from
			(
				select
					{aliasForLink1}.{linkTableFieldNameForId},
					(
						select
							STRING_AGG({aliasForLink2}.{linkTableFieldNameForParentId}::text, ',')
						from
							{linkTableName} {aliasForLink2}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} <> {aliasForLink2}.{linkTableFieldNameForId}
					) {val}
				from
					{linkTableName} {aliasForLink1}
				group by
					{aliasForLink1}.{linkTableFieldNameForId}
			) {aliasForResult}
			where
				{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		),
		{treeTableFieldNameForTreeSort} =
		(
			select
				COALESCE({aliasForResult}.{val}, '')
			from
			(
				select
					{aliasForLink1}.{linkTableFieldNameForId},
					(
						select
							STRING_AGG(RIGHT('0000000000' || {aliasForTree}.{treeTableFieldNameForTreePosition}::text || '.' || {aliasForLink2}.{linkTableFieldNameForParentId}::text, 10), ',')
						from
							{linkTableName} {aliasForLink2}
							inner join {treeTableName} {aliasForTree}
								on {aliasForLink2}.{linkTableFieldNameForParentId} = {aliasForTree}.{treeTableFieldNameForId}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
					) {val}
				from
					{linkTableName} {aliasForLink1}
				group by
					{aliasForLink1}.{linkTableFieldNameForId}
			) {aliasForResult}
			where
				{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		)
	from
		{cte}
	where
		{treeTableName}.{treeTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
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
		and
		{cte}.{treeTableFieldNameForId} in
		(
			{sqlForIdsSelectQuery}
		)
	;
");
				result.Append($@"
end $$;
");
			}

			return result.ToString();
		}

		#endregion Public methods
	}
}
