//Author Maxim Kuzmin//makc//

using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Makc2020.Mods.IdentityServer.Base.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Общее. Вход в систему. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountCommonJobLoginOutput : ModIdentityServerWebMvcPartAccountViewLoginModel
    {
        #region Properties

        /// <summary>
        /// URL перенаправления.
        /// </summary>
        public string RedirectUrl { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать элементы списка выбора метода входа в систему.
        /// </summary>
        /// <param name="textWindows">Текст для метода "Windows".</param>
        /// <param name="textLocal">Текст для метода "Local".</param>
        /// <param name="textLdap">Текст для метода "LDAP".</param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> CreateLoginMethodSelectListItems(
            //string textWindows,
            string textWindowsDomain,
            string textLocal,
            string textLdap
        )
        {
            return new[]
            {
                new SelectListItem(
                    textWindowsDomain,
                    ModIdentityServerBaseEnumLoginMethods.WindowsDomain.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.WindowsDomain
                    ),
                new SelectListItem(
                    textLocal,
                    ModIdentityServerBaseEnumLoginMethods.Local.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.Local
                    ),
                new SelectListItem(
                    textLdap,
                    ModIdentityServerBaseEnumLoginMethods.Ldap.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.Ldap
                    ),

            };
        }

        #endregion Public methods
    }
}
