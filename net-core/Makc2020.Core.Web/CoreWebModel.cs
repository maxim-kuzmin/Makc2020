//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Principal;

namespace Makc2020.Core.Web
{
    /// <summary>
    /// Ядро. Веб. Модель.
    /// </summary>
    public class CoreWebModel
    {
        #region Properties

        /// <summary>
        /// Принципал.
        /// </summary>
        private IPrincipal ExtPrincipal { get; set; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger ExtLogger { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        /// <param name="extPrincipal">Принципал.</param>
        public CoreWebModel(
            ILogger extLogger,
            IPrincipal extPrincipal
            )
        {
            ExtLogger = extLogger;
            ExtPrincipal = extPrincipal;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить принципала.
        /// </summary>
        /// <param name="claimsPrincipal">Принципал с утверждениями.</param>
        /// <returns>Принципал.</returns>
        public IPrincipal GetPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            return (ExtPrincipal is CoreBaseAuthNullPrincipal) ? claimsPrincipal : ExtPrincipal;
        }

        #endregion Public methods
    }
}
