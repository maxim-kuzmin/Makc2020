//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Mods.DummyMain.Caching.DiAutofac
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class ModDummyMainCachingDiAutofacFeature : ModDummyMainCachingFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModDummyMainCachingDiAutofacModule());
        }

        #endregion Public methods
    }
}