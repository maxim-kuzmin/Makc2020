//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Common.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Makc2020.Mods.Auth.Base.Jobs.Register
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Регистрация. Исключение.
    /// </summary>
    public class ModAuthBaseJobRegisterException : HostBaseCommonIdentityException
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errors">Ошибки.</param>
        public ModAuthBaseJobRegisterException(IEnumerable<IdentityError> errors)
            : base(errors)
        {
        }

        #endregion Constructors
    }
}
