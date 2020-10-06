//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "RoleClaim".
    /// </summary>
    public class DataBaseSettingRoleClaim : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRole { get; set; }

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
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingRoleClaim(
            DataBaseSettingRole settingRole,
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbForeignKeyToRole = CreateNameOfForeignKey(DbTable, settingRole.DbTable);

            DbIndexForRoleId = CreateNameOfIndex(DbTable, nameof(DataBaseObjectRoleClaim.RoleId));

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);            
        }

        #endregion Constructors
    }
}
