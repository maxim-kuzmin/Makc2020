//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Data.Entity.DiAutofac
{
    /// <summary>
    /// Мод "DummyMain". Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class DataEntityDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            //Register//Job//DataEntityJobDatabaseMigrateService//

            builder.Register(x => ResolveContext(x).Jobs.JobDatabaseMigrate).AsSelf();

            //Register//DataEntityService//

            builder.Register(x => ResolveContext(x).Service).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private DataEntityContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<DataEntityContext>();
        }

        #endregion Private methods
    }
}