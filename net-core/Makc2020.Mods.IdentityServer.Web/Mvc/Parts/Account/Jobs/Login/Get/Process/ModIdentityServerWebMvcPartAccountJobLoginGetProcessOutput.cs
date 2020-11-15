//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Получение. Обработка. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput
    {
        #region Properties

        /// <summary>
        /// Признак того, что необходимо пройти Windows-аутентификацию.
        /// </summary>
        public bool IsWindowsAuthenticationNeeded { get; set; }

        /// <summary>
        /// URL перенаправления.
        /// </summary>
        public string RedirectUrl { get; set; }

        #endregion Properties
    }
}
