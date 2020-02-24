//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process.Enums;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Обработка. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput
    {
        #region Properties

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostProcessEnumStatuses Status { get; set; } =
            ModIdentityServerWebMvcPartAccountJobLogoutPostProcessEnumStatuses.Default;

        #endregion Properties
    }
}
