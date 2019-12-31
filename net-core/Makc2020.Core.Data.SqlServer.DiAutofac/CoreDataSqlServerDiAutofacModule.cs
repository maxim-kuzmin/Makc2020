//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Core.Base.Data;

namespace Makc2020.Core.Data.SqlServer.DiAutofac
{
    /// <summary>
    /// Ядро. Основа. Внедрение зависимостей. Autofac. Данные. 
    /// Клиенты. Клиент баз данных SQL Server. Модуль.
    /// </summary>
    public class CoreDataSqlServerDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void Load(ContainerBuilder builder)
        {
            //Register//ICoreBaseDataProvider//

            builder.Register(x => ResolveContext(x).Provider).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private CoreDataSqlServerContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<CoreDataSqlServerContext>();
        }

        #endregion Private methods
    }
}
