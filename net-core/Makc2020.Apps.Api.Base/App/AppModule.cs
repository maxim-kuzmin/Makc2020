//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Root.Apps.Api.Base;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Модуль.
    /// </summary>
    public class AppModule : RootAppApiBaseModule<AppContext, AppFeatures>
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Register//Context//RootContext//

            builder.Register(x => AppServer.Instance.GetContext()).AsSelf();
        }

        /// <inheritdoc/>
        protected sealed override AppContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<AppContext>();
        }

        #endregion Protected methods
    }
}