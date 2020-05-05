﻿//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Api.Base.App.Parts.Core.Base.Resources.Errors;
using Makc2020.Apps.Api.Base.App.Parts.Mods.DummyMain.Item.Get;
using Makc2020.Apps.Api.Base.App.Parts.Mods.DummyMain.List.Get;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppApiBaseConfigurator<AppContext, RootAppApiBaseModules>
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => AppServer.Instance.GetContext());

            services.AddTransient<AppPartCoreBaseResourceErrorsClient>();
            services.AddTransient<AppPartModDummyMainItemGetClient>();
            services.AddTransient<AppPartModDummyMainListGetClient>();

            services.AddHostedService<AppHostedService>();            
        }

        #endregion Public methods
    }
}
