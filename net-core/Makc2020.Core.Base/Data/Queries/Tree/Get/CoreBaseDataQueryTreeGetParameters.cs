//Author Maxim Kuzmin//makc//

using System.Data.Common;

namespace Makc2020.Core.Base.Data.Queries.Tree.Get
{
    /// <summary>
    /// Ядро. Основа. Данные. Запросы. Дерево. Получение. Параметры.
    /// </summary>
    public class CoreBaseDataQueryTreeGetParameters
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public DbParameter Id { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        public DbParameter Level { get; set; }

        #endregion Properties
    }
}
