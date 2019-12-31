//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Makc2020.Mods.Auth.Base.Jobs.Register
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Регистрация. Ввод.
    /// </summary>
    public class ModAuthBaseJobRegisterInput
    {
        #region Properties

        /// <summary>
        /// Имя пользователя данных.
        /// </summary>
        public string DataUserName { get; set; }

        /// <summary>
        /// Адрес электронной почты данных.
        /// </summary>
        public string DataEmail { get; set; }

        /// <summary>
        /// Пароль данных.
        /// </summary>
        public string DataPassword { get; set; }

        /// <summary>
        /// Полное имя данных.
        /// </summary>
        public string DataFullName { get; set; }

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

            if (string.IsNullOrWhiteSpace(DataUserName))
            {
                result.Add(nameof(DataUserName));
            }

            if (string.IsNullOrWhiteSpace(DataEmail))
            {
                result.Add(nameof(DataEmail));
            }

            if (string.IsNullOrWhiteSpace(DataPassword))
            {
                result.Add(nameof(DataPassword));
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
