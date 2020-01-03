//Author Maxim Kuzmin//makc//

using Makc2020.Root.Apps.Api.Web;
using Microsoft.Extensions.Logging;

namespace Makc2020.Apps.Api.Web.App
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppApiWebContext<RootAppApiWebModules>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(RootAppApiWebModules modules, ILogger logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
