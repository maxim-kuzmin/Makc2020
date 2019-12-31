//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Mods.DummyMain.Base.DiAutofac
{
    /// <summary>
    /// Мод "DummyMain". Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class ModDummyMainBaseDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            //Register//ModDummyMainBaseConfig//

            builder.Register(x => ResolveContext(x).Config).AsSelf();

            //Register//Config//IModDummyMainBaseConfigSettings//

            builder.Register(x => ResolveContext(x).Config.Settings).AsSelf();

            //Register//Job//ModDummyMainBaseJobItemDeleteService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemDelete).AsSelf();

            //Register//Job//ModDummyMainBaseJobItemGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemGet).AsSelf();

            //Register//Job//ModDummyMainBaseJobItemInsertService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemInsert).AsSelf();

            //Register//Job//ModDummyMainBaseJobItemUpdateService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemUpdate).AsSelf();

            //Register//Job//ModDummyMainBaseJobListGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobListGet).AsSelf();

            //Register//Job//ModDummyMainBaseJobOptionsDummyManyToManyGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobOptionsDummyManyToManyGet).AsSelf();

            //Register//Job//ModDummyMainBaseJobOptionsDummyOneToManyGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobOptionsDummyOneToManyGet).AsSelf();

            //Register//Resource//ModDummyMainBaseResourceErrors//

            builder.Register(x => ResolveContext(x).Resources.Errors).AsSelf();

            //Register//Resource//ModDummyMainBaseResourceSuccesses//

            builder.Register(x => ResolveContext(x).Resources.Successes).AsSelf();

            //Register//ModDummyMainBaseService//

            builder.Register(x => ResolveContext(x).Service).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private ModDummyMainBaseContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<ModDummyMainBaseContext>();
        }

        #endregion Private methods
    }
}