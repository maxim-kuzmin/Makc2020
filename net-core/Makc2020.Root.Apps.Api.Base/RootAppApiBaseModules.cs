//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Data.Base;
using Makc2020.Data.Entity.Db;
using Makc2020.Mods.Auth.Base;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Successes;
using Makc2020.Mods.DummyMain.Base;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using Makc2020.Mods.DummyTree.Base;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using Makc2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Модули.
    /// </summary>
    public class RootAppApiBaseModules : RootBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "Auth". Основа.
        /// </summary>
        public ModAuthBaseModule ModAuthBase { get; set; }

        /// <summary>
        /// Мод "DummyMain". Основа.
        /// </summary>
        public ModDummyMainBaseModule ModDummyMainBase { get; set; }

        /// <summary>
        /// Мод "DummyTree". Основа.
        /// </summary>
        public ModDummyTreeBaseModule ModDummyTreeBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootAppApiBaseModules(IEnumerable<ICoreBaseCommonModule> commonModules)
            : base(commonModules)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ModAuthBase?.ConfigureServices(services);
            ModDummyMainBase?.ConfigureServices(services);
            ModDummyTreeBase?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            ModAuthBase?.InitConfig(environment);
            ModDummyMainBase?.InitConfig(environment);
            ModDummyTreeBase?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            ModAuthBase?.InitContext(new ModAuthBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                ResourceErrorsLocalizer = GetLocalizer<ModAuthBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModAuthBaseResourceSuccesses>(serviceProvider)
            });

            ModDummyMainBase?.InitContext(new ModDummyMainBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                CoreBaseDataProvider = GetProviderForDataClient(),
                DataBaseSettings = GetSettingsForDataClient(),
                DataEntityDbFactory = GetDbFactoryForDataClient(),
                ResourceErrorsLocalizer = GetLocalizer<ModDummyMainBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModDummyMainBaseResourceSuccesses>(serviceProvider)
            });

            ModDummyTreeBase?.InitContext(new ModDummyTreeBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                CoreBaseDataProvider = GetProviderForDataClient(),
                DataBaseSettings = GetSettingsForDataClient(),
                DataEntityDbFactory = GetDbFactoryForDataClient(),
                ResourceErrorsLocalizer = GetLocalizer<ModDummyTreeBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModDummyTreeBaseResourceSuccesses>(serviceProvider)
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            base.TrySetModule(commonModule);

            if (TrySet<ModAuthBaseModule>(x => ModAuthBase = x, commonModule)) return true;
            if (TrySet<ModDummyMainBaseModule>(x => ModDummyMainBase = x, commonModule)) return true;
            if (TrySet<ModDummyTreeBaseModule>(x => ModDummyTreeBase = x, commonModule)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
