//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Root.Apps.Api.Base;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Модуль.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public abstract class RootAppApiWebModule<TContext, TFeatures> :
        RootAppApiBaseModule<TContext, TFeatures>
        where TContext : RootAppApiWebContext<TFeatures>
        where TFeatures : RootAppApiWebFeatures
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Register//FeatureContext//CoreCachingContext//

            builder.Register(x => ResolveContext(x).CoreCaching).AsSelf();

            //Register//FeatureContext//CoreWebContext//

            builder.Register(x => ResolveContext(x).CoreWeb).AsSelf();

            //Register//FeatureContext//ModDummyMainCachingContext//

            builder.Register(x => ResolveContext(x).ModDummyMainCaching).AsSelf();
        }

        #endregion Protected methods
    }
}