//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyMain.Base.Config
{
    /// <summary>
    /// Мод "DummyMain". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModDummyMainBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        #endregion Properties
    }
}