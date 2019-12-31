//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Core.Caching.DiAutofac
{
    /// <summary>
    /// Ядро. Кэширование. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class CoreCachingDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void Load(ContainerBuilder builder)
        {
            //Register//ICoreCachingCache//

            builder.Register(x => ResolveContext(x).Cache).AsSelf();

            //Register//CoreCachingConfig//

            builder.Register(x => ResolveContext(x).Config).AsSelf();

            //Register//Config//ICoreCachingConfigSettings//

            builder.Register(x => ResolveContext(x).Config.Settings).AsSelf();

            //Register//Resource//CoreCachingResourceErrors//

            builder.Register(x => ResolveContext(x).Resources.Errors).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private CoreCachingContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<CoreCachingContext>();
        }

        #endregion Private methods
    }
}