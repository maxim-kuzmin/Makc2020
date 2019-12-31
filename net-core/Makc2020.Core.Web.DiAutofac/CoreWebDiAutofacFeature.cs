//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Core.Web.DiAutofac
{
    /// <summary>
    /// Ядро. Веб. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class CoreWebDiAutofacFeature : CoreWebFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreWebDiAutofacModule());
        }

        #endregion Public methods
    }
}