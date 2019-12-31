//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Data.Entity.SqlServer.DiAutofac
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class DataEntitySqlServerDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Register//DataEntitySqlServerConfig//

            builder.Register(x => ResolveContext(x).Config).AsSelf();

            //Register//Config//IDataEntitySqlServerConfigSettings//

            builder.Register(x => ResolveContext(x).Config.Settings).AsSelf();

            //Register//DataEntityDbFactory//

            builder.Register(x => ResolveContext(x).DbFactory).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private DataEntitySqlServerContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<DataEntitySqlServerContext>();
        }

        #endregion Private methods
    }
}