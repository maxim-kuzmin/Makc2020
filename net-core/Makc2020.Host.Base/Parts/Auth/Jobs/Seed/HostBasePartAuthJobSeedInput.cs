//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Makc2020.Host.Base.Parts.Auth.Jobs.Seed
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Посев. Ввод.
    /// </summary>
    public class HostBasePartAuthJobSeedInput
    {
        #region Properties

        /// <summary>
        /// Менеджер ролей.
        /// </summary>
        public RoleManager<DataEntityObjectRole> RoleManager { get; set; }

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
        public List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (RoleManager == null)
            {
                result.Add(nameof(RoleManager));
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
