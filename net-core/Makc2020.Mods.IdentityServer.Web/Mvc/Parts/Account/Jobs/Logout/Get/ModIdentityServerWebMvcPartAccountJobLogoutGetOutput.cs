//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Получение. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutGetOutput : ModIdentityServerWebMvcPartAccountViewLogoutModel
    {
        #region Properties

        /// <summary>
        /// Признак необходимости показать предупреждение о выходе из системы.
        /// </summary>
        public bool ShowLogoutPrompt { get; set; } = true;

        #endregion Properties
    }
}
