//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;

namespace Makc2020.Data.Entity.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Функциональность.
    /// </summary>
    public class DataEntitySqlServerFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public DataEntitySqlServerConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataEntitySqlServerContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new DataEntitySqlServerConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(DataEntitySqlServerExternals externals)
        {
            Context = new DataEntitySqlServerContext(Config, externals);
        }

        #endregion Public methods
    }
}