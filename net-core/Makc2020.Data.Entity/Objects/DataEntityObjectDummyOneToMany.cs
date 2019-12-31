//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "DummyOneToMany".
    /// </summary>
    public class DataEntityObjectDummyOneToMany : DataBaseObjectDummyOneToMany
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMain".
        /// </summary>
        public virtual List<DataEntityObjectDummyMain> ObjectsDummyMain { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectDummyOneToMany()
        {
            ObjectsDummyMain = new List<DataEntityObjectDummyMain>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyOneToMany".</returns>
        public static DataEntityObjectDummyOneToMany Create(DataBaseObjectDummyOneToMany source)
        {
            var result = new DataEntityObjectDummyOneToMany();
            new DataBaseLoaderDummyOneToMany(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyOneToMany".</returns>
        public DataBaseObjectDummyOneToMany CreateObjectDummyOneToMany()
        {
            var loader = new DataBaseLoaderDummyOneToMany();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
