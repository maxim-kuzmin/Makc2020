//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Base.Data.Queries.Tree.Get
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Получение. Построитель.
    /// </summary>
    public class CoreBaseDataQueryTreeGetBuilder
    {
        #region Properties

        /// <summary>
        /// Ось.
        /// </summary>
        public CoreBaseCommonEnumTreeAxis Axis { get; set; }

        /// <summary>
        /// Имя поля таблицы связи для идентификатора родителя.
        /// </summary>
        public string LinkTableFieldNameForId { get; set; } = "Id";

        /// <summary>
        /// Псевдоним поля таблицы связи для уровня.
        /// </summary>
        public string LinkTableFieldAliasForLevel { get; set; } = "Level";

        /// <summary>
        /// Имя поля таблицы связи для уровня.
        /// </summary>
        public string LinkTableFieldNameForLevel { get; set; } = "Level";

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
        public CoreBaseDataQueryTreeGetParameters Parameters { get; private set; }
            = new CoreBaseDataQueryTreeGetParameters();

        /// <summary>
        /// Префикс.
        /// </summary>
        public string Prefix { get; set; } = "TreeGet_";


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

        /// <summary>
        /// Псевдонимы по именам полей таблицы дерева.
        /// </summary>
        public Dictionary<string, string> TreeTableFiealdAliasesByNames { get; private set; }
            = new Dictionary<string, string>();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public string GetResultSql()
        {
            var result = new StringBuilder("select ");

            if (TreeTableFiealdAliasesByNames.Any())
            {
                result.Append(
                    string.Join(", ", TreeTableFiealdAliasesByNames.Select(x => $"{Prefix}r.{x.Key} {x.Value}"))
                    );

                result.Append(", ");
            }
            
            result.Append($"{Prefix}k.{LinkTableFieldNameForLevel}");

            var aliasForLink = $"{Prefix}k";
            var aliasForResult = $"{Prefix}r";
            var aliasForTree = $"{Prefix}t";

            switch (Axis)
            {
                case CoreBaseCommonEnumTreeAxis.Ancestor:
                    result.Append(
$@"
 from {TreeTableName} {aliasForTree}
	inner join {LinkTableName} {aliasForLink}
        on {aliasForLink}.{LinkTableFieldNameForId} = {aliasForTree}.{TreeTableFieldNameForId}
	inner join {TreeTableName} {aliasForResult}
        on {aliasForResult}.{TreeTableFieldNameForId} = {aliasForLink}.{LinkTableFieldNameForParentId}
");
                    break;
                case CoreBaseCommonEnumTreeAxis.Child:
                    result.Append(
$@"
 from {TreeTableName} {aliasForTree}
    inner join {TreeTableName} {aliasForResult}
        on {aliasForResult}.{TreeTableFieldNameForParentId} = {aliasForTree}.{TreeTableFieldNameForId}
	inner join {LinkTableName} {aliasForLink}
        on {aliasForLink}.{LinkTableFieldNameForId} = {aliasForResult}.{TreeTableFieldNameForId}
            and {aliasForLink}.{LinkTableFieldNameForParentId} = 0
");
                    break;
                case CoreBaseCommonEnumTreeAxis.Descendant:
                    result.Append(
$@"
 from {TreeTableName} {aliasForTree}
	inner join {LinkTableName} {aliasForLink}
        on {aliasForLink}.{LinkTableFieldNameForParentId} = {aliasForTree}.{TreeTableFieldNameForId}
	inner join {TreeTableName} {aliasForResult}
        on {aliasForResult}.{TreeTableFieldNameForId} = {aliasForLink}.{LinkTableFieldNameForId}
");
                    break;
                case CoreBaseCommonEnumTreeAxis.Self:
                    result.Append(
$@"
from {TreeTableName} {aliasForResult}
	inner join {LinkTableName} {aliasForLink}
        on {aliasForLink}.{LinkTableFieldNameForId} = {aliasForResult}.{TreeTableFieldNameForId}
            and {aliasForLink}.{LinkTableFieldNameForParentId} = 0
");
                    break;
            }

            var parId = Parameters.Id;
            var parLevel = Parameters.Level;

            if (parId != null || parLevel != null)
            {
                result.Append("where ");

                var whereCaluseParts = new List<string>(2);

                if (parId != null)
                {
                    whereCaluseParts.Add($"{aliasForResult}.{TreeTableFieldNameForId} = {parId.ParameterName}");
                }

                if (parLevel != null)
                {
                    whereCaluseParts.Add($"{aliasForLink}.{LinkTableFieldNameForLevel} <= {parLevel.ParameterName}");
                }

                result.Append(string.Join("and ", whereCaluseParts));
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
