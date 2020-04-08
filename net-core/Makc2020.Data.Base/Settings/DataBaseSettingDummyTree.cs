//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
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
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId => CoreBaseDataSettings.FIELD_NAME_Id;

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName => CoreBaseDataSettings.FIELD_NAME_Name;

        /// <summary>
        /// Имя колонки в базе данных для поля "ParentId".
        /// </summary>
        public string DbColumnNameForParentId => CoreBaseDataSettings.FIELD_NAME_ParentId;

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeChildCount".
        /// </summary>
        public string DbColumnNameForTreeChildCount => CoreBaseDataSettings.FIELD_NAME_TreeChildCount;

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeDescendantCount".
        /// </summary>
        public string DbColumnNameForTreeDescendantCount => CoreBaseDataSettings.FIELD_NAME_TreeDescendantCount;

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeLevel".
        /// </summary>
        public string DbColumnNameForTreeLevel => CoreBaseDataSettings.FIELD_NAME_TreeLevel;

        /// <summary>
        /// Имя колонки в базе данных для поля "TreePath".
        /// </summary>
        public string DbColumnNameForTreePath => CoreBaseDataSettings.FIELD_NAME_TreePath;

        /// <summary>
        /// Имя колонки в базе данных для поля "TreePosition".
        /// </summary>
        public string DbColumnNameForTreePosition => CoreBaseDataSettings.FIELD_NAME_TreePosition;

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeSort".
        /// </summary>
        public string DbColumnNameForTreeSort => CoreBaseDataSettings.FIELD_NAME_TreeSort;

        #endregion Properties
    }
}