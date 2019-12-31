//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Data.Base.DiAutofac
{
    /// <summary>
    /// Данные. Основа. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class DataBaseDiAutofacFeature : DataBaseFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataBaseDiAutofacModule());
        }

        #endregion Public methods
    }
}