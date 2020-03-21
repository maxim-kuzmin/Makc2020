//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "DummyTreeLink".
    /// </summary>
    public class DataEntityObjectDummyTreeLink : DataBaseObjectDummyTreeLink
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные родительской сущности "DummyTree".
        /// </summary>
        public DataEntityObjectDummyTree ObjectDummyTree { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyTreeLink".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyTreeLink".</returns>
        public static DataEntityObjectDummyTreeLink Create(DataBaseObjectDummyTreeLink source)
        {
            var result = new DataEntityObjectDummyTreeLink();
            new DataBaseLoaderDummyTreeLink(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyTreeLink".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyTreeLink".</returns>
        public DataBaseObjectDummyTreeLink CreateObjectDummyTreeLink()
        {
            var loader = new DataBaseLoaderDummyTreeLink();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
