//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makc2020.Data.Entity.Clients.SqlServer.Queries.Tree.Get
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Запросы. Дерево. Получение. Построитель.
    /// </summary>
    public class DataEntityClientSqlServerQueryTreeGetBuilder
    {
        #region Properties

        /// <summary>
        /// Ось.
        /// </summary>
        public CoreBaseCommonEnumAxis Axis { get; set; } = CoreBaseCommonEnumAxis.Descendant;

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
        public DataEntityClientSqlServerQueryTreeGetParameters Parameters { get; private set; }
            = new DataEntityClientSqlServerQueryTreeGetParameters();

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
                result.Append(string.Join(", ", TreeTableFiealdAliasesByNames.Select(x => $"r.{x.Key} {x.Value}")));

                result.Append(", ");
            }
            
            result.Append($"k.{LinkTableFieldNameForLevel}");

            switch (Axis)
            {
                case CoreBaseCommonEnumAxis.Ancestor:
                    result.Append(
$@"
 from {TreeTableName} t
	inner join {LinkTableName} k on k.{LinkTableFieldNameForId} = t.{TreeTableFieldNameForId}
	inner join {TreeTableName} r on r.{TreeTableFieldNameForId} = k.{LinkTableFieldNameForParentId}
"
                    );
                    break;
                case CoreBaseCommonEnumAxis.Child:
                    result.Append(
$@"
 from {TreeTableName} t
    inner join {TreeTableName} r on r.{TreeTableFieldNameForParentId} = t.{TreeTableFieldNameForId}
	inner join {LinkTableName} k on k.{LinkTableFieldNameForId} = r.{TreeTableFieldNameForId} and k.{LinkTableFieldNameForParentId} = 0
"
                    );
                    break;
                case CoreBaseCommonEnumAxis.Descendant:
                    result.Append(
$@"
 from {TreeTableName} t
	inner join {LinkTableName} k on k.{LinkTableFieldNameForParentId} = t.{TreeTableFieldNameForId}
	inner join {TreeTableName} r on r.{TreeTableFieldNameForId} = k.{LinkTableFieldNameForId}
"
                    );
                    break;
                case CoreBaseCommonEnumAxis.Self:
                    result.Append(
$@"
from {TreeTableName} r
	inner join {LinkTableName} k on k.{LinkTableFieldNameForId} = r.{TreeTableFieldNameForId} and k.{LinkTableFieldNameForParentId} = 0
"
                    );
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
                    whereCaluseParts.Add($"r.{TreeTableFieldNameForId} = {parId.ParameterName}");
                }

                if (parLevel != null)
                {
                    whereCaluseParts.Add($"k.{LinkTableFieldNameForLevel} <= {parLevel.ParameterName}");
                }

                result.Append(string.Join("and ", whereCaluseParts));
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
