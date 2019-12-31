//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "DummyMainDummyManyToMany".
    /// </summary>
    public class DataEntityObjectDummyMainDummyManyToMany : DataBaseObjectDummyMainDummyManyToMany
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        public DataEntityObjectDummyMain ObjectDummyMain { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public DataEntityObjectDummyManyToMany ObjectDummyManyToMany { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMainDummyManyToMany".</returns>
        public static DataEntityObjectDummyMainDummyManyToMany Create(DataBaseObjectDummyMainDummyManyToMany source)
        {
            var result = new DataEntityObjectDummyMainDummyManyToMany();
            new DataBaseLoaderDummyMainDummyManyToMany(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMainDummyManyToMany".</returns>
        public DataBaseObjectDummyMainDummyManyToMany CreateObjectDummyMainDummyManyToMany()
        {
            var loader = new DataBaseLoaderDummyMainDummyManyToMany();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}