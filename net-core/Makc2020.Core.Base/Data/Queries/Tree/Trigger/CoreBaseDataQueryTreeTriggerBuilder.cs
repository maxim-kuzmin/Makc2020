//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Data.Queries.Tree;
using Makc2020.Core.Base.Common.Enums;

namespace Makc2020.Core.Base.Data.Queries.Tree.Trigger
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Триггер. Построитель.
    /// </summary>
    public abstract class CoreBaseDataQueryTreeTriggerBuilder : CoreBaseCommonDataQueryTreeBuilder
    {
        #region Properties

        /// <summary>
        /// Действие.
        /// </summary>
        public CoreBaseCommonEnumSqlTriggerActions Action { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public CoreBaseDataQueryTreeTriggerBuilder()
        {
            Prefix = "TreeTrigger_";
        }

        #endregion Constructors
    }
}
