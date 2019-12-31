//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Mods.Auth.Base.DiAutofac
{
    /// <summary>
    /// Мод "Auth". Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class ModAuthBaseDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            //Register//ModAuthBaseConfig//

            builder.Register(x => ResolveContext(x).Config).AsSelf();

            //Register//Config//IModAuthBaseConfigSettings//

            builder.Register(x => ResolveContext(x).Config.Settings).AsSelf();

            //Register//Job//ModAuthBaseJobLoginJwtService//

            builder.Register(x => ResolveContext(x).Jobs.JobLoginJwt).AsSelf();

            //Register//Job//ModAuthBaseJobRefreshJwtService//

            builder.Register(x => ResolveContext(x).Jobs.JobRefreshJwt).AsSelf();

            //Register//Job//ModAuthBaseJobRegisterService//

            builder.Register(x => ResolveContext(x).Jobs.JobRegister).AsSelf();

            //Register//Resource//ModAuthBaseResourceErrors//

            builder.Register(x => ResolveContext(x).Resources.Errors).AsSelf();

            //Register//Resource//ModAuthBaseResourceSuccesses//

            builder.Register(x => ResolveContext(x).Resources.Successes).AsSelf();

            //Register//ModAuthBaseService//

            builder.Register(x => ResolveContext(x).Service).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private ModAuthBaseContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<ModAuthBaseContext>();
        }

        #endregion Private methods
    }
}