//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyTreeLink".
    /// </summary>
    public class DataBaseSettingDummyTreeLink : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "ParentId".
        /// </summary>
        public string DbColumnNameForParentId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToDummyTree { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingDummyTree">Настройка сущности "DummyTree".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingDummyTreeLink(
            DataBaseSettingDummyTree settingDummyTree,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;
            DbColumnNameForParentId = defaults.ColumnNameForParentId;

            DbForeignKeyToDummyTree = CreateNameOfForeignKey(DbTable, settingDummyTree.DbTable);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}