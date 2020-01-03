//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Функциональность.
    /// </summary>
    public class CoreWebFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreWebContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Resources.Errors);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(CoreWebExternals externals)
        {
            Context = new CoreWebContext(externals);
        }

        #endregion Public methods

        #region Private methods

        private CoreWebContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreWebContext>();
        }

        #endregion Private methods
    }
}