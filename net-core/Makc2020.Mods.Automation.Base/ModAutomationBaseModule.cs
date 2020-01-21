//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Модуль.
    /// </summary>
    public class ModAutomationBaseModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModAutomationBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModAutomationBaseContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).PartAngular);
            services.AddTransient(x => GetContext(x).PartAngular.Jobs.JobCodeGenerate);
            services.AddTransient(x => GetContext(x).PartAngular.Service);
            services.AddTransient(x => GetContext(x).PartNetCore);
            services.AddTransient(x => GetContext(x).PartNetCore.Jobs.JobCodeGenerate);
            services.AddTransient(x => GetContext(x).PartNetCore.Service);
            services.AddTransient(x => GetContext(x).Resources.Errors);
            services.AddTransient(x => GetContext(x).Resources.Successes);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModAutomationBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModAutomationBaseExternals externals)
        {
            Context = new ModAutomationBaseContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModAutomationBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModAutomationBaseContext>();
        }

        #endregion Private methods
    }
}