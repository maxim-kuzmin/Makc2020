//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Функциональность.
    /// </summary>
    public class HostBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public HostBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public HostBaseContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).PartAuth.Jobs.JobCurrentUserGet);
            services.AddTransient(x => GetContext(x).PartAuth.Jobs.JobSeed);
            services.AddTransient(x => GetContext(x).PartAuth.Jobs.JobUserEntityCreate);
            services.AddTransient(x => GetContext(x).PartAuth.Resources.Errors);
            services.AddTransient(x => GetContext(x).PartAuth.Resources.Successes);
            services.AddTransient(x => GetContext(x).PartAuth.Service);
            services.AddTransient(x => GetContext(x).PartLdap.Jobs.JobLogin);
            services.AddTransient(x => GetContext(x).PartLdap.Resources.Errors);
            services.AddTransient(x => GetContext(x).PartLdap.Resources.Successes);
            services.AddTransient(x => GetContext(x).PartLdap.Service);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new HostBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(HostBaseExternals externals)
        {
            Context = new HostBaseContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private HostBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<HostBaseContext>();
        }

        #endregion Private methods
    }
}