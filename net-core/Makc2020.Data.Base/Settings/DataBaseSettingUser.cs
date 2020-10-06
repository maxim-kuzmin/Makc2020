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
        /// <param name="defaults">Значения по-умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DataBaseSettingUser(
            DataBaseDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbIndexForNormalizedEmail = CreateNameOfIndex(DbTable, nameof(DataBaseObjectUser.NormalizedEmail));

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForNormalizedUserName = CreateNameOfUniqueIndex(DbTable, nameof(DataBaseObjectUser.NormalizedUserName));
        }

        #endregion Constructors
    }
}
