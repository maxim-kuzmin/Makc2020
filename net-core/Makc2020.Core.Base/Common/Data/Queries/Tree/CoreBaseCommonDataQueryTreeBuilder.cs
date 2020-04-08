//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Core.Base.Common.Data.Queries.Tree
{
    /// <summary>
    /// Ядро. Основа. Общее. Данные. Запросы. Дерево. Построитель.
    /// </summary>
    public abstract class CoreBaseCommonDataQueryTreeBuilder
    {
        #region Properties

        /// <summary>
        /// Имя поля таблицы связи для идентификатора родителя.
        /// </summary>
        public string LinkTableFieldNameForId { get; set; } = CoreBaseDataSettings.FIELD_NAME_Id;

        /// <summary>
        /// Имя поля таблицы связи для идентификатора родителя.
        /// </summary>
        public string LinkTableFieldNameForParentId { get; set; } = CoreBaseDataSettings.FIELD_NAME_ParentId;

        /// <summary>
        /// Имя таблицы связи.
        /// </summary>
        public string LinkTableName { get; set; }

        /// <summary>
        /// Параметры.
        /// </summary>
        public CoreBaseCommonDataQueryTreeParameters Parameters { get; private set; }
            = new CoreBaseCommonDataQueryTreeParameters();

        /// <summary>
        /// Префикс.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// SQL для запроса выборки идентификаторов.
        /// </summary>
        public string SqlForIdsSelectQuery { get; set; }

        /// <summary>
        /// Имя поля таблицы дерева для идентификатора.
        /// </summary>
        public string TreeTableFieldNameForId { get; set; } = CoreBaseDataSettings.FIELD_NAME_Id;

        /// <summary>
        /// Имя поля таблицы дерева для идентификатора родителя.
        /// </summary>
        public string TreeTableFieldNameForParentId { get; set; } = CoreBaseDataSettings.FIELD_NAME_ParentId;

        /// <summary>
        /// Имя поля таблицы дерева для числа детей узла в дереве.
        /// </summary>
        public string TreeTableFieldNameForTreeChildCount { get; set; } = CoreBaseDataSettings.FIELD_NAME_TreeChildCount;

        /// <summary>
        /// Имя поля таблицы дерева для числа потомков узла в дереве.
        /// </summary>
        public string TreeTableFieldNameForTreeDescendantCount { get; set; } = CoreBaseDataSettings.FIELD_NAME_TreeDescendantCount;

        /// <summary>
        /// Имя поля таблицы дерева для уровня узла в дереве.
        /// </summary>
        public string TreeTableFieldNameForTreeLevel { get; set; } = CoreBaseDataSettings.FIELD_NAME_TreeLevel;

        /// <summary>
        /// Имя поля таблицы дерева для пути узла в дереве.
        /// </summary>
        public string TreeTableFieldNameForTreePath { get; set; } = CoreBaseDataSettings.FIELD_NAME_TreePath;

        /// <summary>
        /// Имя поля таблицы дерева для позиции узла в дереве.
        /// </summary>
        public string TreeTableFieldNameForTreePosition { get; set; } = CoreBaseDataSettings.FIELD_NAME_TreePosition;

        /// <summary>
        /// Имя поля таблицы дерева для сортировки узла в дереве.
        /// </summary>
        public string TreeTableFieldNameForTreeSort { get; set; } = CoreBaseDataSettings.FIELD_NAME_TreeSort;

        /// <summary>
        /// Имя таблицы дерева.
        /// </summary>
        public string TreeTableName { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public abstract string GetResultSql();

        #endregion Public methods
    }
}
