//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Модуль.
    /// </summary>
    public class CoreCachingModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public CoreCachingConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreCachingContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Cache);
            services.AddTransient(x => GetContext(x).Config);
            services.AddTransient(x => GetContext(x).Config.Settings);
            services.AddTransient(x => GetContext(x).Resources.Errors);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new CoreCachingConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(CoreCachingExternals externals)
        {
            Context = new CoreCachingContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private CoreCachingContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CoreCachingContext>();
        }

        #endregion Private methods
    }
}