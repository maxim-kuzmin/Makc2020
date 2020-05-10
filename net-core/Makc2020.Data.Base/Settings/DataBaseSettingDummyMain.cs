//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyMain".
    /// </summary>
    public class DataBaseSettingDummyMain : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public const string DB_COLUMN_FOR_Id = CoreBaseDataSettings.FIELD_NAME_Id;

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public const string DB_TABLE = "DummyMain";

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
        /// Внешний ключ в базе данных к сущности "DummyOneToMany".
        /// </summary>
        public string DbForeignKeyToDummyOneToMany => CreateNameOfForeignKey(DbTable, DataBaseSettingDummyOneToMany.DB_TABLE);

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId => DB_COLUMN_FOR_Id;

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName => CoreBaseDataSettings.FIELD_NAME_Name;

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyOneToMany".
        /// </summary>
        public string DbColumnNameForObjectDummyOneToManyId => CreateNameOfColumn(DataBaseSettingDummyOneToMany.DB_TABLE, DataBaseSettingDummyOneToMany.DB_COLUMN_FOR_Id);

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName => 256;

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "Name".
        /// </summary>
        public string DbUniqueIndexForName => CreateNameOfUniqueIndex(DbTable, DbColumnNameForName);

        #endregion Properties
    }
}
