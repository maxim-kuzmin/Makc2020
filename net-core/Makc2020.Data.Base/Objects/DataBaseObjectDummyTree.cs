//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "DummyTree".
    /// </summary>
    public class DataBaseObjectDummyTree
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор родительского узла.
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Число дочерних узлов в дереве.
        /// </summary>
        public long TreeChildCount { get; set; }

        /// <summary>
        /// Число узлов-потомков в дереве.
        /// </summary>
        public long TreeDescendantCount { get; set; }

        /// <summary>
        /// Уровень узла в дереве.
        /// </summary>
        public long TreeLevel { get; set; }

        /// <summary>
        /// Путь к узлу в дереве.
        /// </summary>
        public string TreePath { get; set; }

        /// <summary>
        /// Сортировка узла в дереве.
        /// </summary>
        public string TreeSort { get; set; }

        #endregion Properties
    }
}