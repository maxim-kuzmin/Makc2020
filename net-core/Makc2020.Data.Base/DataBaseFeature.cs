//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Функциональность.
    /// </summary>
    public class DataBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataBaseContext Context { get; private set; } = new DataBaseContext();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Settings);
        }

        #endregion Public methods

        #region Private methods

        private DataBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<DataBaseContext>();
        }

        #endregion Private methods
    }
}