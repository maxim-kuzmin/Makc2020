//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Модуль.
    /// </summary>
    public class ModDummyTreeBaseModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyTreeBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModDummyTreeBaseContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).Jobs.JobItemDelete);
            services.AddTransient(x => GetContext(x).Jobs.JobItemGet);
            services.AddTransient(x => GetContext(x).Jobs.JobItemInsert);
            services.AddTransient(x => GetContext(x).Jobs.JobItemUpdate);
            services.AddTransient(x => GetContext(x).Jobs.JobListGet);
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
            Config = new ModDummyTreeBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModDummyTreeBaseExternals externals)
        {
            Context = new ModDummyTreeBaseContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModDummyTreeBaseContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModDummyTreeBaseContext>();
        }

        #endregion Private methods
    }
}