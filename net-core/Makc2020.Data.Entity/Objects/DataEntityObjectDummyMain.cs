//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "DummyMain".
    /// </summary>
    public class DataEntityObjectDummyMain : DataBaseObjectDummyMain
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public virtual DataEntityObjectDummyOneToMany ObjectDummyOneToMany { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        public virtual List<DataEntityObjectDummyMainDummyManyToMany> ObjectsDummyMainDummyManyToMany { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectDummyMain()
        {
            ObjectsDummyMainDummyManyToMany = new List<DataEntityObjectDummyMainDummyManyToMany>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DataEntityObjectDummyMain Create(DataBaseObjectDummyMain source)
        {
            var result = new DataEntityObjectDummyMain();
            new DataBaseLoaderDummyMain(result).LoadDataFrom(source);            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public DataBaseObjectDummyMain CreateObjectDummyMain()
        {
            var loader = new DataBaseLoaderDummyMain();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
