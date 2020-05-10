//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyTreeLink".
    /// </summary>
    public class DataBaseSettingDummyTreeLink : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public const string DB_TABLE = "DummyTreeLink";

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
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId => CoreBaseDataSettings.FIELD_NAME_Id;

        /// <summary>
        /// Имя колонки в базе данных для поля "ParentId".
        /// </summary>
        public string DbColumnNameForParentId => CoreBaseDataSettings.FIELD_NAME_ParentId;

        #endregion Properties
    }
}