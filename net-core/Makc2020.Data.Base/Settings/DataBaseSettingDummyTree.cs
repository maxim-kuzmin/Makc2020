//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyTree".
    /// </summary>
    public class DataBaseSettingDummyTree : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        internal const string DB_TABLE = "DummyTree";

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
        /// Внешний ключ в базе данных к родительской сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToParentDummyTree => CreateNameOfForeignKey(DbTable, DbTable, nameof(DataBaseObjectDummyTree.ParentId));

        /// <summary>
        /// Наименование уникального индекса в базе данных для полей "Id" и "ParentId".
        /// </summary>
        public string DbUniqueIndexForIdAndParentId => CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectDummyTree.Id), nameof(DataBaseObjectDummyTree.ParentId));

        /// <summary>
        /// Наименование уникального индекса в базе данных для полей "ParentId" и "Name".
        /// </summary>
        public string DbUniqueIndexForParentIdAndName => CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectDummyTree.ParentId), nameof(DataBaseObjectDummyTree.Name));

        #endregion Properties
    }
}