//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "DummyTreeLink".
    /// </summary>
    public class DataBaseObjectDummyTreeLink
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор родительского узла.
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// Уровень узла в дереве.
        /// </summary>
        public long Level { get; set; }

        #endregion Properties
    }
}