//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Tree.Calculate;

namespace Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Calculate
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Запросы. Дерево. Вычисление. Построитель.
    /// </summary>
    public class CoreDataClientSqlServerQueryTreeCalculateBuilder : CoreBaseDataQueryTreeCalculateBuilder
    {
        #region Potected methods

        /// <inheritdoc/>
        protected sealed override string CreateSqlForCount(string fieldName, bool isDistinct)
        {
            var distinct = isDistinct ? "distinct " : string.Empty;

            return $"COUNT_BIG({distinct}{fieldName})";
        }

        #endregion Potected methods
    }
}
