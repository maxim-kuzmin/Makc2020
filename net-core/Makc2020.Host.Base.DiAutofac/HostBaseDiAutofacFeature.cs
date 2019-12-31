//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Host.Base.DiAutofac
{
    /// <summary>
    /// Хост. Основа. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class HostBaseDiAutofacFeature : HostBaseFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new HostBaseDiAutofacModule());
        }

        #endregion Public methods
    }
}