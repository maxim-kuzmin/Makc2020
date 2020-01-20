//Author Maxim Kuzmin//makc//

using Makc2020.Root.Apps.Automation.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Apps.Automation.Base.App
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppAutomationBaseConfigurator<AppContext, RootAppAutomationBaseModules>
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => AppServer.Instance.GetContext());

            services.AddHostedService<AppHostedService>();            
        }

        #endregion Public methods
    }
}
