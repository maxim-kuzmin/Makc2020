//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Entity.Config
{
    /// <summary>
    /// Данные. Entity Framework. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IDataEntityConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        #endregion Properties
    }
}