//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "DummyMainDummyManyToMany".
    /// </summary>
    public class DataBaseSettingDummyMainDummyManyToMany : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnNameForDummyMainId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbColumnNameForDummyManyToManyId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string DbForeignKeyToDummyMain { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyManyToMany".
        /// </summary>
        public string DbForeignKeyToDummyManyToMany { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingDummyMain">Настройка сущности "DummyMain".</param>
        /// <param name="settingDummyManyToMany">Настройка сущности "DummyManyToMany".</param>
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingDummyMainDummyManyToMany(
            DataBaseSettingDummyMain settingDummyMain,
            DataBaseSettingDummyManyToMany settingDummyManyToMany,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {                        
            DbColumnNameForDummyMainId = CreateNameOfColumn(
                settingDummyMain.DbTable,
                settingDummyMain.DbColumnNameForId
                );

            DbColumnNameForDummyManyToManyId = CreateNameOfColumn(
                settingDummyManyToMany.DbTable,
                settingDummyManyToMany.DbColumnNameForId
                );

            DbForeignKeyToDummyMain = CreateNameOfForeignKey(DbTable, settingDummyMain.DbTable);
            DbForeignKeyToDummyManyToMany = CreateNameOfForeignKey(DbTable, settingDummyManyToMany.DbTable);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
