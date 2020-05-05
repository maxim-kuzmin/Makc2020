//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Api.Base.App.Parts.Core.Base.Resources.Errors;
using Makc2020.Apps.Api.Base.App.Parts.Mods.DummyMain.Item.Get;
using Makc2020.Apps.Api.Base.App.Parts.Mods.DummyMain.List.Get;
using Makc2020.Core.Base.Common.App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Хостируемый сервис.
    /// </summary>    
    public class AppHostedService : IHostedService
    {
        #region Properties

        private static AppServer Server => AppServer.Instance;

        private IServiceScope ServiceScope { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public AppHostedService(IServiceProvider serviceProvider)
        {
            Server.Configure(serviceProvider);

            ServiceScope = serviceProvider.CreateScope();
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Server.OnStarted();

            var clients = new CoreBaseCommonAppClient[]
            {
                GetService<AppPartCoreBaseResourceErrorsClient>(),
                GetService<AppPartModDummyMainItemGetClient>(),
                GetService<AppPartModDummyMainListGetClient>()
            };

            foreach (var client in clients)
            {
                client.Run();
            }

            Console.WriteLine();
            Console.Write("Press <Enter> to exit");
            Console.ReadLine();

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Server.OnStopped();

            ServiceScope.Dispose();

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private TService GetService<TService>()
        {
            return ServiceScope.ServiceProvider.GetService<TService>();
        }

        #endregion Private methods
    }
}
