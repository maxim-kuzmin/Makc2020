//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Authentication;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Задания. Вызов. Получение. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalJobChallengeGetOutput
    {
        #region Properties

        /// <summary>
        /// Свойства аутентификации.
        /// We will issue the external cookie and then redirect the
        /// user back to the external callback, in essence, treating windows
        /// auth the same as any other external authentication mechanism.
        /// 
        /// </summary>
        public AuthenticationProperties AuthenticationProperties { get; set; }

        #endregion Properties
    }
}
