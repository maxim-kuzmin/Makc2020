//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Base.Settings
{
    /// <summary>
    /// Данные. Основа. Настройки. Сущность "User".
    /// </summary>
    public class DataBaseSettingUser : DataBaseSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "AccessFailedCount".
        /// </summary>
        public string DbColumnNameForAccessFailedCount { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "ConcurrencyStamp".
        /// </summary>
        public string DbColumnNameForConcurrencyStamp { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Email".
        /// </summary>
        public string DbColumnNameForEmail { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "EmailConfirmed".
        /// </summary>
        public string DbColumnNameForEmailConfirmed { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "FullName".
        /// </summary>
        public string DbColumnNameForFullName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "NormalizedEmail".
        /// </summary>
        public string DbColumnNameForNormalizedEmail { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "LockoutEnabled".
        /// </summary>
        public string DbColumnNameForLockoutEnabled { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "LockoutEnd".
        /// </summary>
        public string DbColumnNameForLockoutEnd { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "NormalizedUserName".
        /// </summary>
        public string DbColumnNameForNormalizedUserName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PasswordHash".
        /// </summary>
        public string DbColumnNameForPasswordHash { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PhoneNumber".
        /// </summary>
        public string DbColumnNameForPhoneNumber { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PhoneNumberConfirmed".
        /// </summary>
        public string DbColumnNameForPhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "SecurityStamp".
        /// </summary>
        public string DbColumnNameForSecurityStamp { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "TwoFactorEnabled".
        /// </summary>
        public string DbColumnNameForTwoFactorEnabled { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "UserName".
        /// </summary>
        public string DbColumnNameForUserName { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "NormalizedEmail".
        /// </summary>
        public string DbIndexForNormalizedEmail { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "NormalizedUserName".
        /// </summary>
        public string DbUniqueIndexForNormalizedUserName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        /// <param name="dbColumnNameForNormalizedEmail">Имя колонки в базе данных для поля "NormalizedEmail".</param>
        /// <param name="dbColumnNameForNormalizedUserName">Имя колонки в базе данных для поля "NormalizedUserName".</param>
        public DataBaseSettingUser(
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForNormalizedEmail = null,
            string dbColumnNameForNormalizedUserName = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;

            DbColumnNameForNormalizedEmail = dbColumnNameForNormalizedEmail
                ?? nameof(DataBaseObjectUser.NormalizedEmail);
            
            DbColumnNameForNormalizedUserName = dbColumnNameForNormalizedUserName
                ?? nameof(DataBaseObjectUser.NormalizedUserName);

            DbIndexForNormalizedEmail = CreateNameOfIndex(
                DbTable,
                DbColumnNameForNormalizedEmail
                );

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForNormalizedUserName = CreateNameOfUniqueIndex(
                DbTable,
                DbColumnNameForNormalizedUserName
                );
        }

        #endregion Constructors
    }
}
