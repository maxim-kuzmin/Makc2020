//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Identity;

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "User".
    /// </summary>
    public class DataBaseObjectUser : IdentityUser<long>
    {
        #region Properties

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        #endregion Properties
    }
}