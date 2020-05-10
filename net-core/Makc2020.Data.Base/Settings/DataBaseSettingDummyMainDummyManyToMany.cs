//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyMainDummyManyToMany".
    /// </summary>
    public class DataBaseSettingDummyMainDummyManyToMany : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public const string DB_TABLE = "DummyMainDummyManyToMany";

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
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string DbForeignKeyToDummyMain => CreateNameOfForeignKey(DbTable, DataBaseSettingDummyMain.DB_TABLE);

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyManyToMany".
        /// </summary>
        public string DbForeignKeyToDummyManyToMany => CreateNameOfForeignKey(DbTable, DataBaseSettingDummyManyToMany.DB_TABLE);

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnNameForDummyMainId => CreateNameOfColumn(DataBaseSettingDummyMain.DB_TABLE, DataBaseSettingDummyMain.DB_COLUMN_FOR_Id);

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbColumnNameForDummyManyToManyId => CreateNameOfColumn(DataBaseSettingDummyManyToMany.DB_TABLE, DataBaseSettingDummyManyToMany.DB_COLUMN_FOR_Id);

        #endregion Properties
    }
}
