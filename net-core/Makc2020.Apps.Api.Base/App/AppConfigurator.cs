//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Api.Base.App.Samples.Core.Base.Resources;
using Makc2020.Apps.Api.Base.App.Samples.Mods.DummyMain.Base.Jobs;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppApiBaseConfigurator
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient<AppSampleCoreBaseResourceErrors>();
            services.AddTransient<AppSampleModDummyMainBaseJobItemGet>();
            services.AddTransient<AppSampleModDummyMainBaseJobListGet>();

            services.AddHostedService<AppHostedService>();            
        }

        #endregion Public methods
    }
}
