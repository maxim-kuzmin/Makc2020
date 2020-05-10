//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "UserClaim".
    /// </summary>
    public class DataBaseSettingUserClaim : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public const string DB_TABLE = "UserClaim";

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
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser => CreateNameOfForeignKey(DbTable, DataBaseSettingUser.DB_TABLE);

        /// <summary>
        /// Наименование индекса в базе данных для поля "UserId".
        /// </summary>
        public string DbIndexForUserId=> CreateNameOfIndex(DbTable, nameof(DataBaseObjectUserClaim.UserId));

        #endregion Properties
    }
}
