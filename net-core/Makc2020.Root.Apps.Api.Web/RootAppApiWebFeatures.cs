//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.DiAutofac;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Core.Web;
using Makc2020.Core.Web.DiAutofac;
using Makc2020.Core.Web.Resources.Errors;
using Makc2020.Data.Caching;
using Makc2020.Mods.DummyMain.Caching;
using Makc2020.Mods.DummyMain.Caching.DiAutofac;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Caching.Memory;
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
        public CoreCachingDiAutofacFeature CoreCaching { get; set; }

        /// <summary>
        /// Ядро. Веб.
        /// </summary>
        public CoreWebDiAutofacFeature CoreWeb { get; set; }

        /// <summary>
        /// Мод "DummyMain". Кэширование.
        /// </summary>
        public ModDummyMainCachingDiAutofacFeature ModDummyMainCaching { get; set; }

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

            CoreWeb?.InitContext(new CoreWebExternals
            {
                ResourceErrorsLocalizer = GetLocalizer<CoreWebResourceErrors>(serviceProvider)
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
        public sealed override void RegisterModule(ContainerBuilder builder)
        {
            base.RegisterModule(builder);

            CoreCaching?.Register(builder);
            CoreWeb?.Register(builder);
            ModDummyMainCaching?.Register(builder);
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

            if (TrySet<CoreCachingDiAutofacFeature>(x => CoreCaching = x, feature)) return true;
            if (TrySet<CoreWebDiAutofacFeature>(x => CoreWeb = x, feature)) return true;
            if (TrySet<ModDummyMainCachingDiAutofacFeature>(x => ModDummyMainCaching = x, feature)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
