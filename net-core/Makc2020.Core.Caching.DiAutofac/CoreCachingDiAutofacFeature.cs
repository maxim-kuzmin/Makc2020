//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Core.Caching.DiAutofac
{
    /// <summary>
    /// Ядро. Кэширование. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class CoreCachingDiAutofacFeature : CoreCachingFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreCachingDiAutofacModule());
        }

        #endregion Public methods
    }
}