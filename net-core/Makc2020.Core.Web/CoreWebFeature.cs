//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Функциональность.
    /// </summary>
    public abstract class CoreWebFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreWebContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(CoreWebExternals externals)
        {
            Context = new CoreWebContext(externals);
        }

        #endregion Public methods
    }
}