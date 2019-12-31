//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Identity;
using Makc2020.Host.Base.Common.Identity;
using System.Collections.Generic;

namespace Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Сущность пользователя. Создание. Исключение.
    /// </summary>
    public class HostBasePartAuthJobUserEntityCreateException : HostBaseCommonIdentityException
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errors">Ошибки.</param>
        public HostBasePartAuthJobUserEntityCreateException(IEnumerable<IdentityError> errors)
            : base(errors)
        {
        }

        #endregion Constructors
    }
}
