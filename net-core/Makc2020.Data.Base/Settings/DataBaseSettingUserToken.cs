//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "UserToken".
    /// </summary>
    public class DataBaseSettingUserToken : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "LoginProvider".
        /// </summary>
        public string DbColumnNameForLoginProvider { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "UserId".
        /// </summary>
        public string DbColumnNameForUserId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Value".
        /// </summary>
        public string DbColumnNameForValue { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingUser">Настройка сущности "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingUserToken(
            DataBaseSettingUser settingUser,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForName = defaults.ColumnNameForName;

            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingUser.DbTable);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
