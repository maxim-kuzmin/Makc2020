//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Data.Queries.Tree.Calculate;
using Makc2020.Core.Base.Data.Queries.Tree.Trigger;
using Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Calculate;
using Makc2020.Core.Data.Clients.SqlServer.Queries.Tree.Trigger;

namespace Makc2020.Core.Data.Clients.SqlServer
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Фабрика.
    /// </summary>
    public class CoreDataClientSqlServerFactory : CoreBaseDataFactory
    {
        #region Properties

        /// <inheritdoc/>
        public sealed override CoreBaseDataQueryTreeCalculateBuilder CreateQueryTreeCalculateBuilder()
        {
            return new CoreDataClientSqlServerQueryTreeCalculateBuilder();
        }

        /// <inheritdoc/>
        public sealed override CoreBaseDataQueryTreeTriggerBuilder CreateQueryTreeTriggerBuilder()
        {
            return new CoreDataClientSqlServerQueryTreeTriggerBuilder();
        }

        #endregion Properties
    }
}
