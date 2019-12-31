//Author Maxim Kuzmin//makc//

using System;
using System.Security.Principal;

namespace Makc2020.Core.Base.Auth
{
    /// <summary>
    /// Ядро. Основа. Аутентификация. Нулевой принципал.
    /// </summary>
    public class CoreBaseAuthNullPrincipal : IPrincipal
    {
        #region Properties

        /// <inheritdoc/>
        public IIdentity Identity => throw new NotImplementedException();

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public bool IsInRole(string role) => throw new NotImplementedException();

        #endregion Public methods
    }
}