//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Logout
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Общее. Выход из системы. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountCommonJobLogoutInput
    {
        #region Properties

        /// <summary>
        /// Взаимодействие.
        /// </summary>
        public IIdentityServerInteractionService Interaction { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public ClaimsPrincipal User { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (Interaction == null)
            {
                result.Add(nameof(Interaction));
            }

            return result;
        }

        #endregion Public methods
    }
}
