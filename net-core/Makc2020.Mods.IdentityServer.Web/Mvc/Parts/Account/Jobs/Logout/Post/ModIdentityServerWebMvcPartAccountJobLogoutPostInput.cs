//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Logout;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostInput : ModIdentityServerWebMvcPartAccountCommonJobLogoutInput
    {
        #region Properties

        /// <summary>
        /// События.
        /// </summary>
        public IEventService Events { get; set; }

        /// <summary>
        /// HTTP-контекст.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountViewLogoutModel Model { get; set; }

        /// <summary>
        /// Менеджер входа в систему.
        /// </summary>
        public SignInManager<DataEntityObjectUser> SignInManager { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostEnumStatuses Status { get; set; } =
            ModIdentityServerWebMvcPartAccountJobLogoutPostEnumStatuses.Default;

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
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (Events == null)
            {
                result.Add(nameof(Events));
            }

            if (HttpContext == null)
            {
                result.Add(nameof(HttpContext));
            }

            if (Model == null)
            {
                result.Add(nameof(Model));
            }

            if (SignInManager == null)
            {
                result.Add(nameof(SignInManager));
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
