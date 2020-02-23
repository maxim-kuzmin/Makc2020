//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Resources.Titles;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Получение. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutGetOutput : ModIdentityServerWebMvcPartAccountViewLogoutModel
    {
        #region Properties

        /// <summary>
        /// Признак необходимости показать предупреждение о выходе из системы.
        /// </summary>
        public bool ShowLogoutPrompt { get; set; } = true;

        /// <summary>
        /// Заголовок страницы.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Заголовок подтверждения.
        /// </summary>
        public string ConfirmTitle { get; set; }

        /// <summary>
        /// Заголовок вопроса к подтверждению выхода из системы.
        /// </summary>
        public string LogoutQuestionTitle { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitles">Ресурс заголовков.</param>
        public ModIdentityServerWebMvcPartAccountJobLogoutGetOutput(ModIdentityServerBaseResourceTitles resourceTitles)
        {
            PageTitle = resourceTitles.GetStringLogout();
            ConfirmTitle = resourceTitles.GetStringYes();
            LogoutQuestionTitle = resourceTitles.GetStringLogoutQuestion();
        }

        #endregion Constructors
    }
}
