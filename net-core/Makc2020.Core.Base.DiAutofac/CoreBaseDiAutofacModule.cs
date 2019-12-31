//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Core.Base.Auth;
using System.Security.Principal;

namespace Makc2020.Core.Base.DiAutofac
{
    /// <summary>
    /// Ядро. Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class CoreBaseDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            //Register//IPrincipal//

            builder.Register(x => new CoreBaseAuthNullPrincipal()).As<IPrincipal>();

            //Register//Resource//CoreBaseResourceConverting//

            builder.Register(x => ResolveContext(x).Resources.Converting).AsSelf();

            //Register//Resource//CoreBaseResourceErrors//

            builder.Register(x => ResolveContext(x).Resources.Errors).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private CoreBaseContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<CoreBaseContext>();
        }

        #endregion Private methods
    }
}
