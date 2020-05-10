//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "UserRole".
    /// </summary>
    public class DataBaseSettingUserRole : DataBaseSetting
    {
        #region Constants

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public const string DB_TABLE = "UserRole";

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
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRole => CreateNameOfForeignKey(DbTable, DataBaseSettingRole.DB_TABLE);

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbColumnNameForUserId => CreateNameOfColumn(DataBaseSettingUser.DB_TABLE, nameof(DataBaseObjectUser.Id));

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string DbColumnNameForRoleId => CreateNameOfColumn(DataBaseSettingRole.DB_TABLE, nameof(DataBaseObjectRole.Id));

        /// <summary>
        /// Наименование индекса в базе данных для поля "RoleId".
        /// </summary>
        public string DbIndexForRoleId => CreateNameOfIndex(DbTable, nameof(DataBaseObjectUserRole.RoleId));

        #endregion Properties
    }
}
