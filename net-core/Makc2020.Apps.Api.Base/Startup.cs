//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Api.Base.App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Hosting;
using System;
using System.IO;

namespace Makc2020.Apps.Api.Base
{
    /// <summary>
    /// Пуск.
    /// </summary>
    public class Startup
    {
        #region Properties

        private static AppServer Server => AppServer.Instance;

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Запустить.
        /// </summary>
        /// <param name="args">Аргументы.</param>        
        public static async void Run(string[] args)
        {
            var basePath = System.AppContext.BaseDirectory;

            var logConfigFilePath = Path.Combine(basePath, "ConfigFiles", "nlog.config");

            // NLog: setup the logger first to catch all errors
            var logger = NLog.LogManager.LoadConfiguration(logConfigFilePath).GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");

                await Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                    .ConfigureHostConfiguration(configurationBuilder =>
                    {
                        configurationBuilder.AddEnvironmentVariables();
                    })
                    .ConfigureAppConfiguration((builderContext, configurationBuilder) =>
                    {
                        Server.ConfigureAppConfiguration(
                            configurationBuilder,
                            basePath,
                            builderContext.HostingEnvironment.EnvironmentName
                            );
                    })
                    .ConfigureLogging(loggingBuilder =>
                    {
                        loggingBuilder.ClearProviders();
                        loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                    })
                    .UseNLog()
                    .ConfigureServices(services => Server.ConfigureServices(services))
                    .RunConsoleAsync();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");

                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        #endregion Public methods
    }
}