//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Функциональность.
    /// </summary>
    public abstract class CoreCachingFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public CoreCachingConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public CoreCachingContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new CoreCachingConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(CoreCachingExternals externals)
        {
            Context = new CoreCachingContext(Config, externals);
        }

        #endregion Public methods
    }
}