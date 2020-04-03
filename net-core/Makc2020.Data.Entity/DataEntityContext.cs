//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Контекст.
    /// </summary>
    public class DataEntityContext
    {
        #region Properties        

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public DataEntityConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public DataEntityJobs Jobs { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public DataEntityService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public DataEntityContext(DataEntityConfig config, DataEntityExternals externals)
        {
            Config = config;

            Service = new DataEntityService(
                Config.Settings,
                externals.DataEntityDbFactory
                );

            Jobs = new DataEntityJobs(
                externals.CoreBaseResourceErrors,
                Service
                );
        }

        #endregion Constructor
    }
}
