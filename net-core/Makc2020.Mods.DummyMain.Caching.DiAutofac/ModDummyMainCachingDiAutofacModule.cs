//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Mods.DummyMain.Caching.DiAutofac
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class ModDummyMainCachingDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void Load(ContainerBuilder builder)
        {
            //Register//ModDummyMainCachingConfig//

            builder.Register(x => ResolveContext(x).Config).AsSelf();

            //Register//Config//ICoreCachingCommonClientConfigSettings//

            builder.Register(x => ResolveContext(x).Config.Settings).AsSelf();

            //Register//Job//ModDummyMainCachingJobItemDeleteService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemDelete).AsSelf();

            //Register//Job//ModDummyMainCachingJobItemGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemGet).AsSelf();

            //Register//Job//ModDummyMainCachingJobItemInsertService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemInsert).AsSelf();

            //Register//Job//ModDummyMainCachingJobItemUpdateService//

            builder.Register(x => ResolveContext(x).Jobs.JobItemUpdate).AsSelf();

            //Register//Job//ModDummyMainCachingJobListGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobListGet).AsSelf();

            //Register//Job//ModDummyMainCachingJobOptionsDummyManyToManyGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobOptionsDummyManyToManyGet).AsSelf();

            //Register//Job//ModDummyMainCachingJobOptionsDummyOneToManyGetService//

            builder.Register(x => ResolveContext(x).Jobs.JobOptionsDummyOneToManyGet).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private ModDummyMainCachingContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<ModDummyMainCachingContext>();
        }

        #endregion Private methods
    }
}