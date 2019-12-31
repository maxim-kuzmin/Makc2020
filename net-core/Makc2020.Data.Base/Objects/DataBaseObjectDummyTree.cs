//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "DummyTree".
    /// </summary>
    public partial class DataBaseObjectDummyTree
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор родительского узла.
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Число дочерних узлов.
        /// </summary>
        public long ChildCount { get; set; }

        /// <summary>
        /// Число узлов-потомков.
        /// </summary>
        public long DescendantCount { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyMain".
        /// </summary>
        public long ObjectDummyMainId { get; set; }

        /// <summary>
        /// Уровень узла в дереве.
        /// </summary>
        public long Level { get; set; }

        #endregion Properties
    }
}