//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "DummyManyToMany".
    /// </summary>
    public class DataEntityObjectDummyManyToMany : DataBaseObjectDummyManyToMany
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        public virtual List<DataEntityObjectDummyMainDummyManyToMany> ObjectsDummyMainDummyManyToMany { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectDummyManyToMany()
        {
            ObjectsDummyMainDummyManyToMany = new List<DataEntityObjectDummyMainDummyManyToMany>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyManyToMany".</returns>
        public static DataEntityObjectDummyManyToMany Create(DataBaseObjectDummyManyToMany source)
        {
            var result = new DataEntityObjectDummyManyToMany();
            new DataBaseLoaderDummyManyToMany(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyManyToMany".</returns>
        public DataBaseObjectDummyManyToMany CreateObjectDummyManyToMany()
        {
            var loader = new DataBaseLoaderDummyManyToMany();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
