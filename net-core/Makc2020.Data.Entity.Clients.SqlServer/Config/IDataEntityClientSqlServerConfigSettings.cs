//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Entity.Clients.SqlServer.Config
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IDataEntityClientSqlServerConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}