//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Microsoft.AspNetCore.Http;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Получение. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginGetInput : ModIdentityServerWebMvcPartAccountCommonJobLoginInput
    {
        #region Properties

        /// <summary>
        /// HTTP-запрос.
        /// </summary>
        public HttpRequest HttpRequest { get; set; }

        /// <summary>
        /// Признак первого входа в систему.
        /// </summary>
        public bool? IsFirstLogin { get; set; }

        /// <summary>
        /// Ключ языка.
        /// </summary>
        public string LanguageKey { get; set; }

        /// <summary>
        /// URL возврата.
        /// </summary>
        public string ReturnUrl { get; set; }

        #endregion Properties
    }
}