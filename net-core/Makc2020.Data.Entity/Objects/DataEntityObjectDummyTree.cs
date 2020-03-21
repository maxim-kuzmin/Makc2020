//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Entity.Objects
{
    /// <summary>
    /// Данные. Entity Framework. Объекты. Сущность "DummyTree".
    /// </summary>
    public class DataEntityObjectDummyTree : DataBaseObjectDummyTree
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные родительской сущности "DummyTree".
        /// </summary>
        public DataEntityObjectDummyTree ObjectDummyTreeParent { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные дочерней сущности "DummyTree".
        /// </summary>
        public virtual List<DataEntityObjectDummyTree> ObjectsDummyTreeChild { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyTreeLink".
        /// </summary>
        public virtual List<DataEntityObjectDummyTreeLink> ObjectsDummyTreeLink { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityObjectDummyTree()
        {
            ObjectsDummyTreeChild = new List<DataEntityObjectDummyTree>();
            ObjectsDummyTreeLink = new List<DataEntityObjectDummyTreeLink>();
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyTree".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyTree".</returns>
        public static DataEntityObjectDummyTree Create(DataBaseObjectDummyTree source)
        {
            var result = new DataEntityObjectDummyTree();
            new DataBaseLoaderDummyTree(result).LoadDataFrom(source);
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyTree".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyTree".</returns>
        public DataBaseObjectDummyTree CreateObjectDummyTree()
        {
            var loader = new DataBaseLoaderDummyTree();
            loader.LoadDataFrom(this);
            return loader.Data;
        }

        #endregion Public methods
    }
}
