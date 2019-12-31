//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;

namespace Makc2020.Core.Data.SqlServer
{
    /// <summary>
    /// Ядро. Данные. SQL Server. Функциональность.
    /// </summary>
    public abstract class CoreDataSqlServerFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreDataSqlServerContext Context { get; private set; } = new CoreDataSqlServerContext();

        #endregion Properties
    }
}