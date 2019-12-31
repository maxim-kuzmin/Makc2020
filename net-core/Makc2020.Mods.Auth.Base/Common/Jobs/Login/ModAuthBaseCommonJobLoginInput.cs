//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Makc2020.Mod.Auth.Base.Common.Jobs.Login
{
    /// <summary>
    /// Мод "Auth". Основа. Общее. Задания. Вход в систему. Ввод.
    /// </summary>
    public class ModAuthBaseCommonJobLoginInput
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
        /// Менеджер пользователей.
        /// </summary>
        public UserManager<DataEntityObjectUser> UserManager { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (!string.IsNullOrWhiteSpace(DataUserName))
            {
                DataEmail = null;
            }
        }

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(DataUserName) && string.IsNullOrWhiteSpace(DataEmail))
            {
                result.Add(nameof(DataUserName));
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
