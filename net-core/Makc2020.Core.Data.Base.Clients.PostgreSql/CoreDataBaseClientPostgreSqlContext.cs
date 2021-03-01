//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Core.Data.Base.Clients.PostgreSql
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. PostgreSQL. Контекст.
    /// </summary>
    public class CoreDataBaseClientPostgreSqlContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public ICoreBaseDataProvider Provider { get; private set; } = new CoreDataBaseClientPostgreSqlProvider();

        #endregion Properties
    }
}
