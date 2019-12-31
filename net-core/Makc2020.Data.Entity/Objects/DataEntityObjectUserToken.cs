//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "UserToken".
    /// </summary>
    public class DataEntityObjectUserToken : DataBaseObjectUserToken
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public virtual DataEntityObjectUser ObjectUser { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "UserToken".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "UserToken".</returns>
        public static DataEntityObjectUserToken Create(DataBaseObjectUserToken source)
        {
            var result = new DataEntityObjectUserToken();
            new DataBaseLoaderUserToken(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "UserToken".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "UserToken".</returns>
        public DataBaseObjectUserToken CreateObjectUserToken()
        {
            var loader = new DataBaseLoaderUserToken();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
