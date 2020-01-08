//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Config
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModIdentityServerWebMvcConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Account".
        /// </summary>
        IModIdentityServerWebMvcPartAccountConfigSettings PartAccount { get; }

        #endregion Properties
    }
}