//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "Role".
    /// </summary>
    public class DataEntityObjectRole : DataBaseObjectRole
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "RoleClaim".
        /// </summary>
        public virtual List<DataEntityObjectRoleClaim> ObjectsRoleClaim { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserRole".
        /// </summary>
        public virtual List<DataEntityObjectUserRole> ObjectsUserRole { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectRole()
        {
            ObjectsRoleClaim = new List<DataEntityObjectRoleClaim>();
            ObjectsUserRole = new List<DataEntityObjectUserRole>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "Role".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "Role".</returns>
        public static DataEntityObjectRole Create(DataBaseObjectRole source)
        {
            var result = new DataEntityObjectRole();
            new DataBaseLoaderRole(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "Role".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "Role".</returns>
        public DataBaseObjectRole CreateObjectRole()
        {
            var loader = new DataBaseLoaderRole();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
