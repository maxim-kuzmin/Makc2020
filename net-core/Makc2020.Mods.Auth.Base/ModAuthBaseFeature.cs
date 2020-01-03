//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Функциональность.
    /// </summary>
    public class ModAuthBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModAuthBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModAuthBaseContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).Jobs.JobLoginJwt);
            services.AddTransient(x => GetContext(x).Jobs.JobRefreshJwt);
            services.AddTransient(x => GetContext(x).Jobs.JobRegister);
            services.AddTransient(x => GetContext(x).Resources.Errors);
            services.AddTransient(x => GetContext(x).Resources.Successes);
            services.AddTransient(x => GetContext(x).Service);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModAuthBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModAuthBaseExternals externals)
        {
            Context = new ModAuthBaseContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModAuthBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModAuthBaseContext>();
        }

        #endregion Private methods
    }
}