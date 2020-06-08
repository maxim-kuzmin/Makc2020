//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Enums;
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
        /// Признак необходимости запомнить вход в систему.
        /// </summary>
        public bool AllowRememberLogin { get; set; } = true;

        /// <summary>
        /// Признак включения возможности входа в систему под локальной учётной записью.
        /// </summary>
        public bool EnableLocalLogin { get; set; } = true;

        /// <summary>
        /// Внешние поставщики.
        /// </summary>
        public IEnumerable<ModIdentityServerWebMvcPartAccountExternalProvider> ExternalProviders { get; set; } =
            Enumerable.Empty<ModIdentityServerWebMvcPartAccountExternalProvider>();

        /// <summary>
        /// Видимые внешние поставщики.
        /// </summary>
        public IEnumerable<ModIdentityServerWebMvcPartAccountExternalProvider> VisibleExternalProviders =>
            ExternalProviders.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName));

        /// <summary>
        /// Признак того, что для входа в систему доступен только единственный внешний поставщик.
        /// </summary>
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;

        /// <summary>
        /// Схема внешнего поставщика.
        /// </summary>
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;

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
            string textLocal,
            string textLdap,
            string textWindowsDomain
        )
        {
            return new[]
            {
                //new SelectListItem(
                //    textWindows,
                //    ModIdentityServerBaseEnumLoginMethods.WindowsMachine.ToString(),
                //    LoginMethod == ModIdentityServerBaseEnumLoginMethods.WindowsMachine
                //    ),
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
                new SelectListItem(
                    textWindowsDomain,
                    ModIdentityServerBaseEnumLoginMethods.WindowsDomain.ToString(),
                    LoginMethod == ModIdentityServerBaseEnumLoginMethods.WindowsDomain
                    )
            };
        }

        #endregion Public methods
    }
}
