//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "UserClaim".
    /// </summary>
    public class DataEntityObjectUserClaim : DataBaseObjectUserClaim
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public virtual DataEntityObjectUser ObjectUser { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "UserClaim".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "UserClaim".</returns>
        public static DataEntityObjectUserClaim Create(DataBaseObjectUserClaim source)
        {
            var result = new DataEntityObjectUserClaim();
            new DataBaseLoaderUserClaim(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "UserClaim".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "UserClaim".</returns>
        public DataBaseObjectUserClaim CreateObjectUserClaim()
        {
            var loader = new DataBaseLoaderUserClaim();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
