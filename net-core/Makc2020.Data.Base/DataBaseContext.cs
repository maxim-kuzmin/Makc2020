//Author Maxim Kuzmin//makc//

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Контекст.
    /// </summary>
    public class DataBaseContext
    {
        #region Properties

        /// <summary>
        /// Настройки.
        /// </summary>
        public DataBaseSettings Settings => DataBaseSettings.Instance;

        #endregion Properties
    }
}