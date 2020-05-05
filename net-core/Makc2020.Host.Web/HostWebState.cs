//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Host.Base;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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

        /// <inheritdoc/>
        public override void FillLoggerState(List<KeyValuePair<string, object>> loggerState)
        {
            base.FillLoggerState(loggerState);

            loggerState.Add(KeyValuePair.Create<string, object>("HostWebState.IP", IP));
        }

        #endregion Public methods
    }
}
