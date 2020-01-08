//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Logout;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Получение. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutGetInput : ModIdentityServerWebMvcPartAccountCommonJobLogoutInput
    {
        #region Properties

        /// <summary>
        /// Идентификатор выхода из системы.
        /// </summary>
        public string LogoutId { get; set; }

        #endregion Properties
    }
}
