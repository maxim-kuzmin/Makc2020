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
        /// <param name="defaults">Значения по-умолчанию.</param>
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
            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingUser.DbTable);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
