//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Сервис.
    /// </summary>
    public class DataEntityService
    {
        #region Properties

        private DataEntityDbFactory DbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public DataEntityService(DataEntityDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Мигрировать базу данных.
        /// </summary>
        public async Task MigrateDatabase()
        {
            using var dbContext = DbFactory.CreateDbContext();

            await dbContext.Database.MigrateAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods
    }
}
