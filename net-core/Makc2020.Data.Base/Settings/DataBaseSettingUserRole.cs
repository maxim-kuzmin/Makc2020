//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "UserRole".
    /// </summary>
    public class DataBaseSettingUserRole : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string DbColumnNameForRoleId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbColumnNameForUserId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRole { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "RoleId".
        /// </summary>
        public string DbIndexForRoleId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingRole">Настройка сущности "Role".</param>
        /// <param name="settingUser">Настройка сущности "User".</param>
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingUserRole(
            DataBaseSettingRole settingRole,
            DataBaseSettingUser settingUser,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForRoleId = CreateNameOfColumn(settingRole.DbTable, nameof(DataBaseObjectRole.Id));
            DbColumnNameForUserId = CreateNameOfColumn(settingUser.DbTable, nameof(DataBaseObjectUser.Id));

            DbForeignKeyToRole = CreateNameOfForeignKey(DbTable, settingRole.DbTable);
            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingUser.DbTable);

            DbIndexForRoleId = CreateNameOfIndex(DbTable, nameof(DataBaseObjectUserRole.RoleId));

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
