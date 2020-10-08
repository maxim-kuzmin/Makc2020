//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Queries.Identity.Reseed;
using System.Text;

namespace Makc2020.Core.Data.Clients.PostgreSql.Queries.Identity.Reseed
{
    /// <summary>
    /// Ядро. Данные. Клиенты. PostgreSQL. Запросы. Идентичность. Перезаполнение. Построитель.
    /// </summary>
    public class CoreDataClientPostgreSqlQueryIdentityReseedBuilder : CoreBaseDataQueryIdentityReseedBuilder
	{
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
			var result = new StringBuilder();

            foreach (var input in Inputs)
            {
                foreach (var column in input.Columns)
                {
                    result.Append($@"
SELECT setval(pg_get_serial_sequence('""{input.Schema}"".""{input.Table}""', '{column}'), 1);
");
                }
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
