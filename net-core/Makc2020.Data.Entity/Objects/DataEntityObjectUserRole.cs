//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "UserRole".
    /// </summary>
    public class DataEntityObjectUserRole : DataBaseObjectUserRole
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public DataEntityObjectUser ObjectUser { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "Role".
        /// </summary>
        public DataEntityObjectRole ObjectRole { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "UserRole".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "UserRole".</returns>
        public static DataEntityObjectUserRole Create(DataBaseObjectUserRole source)
        {
            var result = new DataEntityObjectUserRole();
            new DataBaseLoaderUserRole(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "UserRole".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "UserRole".</returns>
        public DataBaseObjectUserRole CreateObjectUserRole()
        {
            var loader = new DataBaseLoaderUserRole();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}