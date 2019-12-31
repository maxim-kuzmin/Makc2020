//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Функциональность.
    /// </summary>
    public abstract class DataBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataBaseContext Context { get; private set; } = new DataBaseContext();

        #endregion Properties
    }
}