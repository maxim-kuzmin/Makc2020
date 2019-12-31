//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Data.Entity.SqlServer.DiAutofac
{
    /// <summary>
    /// Данные. Entity Framework. SQL Server. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class DataEntitySqlServerDiAutofacFeature : DataEntitySqlServerFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataEntitySqlServerDiAutofacModule());
        }

        #endregion Public methods
    }
}