//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Enums;
using Makc2020.Mods.IdentityServer.Base.Resources.Titles;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        /// Варианты способов входа в систему.
        /// </summary>
        public IEnumerable<SelectListItem> LoginMethodSelectListItems { get; set; }

        /// <summary>
        /// Заголовок способа входа в систему.
        /// </summary>
        public string LoginMethodTitle { get; set; }

        public bool AllowRememberLogin { get; set; } = true;

        public bool EnableLocalLogin { get; set; } = true;

        public IEnumerable<ModIdentityServerWebMvcPartAccountExternalProvider> ExternalProviders { get; set; } =
            Enumerable.Empty<ModIdentityServerWebMvcPartAccountExternalProvider>();

        public IEnumerable<ModIdentityServerWebMvcPartAccountExternalProvider> VisibleExternalProviders =>
            ExternalProviders.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;

        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitles">Ресурсы заголовков.</param>
        /// <param name="loginMethod">Способ входа в систему.</param>
        public ModIdentityServerWebMvcPartAccountCommonJobLoginOutput(
            ModIdentityServerBaseResourceTitles resourceTitles,
            ModIdentityServerBaseEnumLoginMethods loginMethod
            )
        {
            LoginMethod = loginMethod;

            LoginMethodSelectListItems = new[]
            {
                new SelectListItem(
                    resourceTitles.GetStringLoginMethodWindows(),
                    ModIdentityServerBaseEnumLoginMethods.Windows.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.Windows
                    ),
                new SelectListItem(
                    resourceTitles.GetStringLoginMethodLocal(),
                    ModIdentityServerBaseEnumLoginMethods.Local.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.Local
                    ),
                new SelectListItem(
                    resourceTitles.GetStringLoginMethodLdap(),
                    ModIdentityServerBaseEnumLoginMethods.Ldap.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.Ldap
                    )
            };

            LoginMethodTitle = resourceTitles.GetStringLoginMethod();
        }

        #endregion Constructors
    }
}
