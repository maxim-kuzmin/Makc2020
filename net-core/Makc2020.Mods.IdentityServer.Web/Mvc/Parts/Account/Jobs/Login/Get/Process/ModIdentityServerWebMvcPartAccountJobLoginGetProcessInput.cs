//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Получение. Обработка. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput
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
        /// URL возврата.
        /// </summary>
        public string ReturnUrl { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (HttpRequest == null)
            {
                result.Add(nameof(HttpRequest));
            }

            return result;
        }

        #endregion Public methods
    }
}
