//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "UserClaim".
    /// </summary>
    public class DataBaseSettingUserClaim : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "UserId".
        /// </summary>
        public string DbIndexForUserId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingUser">Настройка сущности "User".</param>
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingUserClaim(
            DataBaseSettingUser settingUser,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingUser.DbTable);

            DbIndexForUserId = CreateNameOfIndex(DbTable, nameof(DataBaseObjectUserClaim.UserId));

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
