//Author Maxim Kuzmin//makc//

using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Logging;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Контекст.
    /// </summary>    
    public class AppContext : RootAppApiBaseContext<AppFeatures>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="features">Функциональности.</param>
        /// <param name="logger">Регистратор.</param>
        public AppContext(AppFeatures features, ILogger logger)
            : base(features, logger)
        {
        }

        #endregion Constructors
    }
}
