//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Функциональность.
    /// </summary>
    public abstract class CoreBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreBaseContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(CoreBaseExternals externals)
        {
            Context = new CoreBaseContext(externals);
        }

        #endregion Public methods
    }
}