//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Root.Base.DiAutofac
{
    /// <summary>
    /// Корень. Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public abstract class RootBaseDiAutofacModule<TContext, TFeatures> : Module
        where TContext : RootBaseDiAutofacContext<TFeatures>
        where TFeatures : RootBaseDiAutofacFeatures
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            //Register//FeatureContext//CoreBaseContext//

            builder.Register(x => ResolveContext(x).CoreBase).AsSelf();

            //Register//FeatureContext//DataBaseContext//

            builder.Register(x => ResolveContext(x).DataBase).AsSelf();

            //Register//FeatureContext//DataEntity//

            builder.Register(x => ResolveContext(x).DataEntity).AsSelf();

            //Register//FeatureContext//DataEntitySqlServerContext//

            builder.Register(x => ResolveContext(x).DataEntitySqlServer).AsSelf();

            //Register//FeatureContext//HostBaseContext//

            builder.Register(x => ResolveContext(x).HostBase).AsSelf();
        }

        /// <summary>
        /// Разрешить контекст.
        /// </summary>
        /// <param name="resolver">Распознаватель.</param>
        /// <returns>Контекст.</returns>
        protected abstract TContext ResolveContext(IComponentContext resolver);

        #endregion Protected methods
    }
}