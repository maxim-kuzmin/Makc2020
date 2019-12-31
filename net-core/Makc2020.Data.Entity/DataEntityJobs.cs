//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Entity.Jobs.Database.Migrate;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Задания.
    /// </summary>
    public class DataEntityJobs
    {
        #region Properties

        /// <summary>
        /// Задание на миграцию базы данных.
        /// </summary>
        public DataEntityJobDatabaseMigrateService JobDatabaseMigrate { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public DataEntityJobs(
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataEntityService service
            )
        {
            JobDatabaseMigrate = new DataEntityJobDatabaseMigrateService(
                service.MigrateDatabase,
                coreBaseResourceErrors
                );
        }

        #endregion Constructor
    }
}
