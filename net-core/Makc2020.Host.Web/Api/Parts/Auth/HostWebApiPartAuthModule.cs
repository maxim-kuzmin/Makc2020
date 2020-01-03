//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Host.Web.Api.Parts.Auth
{
    /// <summary>
    /// Хост. Beб. API. Часть "Auth". API. Модуль.
    /// </summary>
    public class HostWebApiPartAuthModule : ICoreBaseCommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<HostWebApiPartAuthModel>();
        }

        #endregion Public methods
    }
}