//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Контекст.
    /// </summary>
    public class CoreWebContext
    {
        #region Properties

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public CoreWebResources Resources { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public CoreWebContext(CoreWebExternals externals)
        {
            Resources = new CoreWebResources(externals.ResourceErrorsLocalizer);
        }

        #endregion Constructor
    }
}
