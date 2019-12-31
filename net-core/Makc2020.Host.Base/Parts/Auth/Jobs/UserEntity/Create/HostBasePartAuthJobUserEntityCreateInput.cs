//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Identity;
using Makc2020.Data.Entity.Objects;
using System.Collections.Generic;
using System.Security.Claims;

namespace Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Сущность пользователя. Создание. Ввод.
    /// </summary>
    public class HostBasePartAuthJobUserEntityCreateInput
    {
        #region Properties        

        /// <summary>
        /// Утверждения.
        /// </summary>
        public IEnumerable<Claim> Claims { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Поставщик входа в систему.
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Отображаемое имя поставщика.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        /// Ключ поставщика.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Менеджер ролей.
        /// </summary>
        public RoleManager<DataEntityObjectRole> RoleManager { get; set; }

        /// <summary>
        /// Наименования ролей.
        /// </summary>
        public IEnumerable<string> RoleNames { get; set; }

        /// <summary>
        /// Менеджер пользователей.
        /// </summary>
        public UserManager<DataEntityObjectUser> UserManager { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
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

            if (string.IsNullOrWhiteSpace(UserName))
            {
                result.Add(nameof(UserName));
            }

            return result;
        }

        #endregion Public methods
    }
}
