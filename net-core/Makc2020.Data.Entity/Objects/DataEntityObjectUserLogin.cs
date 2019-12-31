//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "UserLogin".
    /// </summary>
    public class DataEntityObjectUserLogin : DataBaseObjectUserLogin
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public virtual DataEntityObjectUser ObjectUser { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "UserLogin".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "UserLogin".</returns>
        public static DataEntityObjectUserLogin Create(DataBaseObjectUserLogin source)
        {
            var result = new DataEntityObjectUserLogin();
            new DataBaseLoaderUserLogin(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "UserLogin".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "UserLogin".</returns>
        public DataBaseObjectUserLogin CreateObjectUserLogin()
        {
            var loader = new DataBaseLoaderUserLogin();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
