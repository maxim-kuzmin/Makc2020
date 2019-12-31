//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Principal;

namespace Makc2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Текущий пользователь. Получение. Ввод.
    /// </summary>
    public class HostBasePartAuthJobCurrentUserGetInput
    {
        #region Properties

        /// <summary>
        /// Принципал.
        /// </summary>
        public IPrincipal Principal { get; set; }

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

            if (UserManager == null)
            {
                result.Add(nameof(UserManager));
            }

            return result;
        }

        #endregion Public methods
    }
}
