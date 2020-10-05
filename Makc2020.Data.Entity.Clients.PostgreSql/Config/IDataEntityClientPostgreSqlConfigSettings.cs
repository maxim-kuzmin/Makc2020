//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Entity.Clients.PostgreSql.Config
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IDataEntityClientPostgreSqlConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}