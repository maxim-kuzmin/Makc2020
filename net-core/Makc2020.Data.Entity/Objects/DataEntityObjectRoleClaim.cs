//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "RoleClaim".
    /// </summary>
    public class DataEntityObjectRoleClaim : DataBaseObjectRoleClaim
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "Role".
        /// </summary>
        public virtual DataEntityObjectRole ObjectRole { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "RoleClaim".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "RoleClaim".</returns>
        public static DataEntityObjectRoleClaim Create(DataBaseObjectRoleClaim source)
        {
            var result = new DataEntityObjectRoleClaim();
            new DataBaseLoaderRoleClaim(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "RoleClaim".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "RoleClaim".</returns>
        public DataBaseObjectRoleClaim CreateObjectRoleClaim()
        {
            var loader = new DataBaseLoaderRoleClaim();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
