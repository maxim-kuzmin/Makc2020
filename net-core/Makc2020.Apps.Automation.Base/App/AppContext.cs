//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;
using Makc2020.Root.Apps.Automation.Base;

namespace Makc2020.Apps.Automation.Base.App
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppAutomationBaseContext<RootAppAutomationBaseModules>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(RootAppAutomationBaseModules modules, CoreBaseLoggingService logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
