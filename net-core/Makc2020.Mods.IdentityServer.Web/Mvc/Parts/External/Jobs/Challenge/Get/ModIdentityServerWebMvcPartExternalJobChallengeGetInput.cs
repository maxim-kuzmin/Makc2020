//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Задания. Вызов. Получение. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalJobChallengeGetInput
    {
        #region Properties

        /// <summary>
        /// HTTP-контекст.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Взаимодействие.
        /// </summary>
        public IIdentityServerInteractionService Interaction { get; set; }

        /// <summary>
        /// Поставщик.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// URL перенаправления.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// URL возврата.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartExternalJobChallengeGetEnumStatuses Status { get; set; }

        /// <summary>
        /// Помощник URL.
        /// </summary>
        public IUrlHelper UrlHelper { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (HttpContext == null)
            {
                result.Add(nameof(HttpContext));
            }

            if (Interaction == null)
            {
                result.Add(nameof(Interaction));
            }

            if (UrlHelper == null)
            {
                result.Add(nameof(UrlHelper));
            }

            return result;
        }

        #endregion Public methods
    }
}
