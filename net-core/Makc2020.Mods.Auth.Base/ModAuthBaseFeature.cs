//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Функциональность.
    /// </summary>
    public class ModAuthBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModAuthBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModAuthBaseContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModAuthBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModAuthBaseExternals externals)
        {
            Context = new ModAuthBaseContext(Config, externals);
        }

        #endregion Public methods
    }
}