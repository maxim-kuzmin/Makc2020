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

        /// <summary>
        /// Заголовок "Запомнить логин входа" в систему.
        /// </summary>
        public string RememberMyLoginTitle { get; set; }

        /// <summary>
        /// Заголовок страницы.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Заголовок имени пользователя.
        /// </summary>
        public string UsernameTitle { get; set; }

        /// <summary>
        /// Заголовок пароля.
        /// </summary>
        public string PasswordTitle { get; set; }

        /// <summary>
        /// Заголовок действия по входу в систему.
        /// </summary>
        public string LoginActionTitle { get; set; }

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
            RememberMyLoginTitle = resourceTitles.GetStringRememberMyLogin();
            PageTitle = resourceTitles.GetStringLogin();
            UsernameTitle = resourceTitles.GetStringUsername();
            PasswordTitle = resourceTitles.GetStringPassword();
            LoginActionTitle = resourceTitles.GetStringLoginAction();
        }

        #endregion Constructors
    }
}
