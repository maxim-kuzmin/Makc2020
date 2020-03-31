//Author Maxim Kuzmin//makc//

using System.Linq;
using System.Text;

namespace Makc2020.Core.Base.Data.Queries.Tree.Calculate
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Вычисление. Построитель.
    /// </summary>
    public abstract class CoreBaseDataQueryTreeCalculateBuilder
    {
        #region Properties

        /// <summary>
        /// Запрос выборки идентификаторов.
        /// </summary>
        public string IdsSelectQuery { get; set; }

        /// <summary>
        /// Имя поля таблицы связи для идентификатора родителя.
        /// </summary>
        public string LinkTableFieldNameForId { get; set; } = "Id";

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
        public CoreBaseDataQueryTreeCalculateParameters Parameters { get; private set; }
            = new CoreBaseDataQueryTreeCalculateParameters();

        /// <summary>
        /// Префикс.
        /// </summary>
        public string Prefix { get; set; } = "TreeCalculate_";

        /// <summary>
        /// Имя поля таблицы дерева для числа детей.
        /// </summary>
        public string TreeTableFieldNameForChildCount{ get; set; } = "ChildCount";

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
            var aliasForLink = $"{Prefix}k";
            var aliasForResult = $"{Prefix}r";
            var aliasForTree = $"{Prefix}t";

            var sqlForChildCount = CreateSqlForCount($"{aliasForTree}.{TreeTableFieldNameForId}", false);
            var sqlForDescendantCount = CreateSqlForCount($"{aliasForTree}.{TreeTableFieldNameForId}", true);

            var result = new StringBuilder($@"
update {TreeTableName} {aliasForResult}
set
	{aliasForResult}.{TreeTableFieldNameForChildCount} =
		(
			select		
				{sqlForChildCount}
			from
				{TreeTableName} {aliasForTree}
			where
				{aliasForTree}.{TreeTableFieldNameForParentId} = {aliasForResult}.{TreeTableFieldNameForId} 
		),
	{aliasForResult}.{TreeTableFieldNameForDescendantCount} =
		(
			select                
				{sqlForDescendantCount}
			from
				{LinkTableName} {aliasForLink}
				inner join {TreeTableName} {aliasForTree}
                    on {aliasForTree}.{TreeTableFieldNameForId} = {aliasForLink}.{LinkTableFieldNameForId}
			where
				{aliasForLink}.{LinkTableFieldNameForParentId} = {aliasForResult}.{TreeTableFieldNameForId}
				and {aliasForTree}.{TreeTableFieldNameForId} <> {aliasForResult}.{TreeTableFieldNameForId}
		)
");

            var parIds = Parameters.Ids;

            if (parIds.Any() || !string.IsNullOrWhiteSpace(IdsSelectQuery))
            {
                result.Append($"where {aliasForResult}.{TreeTableFieldNameForId} in (");

                if (parIds.Any())
                {
                    result.Append(string.Join(", ", parIds.Select(x => x.ParameterName)));
                }
                else
                {
                    result.Append(IdsSelectQuery);
                }

                result.Append(")");
            }

            return result.ToString();
        }

        #endregion Public methods

        #region Potected methods

        /// <summary>
        /// Создать SQL для подсчёта.
        /// </summary>
        /// <param name="fieldName">Имя поля.</param>
        /// <param name="isDistinct">Признак подсчёта только уникальных значений.</param>
        /// <returns></returns>
        protected abstract string CreateSqlForCount(string fieldName, bool isDistinct);

        #endregion Potected methods
    }
}
