//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Logout;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Logout;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Создание отклика. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput : ModIdentityServerWebMvcPartAccountCommonJobLogoutInput
    {
        #region Properties

        /// <summary>
        /// HTTP-контекст.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountViewLogoutModel Model { get; set; }

        /// <summary>
        /// Состояние модели.
        /// </summary>
        public ModelStateDictionary ModelState { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (HttpContext == null)
            {
                result.Add(nameof(HttpContext));
            }

            if (Model == null)
            {
                result.Add(nameof(Model));
            }

            if (ModelState == null)
            {
                result.Add(nameof(ModelState));
            }

            return result;
        }

        #endregion Public methods
    }
}
