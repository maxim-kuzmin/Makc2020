//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "Role".
    /// </summary>
    public class DataBaseSettingRole : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public const string DB_TABLE = "Role";

        #endregion Constants

        #region Properties

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public string DbTable => DB_TABLE;

        /// <summary>
        /// Схема в базе данных.
        /// </summary>
        public string DbSchema => CreateNameOfSchema();

        /// <summary>
        /// Таблица со схемой в базе данных.
        /// </summary>
        public string DbTableWithSchema => CreateFullName(DbSchema, DbTable);

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey => CreateNameOfPrimaryKey(DbTable);

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "NormalizedName".
        /// </summary>
        public string DbUniqueIndexForNormalizedName => CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectRole.NormalizedName));

        #endregion Properties
    }
}
