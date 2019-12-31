//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Core.Data.SqlServer.DiAutofac
{
    /// <summary>
    /// Ядро. Основа. Внедрение зависимостей. Autofac. Данные. Клиенты. 
    /// Клиент баз данных SQL Server. Функциональность.
    /// </summary>
    public class CoreDataSqlServerDiAutofacFeature : CoreDataSqlServerFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreDataSqlServerDiAutofacModule());
        }

        #endregion Public methods
    }
}