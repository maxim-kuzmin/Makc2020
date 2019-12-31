//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Base;

namespace Makc2020.Data.Entity.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Внешнее.
    /// </summary>
    public class DataEntitySqlServerExternals
    {
        #region Properties

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        public DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        public CoreBaseEnvironment Environment { get; set; }

        #endregion Properties
    }
}
