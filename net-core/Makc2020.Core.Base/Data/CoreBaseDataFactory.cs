//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Tree.Calculate;
using Makc2020.Core.Base.Data.Queries.Tree.Trigger;

namespace Makc2020.Core.Base.Data
{
    /// <summary>
    /// Ядро. Основа. Данные. Фабрика.
    /// </summary>
    public abstract class CoreBaseDataFactory
    {
        #region Properties

        /// <summary>
        /// Создать построитель запроса вычисления дерева.
        /// </summary>
        public abstract CoreBaseDataQueryTreeCalculateBuilder CreateQueryTreeCalculateBuilder();

        /// <summary>
        /// Создать построитель запроса триггера дерева.
        /// </summary>
        public abstract CoreBaseDataQueryTreeTriggerBuilder CreateQueryTreeTriggerBuilder();

        #endregion Properties
    }
}
