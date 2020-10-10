//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Core.Data.Clients.PostgreSql
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Контекст.
    /// </summary>
    public class CoreDataClientPostgreSqlContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public ICoreBaseDataProvider Provider { get; private set; } = new CoreDataClientPostgreSqlProvider();

        #endregion Properties
    }
}
