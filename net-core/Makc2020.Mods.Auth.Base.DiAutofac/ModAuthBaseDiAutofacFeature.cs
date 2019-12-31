//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Mods.Auth.Base.DiAutofac
{
    /// <summary>
    /// Мод "Auth". Основа. Внедрение зависимостей. Autofac. Функциональность.
    /// </summary>
    public class ModAuthBaseDiAutofacFeature : ModAuthBaseFeature
    {
        #region Public methods

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModAuthBaseDiAutofacModule());
        }

        #endregion Public methods
    }
}