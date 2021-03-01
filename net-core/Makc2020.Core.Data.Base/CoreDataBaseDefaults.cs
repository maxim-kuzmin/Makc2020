//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Data.Base
{
    /// <summary>
    /// Ядро. Данные. Основа. Значения по умолчанию.
    /// </summary>
    public class CoreDataBaseDefaults
    {
        #region Properties

        /// <summary>
        /// Имя колонки для поля "Id".
        /// </summary>
        public string ColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки для поля "Name".
        /// </summary>
        public string ColumnNameForName { get; set; }

        /// <summary>
        /// Имя колонки для поля "ParentId".
        /// </summary>
        public string ColumnNameForParentId { get; set; }

        /// <summary>
        /// Имя колонки для поля "TreeChildCount".
        /// </summary>
        public string ColumnNameForTreeChildCount { get; set; }

        /// <summary>
        /// Имя колонки для поля "TreeDescendantCount".
        /// </summary>
        public string ColumnNameForTreeDescendantCount { get; set; }

        /// <summary>
        /// Имя колонки для поля "TreeLevel".
        /// </summary>
        public string ColumnNameForTreeLevel { get; set; }

        /// <summary>
        /// Имя колонки для поля "TreePath".
        /// </summary>
        public string ColumnNameForTreePath { get; set; }

        /// <summary>
        /// Имя колонки для поля "TreePosition".
        /// </summary>
        public string ColumnNameForTreePosition { get; set; }

        /// <summary>
        /// Имя колонки для поля "TreeSort".
        /// </summary>
        public string ColumnNameForTreeSort { get; set; }

        /// <summary>
        /// Разделитель частей имени столбца.
        /// </summary>
        public string ColumnNamePartsSeparator { get; set; }

        /// <summary>
        /// Префикс внешнего ключа.
        /// </summary>
        public string ForeignKeyPrefix { get; set; }

        /// <summary>
        /// Разделитель частей полного имени.
        /// </summary>
        public string FullNamePartsSeparator { get; set; }

        /// <summary>
        /// Префикс индекса в базе данных.
        /// </summary>
        public string IndexPrefix { get; set; }

        /// <summary>
        /// Разделитель частей имени.
        /// </summary>
        public string NamePartsSeparator { get; set; }

        /// <summary>
        /// Префикс первичного ключа.
        /// </summary>
        public string PrimaryKeyPrefix { get; set; }

        /// <summary>
        /// Схема.
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Префикс уникального индекса.
        /// </summary>
        public string UniqueIndexPrefix { get; set; }

        #endregion Properties
    }
}
