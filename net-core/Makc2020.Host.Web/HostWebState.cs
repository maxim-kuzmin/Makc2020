//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Host.Base;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Microsoft.AspNetCore.Http;

namespace Makc2020.Host.Web
{
    /// <summary>
    /// Хост. Веб. Состояние.
    /// </summary>
    public class HostWebState : HostBaseState
    {
        #region Properties

        /// <summary>
        /// IP-адрес.
        /// </summary>
        public string IP { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="httpContext">HTTP-контекст.</param>
        /// <returns>Состояние.</returns>
        public static HostWebState Create(HttpContext httpContext)
        {
            return new HostWebState
            {
                User = httpContext.User.HostBasePartAuthExtCreateUser(),
                IP = httpContext.Connection.RemoteIpAddress?.CoreBaseExtConvertFromIPToV4String()
            };
        }

        #endregion Public methods
    }
}
