//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Identity.Reseed;
using System.Text;

namespace Makc2020.Core.Data.Clients.SqlServer.Queries.Identity.Reseed
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Запросы. Идентичность. Перезаполнение. Построитель.
    /// </summary>
    public class CoreDataClientSqlServerQueryIdentityReseedBuilder : CoreBaseDataQueryIdentityReseedBuilder
	{
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
			var result = new StringBuilder();

            foreach (var table in Tables)
            {
                result.Append($@"
DBCC CHECKIDENT ('{table}', RESEED, 0);
");
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
