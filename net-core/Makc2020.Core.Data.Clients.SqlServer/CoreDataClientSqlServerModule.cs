//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Core.Data.Clients.SqlServer
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Модуль.
    /// </summary>
    public class CoreDataClientSqlServerModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreDataClientSqlServerContext Context { get; private set; } = new CoreDataClientSqlServerContext();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Provider);
        }

        #endregion Public methods

        #region Private methods

        private CoreDataClientSqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreDataClientSqlServerContext>();
        }

        #endregion Private methods
    }
}