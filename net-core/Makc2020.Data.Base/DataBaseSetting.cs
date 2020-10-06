//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Настройка.
    /// </summary>
    public class DataBaseSetting
    {
        #region Properties

        private DataBaseDefaults Defaults { get; set; }

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public string DbTable { get; private set; }

        /// <summary>
        /// Схема в базе данных.
        /// </summary>
        public string DbSchema { get; private set; }

        /// <summary>
        /// Таблица со схемой в базе данных.
        /// </summary>
        public string DbTableWithSchema { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSetting(DataBaseDefaults defaults, string dbTable, string dbSchema = null)
        {
            Defaults = defaults;
            DbTable = dbTable;
            DbSchema = dbSchema ?? CreateNameOfSchema();
            DbTableWithSchema = string.IsNullOrWhiteSpace(DbSchema) ? DbTable : CreateFullName(DbSchema, DbTable);
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Создать полное имя в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateFullName(params string[] parts)
        {
            return string.Join(Defaults.FullNamePartsSeparator, parts);
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
            return CreateName(Defaults.ForeignKeyPrefix, parts);
        }

        /// <summary>
        /// Создать имя индекса в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfIndex(params string[] parts)
        {
            return CreateName(Defaults.IndexPrefix, parts);
        }

        /// <summary>
        /// Создать имя первичного ключа в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfPrimaryKey(params string[] parts)
        {
            return CreateName(Defaults.PrimaryKeyPrefix, parts);
        }

        /// <summary>
        /// Создать имя схемы в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfSchema(params string[] parts)
        {
            return parts.Length > 0 ? CreateName(null, parts) : Defaults.Schema;
        }

        /// <summary>
        /// Создать имя уникального индекса в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя.</returns>
        protected string CreateNameOfUniqueIndex(params string[] parts)
        {
            return CreateName(Defaults.UniqueIndexPrefix, parts);
        }

        #endregion Protected methods

        #region Private methods

        private string CreateName(string prefix, params string[] parts)
        {
            var result = string.Join(Defaults.NamePartsSeparator, parts);

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                result = string.Concat(prefix, Defaults.NamePartsSeparator, result);
            }

            return result;
        }

        #endregion Private methods
    }
}
