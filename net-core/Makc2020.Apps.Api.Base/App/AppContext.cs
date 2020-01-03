//Author Maxim Kuzmin//makc//

using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Logging;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppApiBaseContext<RootAppApiBaseModules>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(RootAppApiBaseModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
