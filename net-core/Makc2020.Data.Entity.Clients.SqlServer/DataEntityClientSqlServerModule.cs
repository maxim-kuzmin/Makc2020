//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Data.Entity.Clients.SqlServer
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Модуль.
    /// </summary>
    public class DataEntityClientSqlServerModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public DataEntityClientSqlServerConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataEntityClientSqlServerContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).Settings);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new DataEntityClientSqlServerConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(DataEntityClientSqlServerExternals externals)
        {
            Context = new DataEntityClientSqlServerContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityClientSqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<DataEntityClientSqlServerContext>();
        }

        #endregion Private methods
    }
}