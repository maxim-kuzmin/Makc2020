//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Views.Login;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Создание отклика. Ввод.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput : ModIdentityServerWebMvcPartAccountCommonJobLoginInput
    {
        #region Properties

        /// <summary>
        /// Модель.
        /// </summary>
        public ModIdentityServerWebMvcPartAccountViewLoginModel Model { get; set; }

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
