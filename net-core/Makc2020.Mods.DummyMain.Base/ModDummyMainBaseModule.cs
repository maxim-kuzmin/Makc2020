//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Модуль.
    /// </summary>
    public class ModDummyMainBaseModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyMainBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModDummyMainBaseContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).Jobs.JobFilteredGet);
            services.AddTransient(x => GetContext(x).Jobs.JobItemDelete);
            services.AddTransient(x => GetContext(x).Jobs.JobItemGet);
            services.AddTransient(x => GetContext(x).Jobs.JobItemInsert);
            services.AddTransient(x => GetContext(x).Jobs.JobItemUpdate);
            services.AddTransient(x => GetContext(x).Jobs.JobListDelete);
            services.AddTransient(x => GetContext(x).Jobs.JobListGet);
            services.AddTransient(x => GetContext(x).Jobs.JobOptionsDummyManyToManyGet);
            services.AddTransient(x => GetContext(x).Jobs.JobOptionsDummyOneToManyGet);
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
            Config = new ModDummyMainBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModDummyMainBaseExternals externals)
        {
            Context = new ModDummyMainBaseContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModDummyMainBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModDummyMainBaseContext>();
        }

        #endregion Private methods
    }
}