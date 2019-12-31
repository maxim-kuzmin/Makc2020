//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Функциональность.
    /// </summary>
    public class DataEntityFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataEntityContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(DataEntityExternals externals)
        {
            Context = new DataEntityContext(externals);
        }

        #endregion Public methods
    }
}