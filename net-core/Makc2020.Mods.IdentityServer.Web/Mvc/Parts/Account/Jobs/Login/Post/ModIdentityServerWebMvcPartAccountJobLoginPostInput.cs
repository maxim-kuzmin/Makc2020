//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostInput : ModIdentityServerWebMvcPartAccountCommonJobLoginInput
    {
        #region Properties

        /// <summary>
        /// Действие.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// События.
        /// </summary>
        public IEventService Events { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountViewLoginModel Model { get; set; }

        /// <summary>
        /// Состояние модели.
        /// </summary>
        public ModelStateDictionary ModelState { get; set; }

        /// <summary>
        /// Менеджер входа в систему.
        /// </summary>
        public SignInManager<DataEntityObjectUser> SignInManager { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses Status { get; set; } =
            ModIdentityServerWebMvcPartAccountJobLoginPostEnumStatuses.Default;

        /// <summary>
        /// Помощник URL.
        /// </summary>
        public IUrlHelper UrlHelper { get; set; }

        /// <summary>
        /// Менеджер пользователей.
        /// </summary>
        public UserManager<DataEntityObjectUser> UserManager { get; set; }

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

            if (Model == null)
            {
                result.Add(nameof(Model));
            }

            if (ModelState == null)
            {
                result.Add(nameof(ModelState));
            }

            if (SignInManager == null)
            {
                result.Add(nameof(SignInManager));
            }

            if (UrlHelper == null)
            {
                result.Add(nameof(UrlHelper));
            }

            if (UserManager == null)
            {
                result.Add(nameof(UserManager));
            }

            return result;
        }

        #endregion Public methods
    }
}
