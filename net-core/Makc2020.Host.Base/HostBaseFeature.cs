//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Функциональность.
    /// </summary>
    public abstract class HostBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public HostBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public HostBaseContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new HostBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(HostBaseExternals externals)
        {
            Context = new HostBaseContext(Config, externals);
        }

        #endregion Public methods
    }
}