//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Resources.Titles;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.LoggedOut;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Создание отклика. Вывод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput : ModIdentityServerWebMvcPartAccountViewLoggedOutModel
    {
        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitles">Ресурс заголовков.</param>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput(ModIdentityServerBaseResourceTitles resourceTitles) :
            base(resourceTitles)
        {
        }

        #endregion Constructor
    }
}
