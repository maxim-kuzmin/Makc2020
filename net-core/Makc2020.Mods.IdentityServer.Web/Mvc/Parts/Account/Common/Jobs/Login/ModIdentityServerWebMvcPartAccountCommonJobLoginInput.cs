//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Общее. Вход в систему. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountCommonJobLoginInput
    {
        #region Properties

        /// <summary>
        /// Хранилище клиентов.
        /// </summary>
        public IClientStore СlientStore { get; set; }

        /// <summary>
        /// Взаимодействие.
        /// </summary>
        public IIdentityServerInteractionService Interaction { get; set; }

        /// <summary>
        /// Поставщик схем.
        /// </summary>
        public IAuthenticationSchemeProvider SchemeProvider { get; set; }

        /// <summary>
        /// HTTP-контекст.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (СlientStore == null)
            {
                result.Add(nameof(СlientStore));
            }

            if (Interaction == null)
            {
                result.Add(nameof(Interaction));
            }

            if (SchemeProvider == null)
            {
                result.Add(nameof(SchemeProvider));
            }

            return result;
        }

        #endregion Public methods
    }
}
