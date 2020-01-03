//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Caching;
using Makc2020.Mods.DummyMain.Caching;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Функциональности.
    /// </summary>
    public class RootAppApiWebFeatures : RootAppApiBaseFeatures
    {
        #region Properties

        /// <summary>
        /// Ядро. Кэширование.
        /// </summary>
        public CoreCachingFeature CoreCaching { get; set; }

        /// <summary>
        /// Мод "DummyMain". Кэширование.
        /// </summary>
        public ModDummyMainCachingFeature ModDummyMainCaching { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonFeatures">Обобщённые функциональности.</param>
        public RootAppApiWebFeatures(IEnumerable<ICoreBaseCommonFeature> commonFeatures)
            : base(commonFeatures)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            CoreCaching?.ConfigureServices(services);
            ModDummyMainCaching?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public sealed override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            CoreCaching?.InitConfig(environment);
            ModDummyMainCaching?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public sealed override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            CoreCaching?.InitContext(new CoreCachingExternals
            {
                MemoryCacheOptions = new MemoryCacheOptions(),
                ResourceErrorsLocalizer = GetLocalizer<CoreCachingResourceErrors>(serviceProvider)
            });

            ModDummyMainCaching?.InitContext(new ModDummyMainCachingExternals
            {
                Cache = CoreCaching.Context.Cache,
                CoreBaseResourceErrors = CoreBase.Context.Resources.Errors,
                CoreCachingResourceErrors = CoreCaching.Context.Resources.Errors,
                DataBaseSettings = DataBase.Context.Settings,
                ResourceErrors = ModDummyMainBase.Context.Resources.Errors,
                ResourceSuccesses = ModDummyMainBase.Context.Resources.Successes,
                Service = ModDummyMainBase.Context.Service
            });
        }

        /// <inheritdoc/>
        public sealed override void OnAppStarted()
        {
            DataCachingSerialization.Init();
            ModDummyMainCachingSerialization.Init();
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override bool TrySetFeature(ICoreBaseCommonFeature feature)
        {
            if (base.TrySetFeature(feature)) return true;

            if (TrySet<CoreCachingFeature>(x => CoreCaching = x, feature)) return true;
            if (TrySet<ModDummyMainCachingFeature>(x => ModDummyMainCaching = x, feature)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
