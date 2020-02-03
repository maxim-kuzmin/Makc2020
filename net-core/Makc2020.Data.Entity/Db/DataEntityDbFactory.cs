//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Makc2020.Data.Entity.Db
{
    /// <summary>
    /// Данные. Entity Framework. База данных. Фабрика.
    /// </summary>
    public abstract class DataEntityDbFactory : IDesignTimeDbContextFactory<DataEntityDbContext>
    {
        #region Properties

        private DbContextOptions<DataEntityDbContext> Options { get; set; }

        private DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Строка подключения.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        protected CoreBaseEnvironment Environment { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityDbFactory()
        {
            var environment = new CoreBaseEnvironment
            {
                BasePath = System.AppContext.BaseDirectory
            };

            Initialize(CreateConnectionString(), DataBaseSettings.Instance, environment);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="environment">Окружение.</param>
        public DataEntityDbFactory(
            string connectionString,
            DataBaseSettings dataBaseSettings,
            CoreBaseEnvironment environment
            )
        {
            Initialize(connectionString, dataBaseSettings, environment);
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <param name="args">Аргументы.</param>
        /// <returns>Контекст базы данных.</returns>
        public DataEntityDbContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <returns>Контекст базы данных.</returns>
        public DataEntityDbContext CreateDbContext()
        {
            return new DataEntityDbContext(Options, DataBaseSettings);
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать строку подключения.
        /// </summary>
        /// <returns>Строка подключения.</returns>
        protected abstract string CreateConnectionString();

        /// <summary>
        /// Построить опции контекста базы данных.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public abstract void BuildDbContextOptions(DbContextOptionsBuilder builder);

        #endregion Protected methods

        #region Private methods

        private void Initialize(
            string connectionString,
            DataBaseSettings dataBaseSettings,
            CoreBaseEnvironment environment
            )
        {
            ConnectionString = connectionString;
            DataBaseSettings = dataBaseSettings;
            Environment = environment;
            Options = CreateDbContextOptions();
        }

        private DbContextOptions<DataEntityDbContext> CreateDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<DataEntityDbContext>();

            BuildDbContextOptions(builder);

            return builder.Options;
        }

        #endregion Private methods
    }
}