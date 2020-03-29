//Author Maxim Kuzmin//makc//

using System.Linq;
using System.Text;

namespace Makc2020.Data.Entity.Clients.SqlServer.Queries.Tree.Trigger
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Запросы. Дерево. Триггер. Построитель.
    /// </summary>
    public class DataEntityClientSqlServerQueryTreeTriggerBuilder
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
        public DataEntityClientSqlServerQueryTreeTriggerParameters Parameters { get; private set; }
            = new DataEntityClientSqlServerQueryTreeTriggerParameters();

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
            var result = new StringBuilder($@"
update {TreeTableName} r
set
	r.{TreeTableFieldNameForChildCount} =
		(
			select		
				COUNT_BIG(t.{TreeTableFieldNameForId})
			from
				{TreeTableName} t
			where
				t.{TreeTableFieldNameForParentId} = r.{TreeTableFieldNameForId} 
		),
	r.{TreeTableFieldNameForDescendantCount} =
		(
			select
				COUNT_BIG(distinct t.{TreeTableFieldNameForId})
			from
				{LinkTableName} k
				inner join {TreeTableName} t on t.{TreeTableFieldNameForId} = k.{LinkTableFieldNameForId}
			where
				k.{LinkTableFieldNameForParentId} = r.{TreeTableFieldNameForId}	
				and t.{TreeTableFieldNameForId} <> r.{TreeTableFieldNameForId}
		)
"
                );

            var parIds = Parameters.Ids;

            if (parIds.Any() || !string.IsNullOrWhiteSpace(IdsSelectQuery))
            {
                result.Append($"where r.{TreeTableFieldNameForId} in (");

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
    }
}
