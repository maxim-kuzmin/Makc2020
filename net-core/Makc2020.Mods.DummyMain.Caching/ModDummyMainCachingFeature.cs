//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Функциональность.
    /// </summary>
    public class ModDummyMainCachingFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyMainCachingConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModDummyMainCachingContext Context { get; private set; }

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
            services.AddTransient(x => GetContext(x).Jobs.JobOptionsDummyManyToManyGet);
            services.AddTransient(x => GetContext(x).Jobs.JobOptionsDummyOneToManyGet);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModDummyMainCachingConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModDummyMainCachingExternals externals)
        {
            Context = new ModDummyMainCachingContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModDummyMainCachingContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModDummyMainCachingContext>();
        }

        #endregion Private methods
    }
}