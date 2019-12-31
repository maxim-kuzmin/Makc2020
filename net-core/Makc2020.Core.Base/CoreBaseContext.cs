//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Контекст.
    /// </summary>
    public class CoreBaseContext
    {
        #region Properties

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public CoreBaseResources Resources { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public CoreBaseContext(CoreBaseExternals externals)
        {
            Resources = new CoreBaseResources(
                externals.ResourceConvertingLocalizer,
                externals.ResourceErrorsLocalizer
                );
        }

        #endregion Constructor
    }
}
