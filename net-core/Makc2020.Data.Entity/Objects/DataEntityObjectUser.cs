//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "User".
    /// </summary>
    public class DataEntityObjectUser : DataBaseObjectUser
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserClaim".
        /// </summary>
        public virtual List<DataEntityObjectUserClaim> ObjectsUserClaim { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserLogin".
        /// </summary>
        public virtual List<DataEntityObjectUserLogin> ObjectsUserLogin { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserRole".
        /// </summary>
        public virtual List<DataEntityObjectUserRole> ObjectsUserRole { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserToken".
        /// </summary>
        public virtual List<DataEntityObjectUserToken> ObjectsUserToken { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectUser()
        {
            ObjectsUserClaim = new List<DataEntityObjectUserClaim>();
            ObjectsUserRole = new List<DataEntityObjectUserRole>();
            ObjectsUserToken = new List<DataEntityObjectUserToken>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "User".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "User".</returns>
        public static DataEntityObjectUser Create(DataBaseObjectUser source)
        {
            var result = new DataEntityObjectUser();
            new DataBaseLoaderUser(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "User".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "User".</returns>
        public DataBaseObjectUser CreateObjectUser()
        {
            var loader = new DataBaseLoaderUser();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
