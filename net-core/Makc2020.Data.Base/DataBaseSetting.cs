//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Настройка.
    /// </summary>
    public class DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Схема в базе данных.
        /// </summary>
        private const string DB_SCHEMA = "dbo";

        /// <summary>
        /// Префикс первичного ключа в базе данных.
        /// </summary>
        private const string DB_PREFIX_PK = "PK";

        /// <summary>
        /// Префикс внешнего ключа в базе данных.
        /// </summary>
        private const string DB_PREFIX_FK = "FK";

        /// <summary>
        /// Префикс уникального индекса в базе данных.
        /// </summary>
        private const string DB_PREFIX_UX = "UX";

        /// <summary>
        /// Префикс индекса в базе данных.
        /// </summary>
        private const string DB_PREFIX_IX = "IX";

        /// <summary>
        /// Разделитель частей полного имени в базе данных.
        /// </summary>
        private const string DB_SEPARATOR_OF_FULL_NAME_PARTS = ".";

        /// <summary>
        /// Разделитель частей имени в базе данных.
        /// </summary>
        private const string DB_SEPARATOR_OF_NAME_PARTS = "_";

        #endregion Constants

        #region Protected methods

        /// <summary>
        /// Создать полное имя в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateFullName(params string[] parts)
        {
            return string.Join(DB_SEPARATOR_OF_FULL_NAME_PARTS, parts);
        }

        /// <summary>
        /// Создать имя колонки в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfColumn(params string[] parts)
        {
            return string.Concat(parts);
        }

        /// <summary>
        /// Создать имя внешнего ключа в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfForeignKey(params string[] parts)
        {
            return CreateName(DB_PREFIX_FK, parts);
        }

        /// <summary>
        /// Создать имя индекса в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfIndex(params string[] parts)
        {
            return CreateName(DB_PREFIX_IX, parts);
        }

        /// <summary>
        /// Создать имя первичного ключа в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfPrimaryKey(params string[] parts)
        {
            return CreateName(DB_PREFIX_PK, parts);
        }

        /// <summary>
        /// Создать имя схемы в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfSchema(params string[] parts)
        {
            return parts.Length > 0 ? CreateName(null, parts) : DB_SCHEMA;
        }

        /// <summary>
        /// Создать имя уникального индекса в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfUniqueIndex(params string[] parts)
        {
            return CreateName(DB_PREFIX_UX, parts);
        }

        #endregion Protected methods

        #region Private methods

        private string CreateName(string prefix, params string[] parts)
        {
            var result = string.Join(DB_SEPARATOR_OF_NAME_PARTS, parts);

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                result = string.Concat(prefix, DB_SEPARATOR_OF_NAME_PARTS, result);
            }

            return result;
        }

        #endregion Private methods
    }
}
