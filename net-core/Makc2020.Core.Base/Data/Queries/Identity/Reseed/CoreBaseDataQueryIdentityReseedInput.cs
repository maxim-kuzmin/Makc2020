//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Core.Base.Data.Queries.Identity.Reseed
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Идентичность. Перезаполнение. Ввод.
    /// </summary>
    public class CoreBaseDataQueryIdentityReseedInput
    {
        #region Properties

        /// <summary>
        /// Имена столбцов.
        /// </summary>
        public IEnumerable<string> Columns { get; private set; }

        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public string Table { get; private set; }

        /// <summary>
        /// Схема.
        /// </summary>
        public string Schema { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public CoreBaseDataQueryIdentityReseedInput(
            string table,
            string schema,
            params string[] columns
            )
        {
            Table = table;
            Schema = schema;
            Columns = columns;
        }

        #endregion Constructors
    }
}
