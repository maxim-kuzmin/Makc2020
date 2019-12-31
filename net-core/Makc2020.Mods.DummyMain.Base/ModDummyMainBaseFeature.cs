//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Функциональность.
    /// </summary>
    public class ModDummyMainBaseFeature : ICoreBaseCommonFeature
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModDummyMainBaseConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModDummyMainBaseContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModDummyMainBaseConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModDummyMainBaseExternals externals)
        {
            Context = new ModDummyMainBaseContext(Config, externals);
        }

        #endregion Public methods
    }
}