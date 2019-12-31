//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Mods.DummyMain.Base.DiAutofac
{
    /// <summary>
    /// Мод "DummyMain". Основа. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class ModDummyMainBaseDiAutofacFeature : ModDummyMainBaseFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModDummyMainBaseDiAutofacModule());
        }

        #endregion Public methods
    }
}