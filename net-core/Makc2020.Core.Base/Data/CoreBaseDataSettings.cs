//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Data
{
    /// <summary>
    /// Ядро. Основа. Данные. Настройки.
    /// </summary>
    public class CoreBaseDataSettings
    {
        #region Constants

        /// <summary>
        /// Имя поля "Идентификатор".
        /// </summary>
        public const string FIELD_NAME_Id = "Id";

        /// <summary>
        /// Имя поля "Имя".
        /// </summary>
        public const string FIELD_NAME_Name = "Name";

        /// <summary>
        /// Имя поля "Идентификатор родителя".
        /// </summary>
        public const string FIELD_NAME_ParentId = "ParentId";

        /// <summary>
        /// Имя поля "Число детей узла в дереве".
        /// </summary>
        public const string FIELD_NAME_TreeChildCount = "TreeChildCount";

        /// <summary>
        /// Имя поля "Число потомков узла в дереве".
        /// </summary>
        public const string FIELD_NAME_TreeDescendantCount = "TreeDescendantCount";

        /// <summary>
        /// Имя поля "Уровень узла в дереве".
        /// </summary>
        public const string FIELD_NAME_TreeLevel = "TreeLevel";

        /// <summary>
        /// Имя поля "Путь узла в дереве".
        /// </summary>
        public const string FIELD_NAME_TreePath = "TreePath";

        /// <summary>
        /// Имя поля "Позиция узла в дереве".
        /// </summary>
        public const string FIELD_NAME_TreePosition = "TreePosition";

        /// <summary>
        /// Имя поля "Сортировка узла в дереве".
        /// </summary>
        public const string FIELD_NAME_TreeSort = "TreeSort";

        #endregion Constants
    }
}
