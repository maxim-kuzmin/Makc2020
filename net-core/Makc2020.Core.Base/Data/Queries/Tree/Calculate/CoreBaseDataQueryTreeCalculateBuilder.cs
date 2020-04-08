//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Data.Queries.Tree;

namespace Makc2020.Core.Base.Data.Queries.Tree.Calculate
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Вычисление. Построитель.
    /// </summary>
    public abstract class CoreBaseDataQueryTreeCalculateBuilder : CoreBaseCommonDataQueryTreeBuilder
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public CoreBaseDataQueryTreeCalculateBuilder()
        {
            Prefix = "TreeCalculate_";
        }

        #endregion Constructors
    }
}
