//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Core.Web.DiAutofac
{
    /// <summary>
    /// Ядро. Веб. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class CoreWebDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            //Register//Resource//CoreWebResourceErrors//

            builder.Register(x => ResolveContext(x).Resources.Errors).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private CoreWebContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<CoreWebContext>();
        }

        #endregion Private methods
    }
}
