//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Makc2020.Core.Web.Api
{
    /// <summary>
    /// Ядро. Веб. API. Контроллер.
    /// </summary>
    public abstract class CoreWebApiController : ControllerBase
    {
        #region Properties

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger Logger { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        public CoreWebApiController(ILogger logger)
        {
            Logger = logger;
        }

        #endregion Constructors
    }
}
