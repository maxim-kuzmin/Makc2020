//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Mods.Auth.Web.Api
{
    /// <summary>
    /// Мод "Auth". Веб. API. Модуль.
    /// </summary>
    public class ModAuthWebApiModule : ICoreBaseCommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ModAuthWebApiModel>();
        }

        #endregion Public methods
    }
}