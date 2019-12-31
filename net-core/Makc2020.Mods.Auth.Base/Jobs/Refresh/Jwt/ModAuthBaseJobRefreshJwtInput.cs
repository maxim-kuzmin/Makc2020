//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Обновление. JWT. Ввод.
    /// </summary>
    public class ModAuthBaseJobRefreshJwtInput
    {
        #region Properties

        /// <summary>
        /// Токен данных.
        /// </summary>
        public string DataToken { get; set; }

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

            if (string.IsNullOrWhiteSpace(DataToken))
            {
                result.Add(nameof(DataToken));
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
