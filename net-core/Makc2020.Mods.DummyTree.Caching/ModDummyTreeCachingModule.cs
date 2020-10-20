﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.DummyTree.Caching
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Модуль.
    /// </summary>
    public class ModDummyTreeCachingModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyTreeCachingConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModDummyTreeCachingContext Context { get; private set; }

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
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModDummyTreeCachingConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModDummyTreeCachingExternals externals)
        {
            Context = new ModDummyTreeCachingContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModDummyTreeCachingContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModDummyTreeCachingContext>();
        }

        #endregion Private methods
    }
}