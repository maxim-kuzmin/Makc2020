//Author Maxim Kuzmin//makc//

using System;

namespace Makc2020.Mods.IdentityServer.Base.Common.Exceptions
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Исключения. Пользователь.
    /// </summary>
    public class ModIdentityServerBaseCommonExceptionUser : Exception
    {
        #region Properties

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        #endregion Properties
    }
}