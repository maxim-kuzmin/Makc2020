//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyTree.Base.Config
{
    /// <summary>
    /// Мод "DummyTree". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModDummyTreeBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        #endregion Properties
    }
}