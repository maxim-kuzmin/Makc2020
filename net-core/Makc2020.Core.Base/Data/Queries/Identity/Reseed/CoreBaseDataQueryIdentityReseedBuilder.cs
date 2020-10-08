//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Core.Base.Data.Queries.Identity.Reseed
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Идентичность. Перезаполнение. Построитель.
    /// </summary>
    public abstract class CoreBaseDataQueryIdentityReseedBuilder
    {
        #region Properties

        /// <summary>
        /// Таблицы.
        /// </summary>
        public List<CoreBaseDataQueryIdentityReseedInput> Inputs { get; private set; }
            = new List<CoreBaseDataQueryIdentityReseedInput>();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public abstract string GetResultSql();

        #endregion Public methods
    }
}
