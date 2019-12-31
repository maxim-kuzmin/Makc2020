//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Host.Base.DiAutofac
{
    /// <summary>
    /// Хост. Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class HostBaseDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Register//HostBaseConfig//

            builder.Register(x => ResolveContext(x).Config).AsSelf();

            //Register//Config//IHostBaseConfigSettings//

            builder.Register(x => ResolveContext(x).Config.Settings).AsSelf();

            //Register//Part//Auth//Job//HostBasePartAuthJobCurrentUserGetService//

            builder.Register(x => ResolveContext(x).PartAuth.Jobs.JobCurrentUserGet).AsSelf();

            //Register//Part//Auth//Job//HostBasePartAuthJobSeedService//

            builder.Register(x => ResolveContext(x).PartAuth.Jobs.JobSeed).AsSelf();

            //Register//Part//Auth//Job//HostBasePartAuthJobUserCreateService//

            builder.Register(x => ResolveContext(x).PartAuth.Jobs.JobUserEntityCreate).AsSelf();

            //Register//Part//Auth//Resource//HostBasePartAuthResourceErrors//

            builder.Register(x => ResolveContext(x).PartAuth.Resources.Errors).AsSelf();

            //Register//Part//Auth//Resource//HostBasePartAuthResourceSuccesses//

            builder.Register(x => ResolveContext(x).PartAuth.Resources.Successes).AsSelf();

            //Register//Part//Auth//HostBasePartAuthService//

            builder.Register(x => ResolveContext(x).PartAuth.Service).AsSelf();

            //Register//Part//Ldap//Job//HostBasePartLdapJobLoginService//

            builder.Register(x => ResolveContext(x).PartLdap.Jobs.JobLogin).AsSelf();

            //Register//Part//Ldap//Resource//HostBasePartLdapResourceErrors//

            builder.Register(x => ResolveContext(x).PartLdap.Resources.Errors).AsSelf();

            //Register//Part//Ldap//Resource//HostBasePartLdapResourceSuccesses//

            builder.Register(x => ResolveContext(x).PartLdap.Resources.Successes).AsSelf();

            //Register//Part//Ldap//HostBasePartLdapService//

            builder.Register(x => ResolveContext(x).PartLdap.Service).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private HostBaseContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<HostBaseContext>();
        }

        #endregion Private methods
    }
}