//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Entity.SqlServer.Config
{
    /// <summary>
    /// Данные. Entity Framework. База данных MS SQL Server. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IDataEntitySqlServerConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}