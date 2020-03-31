//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Core.Data.Clients.SqlServer
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Контекст.
    /// </summary>
    public class CoreDataClientSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Фабрика.
        /// </summary>
        public CoreDataClientSqlServerFactory Factory { get; private set; } = new CoreDataClientSqlServerFactory();

        /// <summary>
        /// Поставщик.
        /// </summary>
        public ICoreBaseDataProvider Provider { get; private set; } = new CoreDataClientSqlServerProvider();

        #endregion Properties
    }
}
