//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Produce
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Получение. Создание отклика. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginGetProduceInput : ModIdentityServerWebMvcPartAccountCommonJobLoginInput
    {
        #region Properties

        /// <summary>
        /// URL возврата.
        /// </summary>
        public string ReturnUrl { get; set; }

        #endregion Properties
    }
}
