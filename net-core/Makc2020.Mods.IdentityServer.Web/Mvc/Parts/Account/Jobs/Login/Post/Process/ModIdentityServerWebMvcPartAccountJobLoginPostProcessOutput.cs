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
        /// Имя куки для хранения метода входа в систему.
        /// </summary>
        public string LoginMethodCookieName { get; set; }

        /// <summary>
        /// Имя куки для хранения имени вошедшего в систему пользователя.
        /// </summary>
        public string LoginUserNameCookieName { get; set; }

        /// <summary>
        /// Длительность хранения информации о входе в систему в днях.
        /// </summary>
        public int RememberLoginDurationInDays { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses Status { get; set; } =
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default;

        #endregion Properties
    }
}
