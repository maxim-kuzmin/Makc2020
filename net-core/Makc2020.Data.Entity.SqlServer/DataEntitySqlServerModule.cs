//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Data.Entity.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Модуль.
    /// </summary>
    public class DataEntitySqlServerModule : ICoreBaseCommonModule
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
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Config);
            services.AddTransient(x => GetContext(x).Config.Settings);
            services.AddTransient(x => GetContext(x).DbFactory);
        }

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

        #region Private methods

        private DataEntitySqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<DataEntitySqlServerContext>();
        }

        #endregion Private methods
    }
}