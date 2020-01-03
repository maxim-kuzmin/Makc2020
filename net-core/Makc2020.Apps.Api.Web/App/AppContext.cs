//Author Maxim Kuzmin//makc//

using Makc2020.Root.Apps.Api.Web;
using Microsoft.Extensions.Logging;

namespace Makc2020.Apps.Api.Web.App
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppApiWebContext<RootAppApiWebFeatures>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="features">Функциональности.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(RootAppApiWebFeatures features, ILogger logger)
            : base(features, logger)
        {
        }

        #endregion Constructors
    }
}
