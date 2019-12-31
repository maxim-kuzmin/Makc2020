//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Root.Base.DiAutofac;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Модуль.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public abstract class RootAppApiBaseModule<TContext, TFeatures> : RootBaseDiAutofacModule<TContext, TFeatures>
        where TContext : RootAppApiBaseContext<TFeatures>
        where TFeatures : RootAppApiBaseFeatures
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Register//FeatureContext//ModAuthBaseContext//

            builder.Register(x => ResolveContext(x).ModAuthBase).AsSelf();

            //Register//FeatureContext//ModDummyMainBaseContext//

            builder.Register(x => ResolveContext(x).ModDummyMainBase).AsSelf();
        }

        #endregion Protected methods
    }
}