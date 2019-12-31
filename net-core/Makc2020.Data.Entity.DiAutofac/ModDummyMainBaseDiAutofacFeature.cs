//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Data.Entity.DiAutofac
{
    /// <summary>
    /// Мод "DummyMain". Основа. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class DataEntityDiAutofacFeature : DataEntityFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataEntityDiAutofacModule());
        }

        #endregion Public methods
    }
}