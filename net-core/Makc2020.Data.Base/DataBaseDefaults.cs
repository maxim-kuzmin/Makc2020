//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Значения по-умолчанию.
    /// </summary>
    public class DataBaseDefaults
    {
        #region Properties

        /// <summary>
        /// Префикс внешнего ключа.
        /// </summary>
        public string ForeignKeyPrefix { get; set; } = "FK";

        /// <summary>
        /// Разделитель частей полного имени.
        /// </summary>
        public string FullNamePartsSeparator { get; set; } = ".";

        /// <summary>
        /// Префикс индекса в базе данных.
        /// </summary>
        public string IndexPrefix { get; set; } = "IX";

        /// <summary>
        /// Разделитель частей имени.
        /// </summary>
        public string NamePartsSeparator { get; set; } = "_";

        /// <summary>
        /// Префикс первичного ключа.
        /// </summary>
        public string PrimaryKeyPrefix { get; set; } = "PK";

        /// <summary>
        /// Схема.
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Префикс уникального индекса.
        /// </summary>
        public string UniqueIndexPrefix { get; set; } = "UX";

        #endregion Properties
    }
}
