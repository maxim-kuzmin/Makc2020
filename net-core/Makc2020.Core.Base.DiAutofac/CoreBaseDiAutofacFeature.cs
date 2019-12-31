//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Core.Base.DiAutofac
{
    /// <summary>
    /// Ядро. Основа. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class CoreBaseDiAutofacFeature : CoreBaseFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreBaseDiAutofacModule());
        }

        #endregion Public methods
    }
}