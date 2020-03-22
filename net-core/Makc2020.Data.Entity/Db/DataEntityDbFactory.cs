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

        /// <summary>
        /// Строка подключения.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        protected CoreBaseEnvironment Environment { get; private set; }

        /// <summary>
        /// Опции.
        /// </summary>
        protected DbContextOptions<DataEntityDbContext> Options { get; private set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        protected DataBaseSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataEntityDbFactory()
        {
            Initialize(null, null, null);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="settings">Настройки.</param>
        /// <param name="environment">Окружение.</param>
        public DataEntityDbFactory(
            string connectionString,
            DataBaseSettings settings,
            CoreBaseEnvironment environment
            )
        {
            Initialize(connectionString, settings, environment);
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
        public abstract DataEntityDbContext CreateDbContext();

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать строку подключения.
        /// </summary>
        /// <returns>Строка подключения.</returns>
        protected abstract string CreateConnectionString();

        /// <summary>
        /// Создать настройки.
        /// </summary>
        /// <returns>Настройки.</returns>
        protected abstract DataBaseSettings CreateSettings();

        /// <summary>
        /// Построить опции контекста базы данных.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public abstract void BuildDbContextOptions(DbContextOptionsBuilder builder);

        #endregion Protected methods

        #region Private methods

        private void Initialize(
            string connectionString,
            DataBaseSettings settings,
            CoreBaseEnvironment environment
            )
        {
            Environment = environment ?? new CoreBaseEnvironment
            {
                BasePath = System.AppContext.BaseDirectory
            };

            Settings = settings ?? CreateSettings();
            ConnectionString = connectionString ?? CreateConnectionString();
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