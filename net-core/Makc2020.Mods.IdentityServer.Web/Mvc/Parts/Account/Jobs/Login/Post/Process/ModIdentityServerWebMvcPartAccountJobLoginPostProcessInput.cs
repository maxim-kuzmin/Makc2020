//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using Makc2020.Core.Base.Logging;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Makc2020.Host.Base.Parts.Ldap.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process.Enums;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Обработка. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput : ModIdentityServerWebMvcPartAccountCommonJobLoginInput
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
        /// Задание на вход в систему через LDAP.
        /// </summary>
        public HostBasePartLdapJobLoginService JobLdapLogin { get; set; }

        /// <summary>
        /// Задание на создание сущности пользователя.
        /// </summary>
        public HostBasePartAuthJobUserEntityCreateService JobUserEntityCreate { get; set; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        public CoreBaseLoggingService Logger { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountViewLoginModel Model { get; set; }

        /// <summary>
        /// Состояние модели.
        /// </summary>
        public ModelStateDictionary ModelState { get; set; }

        /// <summary>
        /// Менеджер ролей.
        /// </summary>
        public RoleManager<DataEntityObjectRole> RoleManager { get; set; }

        /// <summary>
        /// Менеджер входа в систему.
        /// </summary>
        public SignInManager<DataEntityObjectUser> SignInManager { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses Status { get; set; } =
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessEnumStatuses.Default;

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
