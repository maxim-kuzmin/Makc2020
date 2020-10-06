//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyTree".
    /// </summary>
    public class DataBaseSettingDummyTree : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Внешний ключ в базе данных к родительской сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToParentDummyTree { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "ParentId".
        /// </summary>
        public string DbColumnNameForParentId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeChildCount".
        /// </summary>
        public string DbColumnNameForTreeChildCount { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeDescendantCount".
        /// </summary>
        public string DbColumnNameForTreeDescendantCount { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeLevel".
        /// </summary>
        public string DbColumnNameForTreeLevel { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TreePath".
        /// </summary>
        public string DbColumnNameForTreePath { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TreePosition".
        /// </summary>
        public string DbColumnNameForTreePosition { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TreeSort".
        /// </summary>
        public string DbColumnNameForTreeSort { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "Name".
        /// </summary>
        public string DbIndexForName { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "TreeSort".
        /// </summary>
        public string DbIndexForTreeSort { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "TreePath".
        /// </summary>
        public int DbMaxLengthForTreePath { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "TreeSort".
        /// </summary>
        public int DbMaxLengthForTreeSort { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingDummyTree(
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = CoreBaseDataSettings.FIELD_NAME_Id;
            DbColumnNameForName = CoreBaseDataSettings.FIELD_NAME_Name;
            DbColumnNameForParentId = CoreBaseDataSettings.FIELD_NAME_ParentId;
            DbColumnNameForTreeChildCount = CoreBaseDataSettings.FIELD_NAME_TreeChildCount;
            DbColumnNameForTreeDescendantCount = CoreBaseDataSettings.FIELD_NAME_TreeDescendantCount;
            DbColumnNameForTreeLevel = CoreBaseDataSettings.FIELD_NAME_TreeLevel;
            DbColumnNameForTreePath = CoreBaseDataSettings.FIELD_NAME_TreePath;
            DbColumnNameForTreePosition = CoreBaseDataSettings.FIELD_NAME_TreePosition;
            DbColumnNameForTreeSort = CoreBaseDataSettings.FIELD_NAME_TreeSort;

            DbForeignKeyToParentDummyTree = CreateNameOfForeignKey(DbTable, DbTable, DbColumnNameForParentId);

            DbIndexForName = CreateNameOfIndex(DbTable, DbColumnNameForName);
            DbIndexForTreeSort = CreateNameOfIndex(DbTable, DbColumnNameForTreeSort);

            DbMaxLengthForName = 256;
            DbMaxLengthForTreePath = 900;
            DbMaxLengthForTreeSort = 900;

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}