//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Principal;

namespace Makc2020.Core.Web.Api
{
    /// <summary>
    /// Ядро. Веб. API. Контроллер.
    /// </summary>
    public abstract class CoreWebApiController : ControllerBase
    {
        #region Properties

        private IPrincipal Principal { get; set; }

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
        /// <param name="principal">Принципал.</param>
        public CoreWebApiController(ILogger logger, IPrincipal principal = null)
        {
            Logger = logger;
            Principal = principal;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить принципал. 
        /// </summary>
        /// <returns>Принципал.</returns>
        public IPrincipal GetPrincipal()
        {
            return (Principal is CoreBaseAuthNullPrincipal) ? User : Principal;
        }

        #endregion Public methods
    }
}
