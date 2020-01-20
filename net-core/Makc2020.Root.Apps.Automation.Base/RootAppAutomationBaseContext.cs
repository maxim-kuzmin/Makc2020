//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base;
using Makc2020.Root.Base;
using Microsoft.Extensions.Logging;

namespace Makc2020.Root.Apps.Automation.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Контекст.
    /// </summary>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    public class RootAppAutomationBaseContext<TModules> : RootBaseContext<TModules>
        where TModules: RootAppAutomationBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "Automation". Основа.
        /// </summary>
        public ModAutomationBaseContext ModAutomationBase => Modules.ModAutomationBase.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppAutomationBaseContext(TModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
