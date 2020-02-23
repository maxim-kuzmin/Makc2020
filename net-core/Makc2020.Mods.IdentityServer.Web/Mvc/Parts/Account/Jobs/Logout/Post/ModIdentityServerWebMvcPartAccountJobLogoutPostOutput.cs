//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Resources.Titles;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.LoggedOut;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostOutput : ModIdentityServerWebMvcPartAccountViewLoggedOutModel
    {
        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitles">Ресурс заголовков.</param>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostOutput(ModIdentityServerBaseResourceTitles resourceTitles) :
            base(resourceTitles)
        {
        }

        #endregion Constructor
    }
}
