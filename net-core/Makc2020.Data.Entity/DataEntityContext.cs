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
        /// <param name="externals">Внешнее.</param>
        public DataEntityContext(DataEntityExternals externals)
        {
            Service = new DataEntityService(externals.DataEntityDbFactory);

            Jobs = new DataEntityJobs(
                externals.CoreBaseResourceErrors,
                Service
                );
        }

        #endregion Constructor
    }
}
