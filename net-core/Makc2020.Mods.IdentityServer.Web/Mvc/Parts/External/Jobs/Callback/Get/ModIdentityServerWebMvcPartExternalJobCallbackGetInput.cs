//Author Maxim Kuzmin//makc//

using IdentityServer4.Services;
using IdentityServer4.Stores;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Задания. Обратный вызов. Получение. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalJobCallbackGetInput
    {
        #region Properties

        /// <summary>
        /// Хранилище клиентов.
        /// </summary>
        public IClientStore ClientStore { get; set; }

        /// <summary>
        /// События.
        /// </summary>
        public IEventService Events { get; set; }

        /// <summary>
        /// HTTP-контекст.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Взаимодействие.
        /// </summary>
        public IIdentityServerInteractionService Interaction { get; set; }

        /// <summary>
        /// Задание на создание сущности пользователя.
        /// </summary>
        public HostBasePartAuthJobUserEntityCreateService JobUserEntityCreate { get; set; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        public ILogger Logger { get; set; }

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
        public ModIdentityServerWebMvcPartExternalJobCallbackGetEnumStatuses Status { get; set; }

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
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (ClientStore == null)
            {
                result.Add(nameof(ClientStore));
            }

            if (Events == null)
            {
                result.Add(nameof(Events));
            }

            if (HttpContext == null)
            {
                result.Add(nameof(HttpContext));
            }

            if (Interaction == null)
            {
                result.Add(nameof(Interaction));
            }

            if (JobUserEntityCreate == null)
            {
                result.Add(nameof(JobUserEntityCreate));
            }

            if (Logger == null)
            {
                result.Add(nameof(Logger));
            }

            if (RoleManager == null)
            {
                result.Add(nameof(RoleManager));
            }

            if (SignInManager == null)
            {
                result.Add(nameof(SignInManager));
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
