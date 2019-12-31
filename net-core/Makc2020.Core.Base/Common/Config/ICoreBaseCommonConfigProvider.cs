//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Config
{
    /// <summary>
    /// Ядро. Основа. Общее. Конфигурация. Поставщик. Интерфейс.
    /// </summary>
    public interface ICoreBaseCommonConfigProvider
    {
        #region Methods

        /// <summary>
        /// Загрузить.
        /// </summary>
        void Load();

        /// <summary>
        /// Сохранить.
        /// </summary>
        void Save();

        #endregion Methods
    }
}
