//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process.Enums
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Обработка. Перечисления. Статусы.
    /// </summary>
    public enum ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses
    {
        /// <summary>
        /// По-молчанию.
        /// </summary>
        Default,
        /// <summary>
        /// Начало.
        /// </summary>
        Index,
        /// <summary>
        /// Перенаправление.
        /// </summary>
        Redirect,
        /// <summary>
        /// Возврат.
        /// </summary>
        Return
    }
}
