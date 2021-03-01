//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Core.Data.Base.Clients.SqlServer
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. SQL Server. Контекст.
    /// </summary>
    public class CoreDataBaseClientSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public ICoreBaseDataProvider Provider { get; private set; } = new CoreDataBaseClientSqlServerProvider();

        #endregion Properties
    }
}
