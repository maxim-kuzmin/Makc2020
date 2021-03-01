//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Core.Data.Base.Clients.SqlServer
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. SQL Server. Модуль.
    /// </summary>
    public class CoreDataBaseClientSqlServerModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreDataBaseClientSqlServerContext Context { get; private set; } = new CoreDataBaseClientSqlServerContext();

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

        private CoreDataBaseClientSqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreDataBaseClientSqlServerContext>();
        }

        #endregion Private methods
    }
}