//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process.Enums;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Обработка. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput
    {
        #region Properties

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses Status { get; set; } =
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default;

        #endregion Properties
    }
}
