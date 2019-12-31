//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Host.Base.Parts.Ldap.Jobs.Login
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Задания. Вход в систему. Ввод.
    /// </summary>
    public class HostBasePartLdapJobLoginInput
    {
        #region Properties

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

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

            if (string.IsNullOrWhiteSpace(Password))
            {
                result.Add(nameof(Password));
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
