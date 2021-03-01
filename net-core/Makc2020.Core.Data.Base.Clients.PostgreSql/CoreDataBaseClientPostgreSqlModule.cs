//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Core.Data.Base.Clients.PostgreSql
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. PostgreSQL. Модуль.
    /// </summary>
    public class CoreDataBaseClientPostgreSqlModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreDataBaseClientPostgreSqlContext Context { get; private set; } = new CoreDataBaseClientPostgreSqlContext();

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

        private CoreDataBaseClientPostgreSqlContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreDataBaseClientPostgreSqlContext>();
        }

        #endregion Private methods
    }
}