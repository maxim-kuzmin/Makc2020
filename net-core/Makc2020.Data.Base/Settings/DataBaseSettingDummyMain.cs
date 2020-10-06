//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyMain".
    /// </summary>
    public class DataBaseSettingDummyMain : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyOneToMany".
        /// </summary>
        public string DbColumnNameForObjectDummyOneToManyId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyOneToMany".
        /// </summary>
        public string DbForeignKeyToDummyOneToMany { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "Name".
        /// </summary>
        public string DbUniqueIndexForName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingDummyOneToMany">Настройка сущности "DummyOneToMany".</param>
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingDummyMain(
            DataBaseSettingDummyOneToMany settingDummyOneToMany,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {            
            DbColumnNameForId = CoreBaseDataSettings.FIELD_NAME_Id;
            DbColumnNameForName = CoreBaseDataSettings.FIELD_NAME_Name;
            
            DbColumnNameForObjectDummyOneToManyId = CreateNameOfColumn(
                settingDummyOneToMany.DbTable,
                settingDummyOneToMany.DbColumnNameForId
                );

            DbForeignKeyToDummyOneToMany = CreateNameOfForeignKey(DbTable, settingDummyOneToMany.DbTable);

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForName = CreateNameOfUniqueIndex(DbTable, DbColumnNameForName);
        }

        #endregion Constructors
    }
}
