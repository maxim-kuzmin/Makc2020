//Author Maxim Kuzmin//makc//

using Makc2020.Apps.IdentityServer.Web.Root;
using Makc2020.Core.Base.Ext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.IO;

namespace Makc2020.Apps.IdentityServer.Web
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
        public static void Run(string[] args)
        {
            Run<Startup>(args);
        }

        /// <summary>
        /// Запустить.
        /// </summary>
        /// <typeparam name="TStartup">Тип пуска.</typeparam>
        /// <param name="args">Аргументы.</param>        
        public static void Run<TStartup>(string[] args) where TStartup : class
        {
            var basePath = System.AppContext.BaseDirectory;

            // NLog: setup the logger first to catch all errors
            var logger = NLog.LogManager.LogFactory.CoreBaseExtNLogLoadConfiguration(
                Path.Combine(basePath, "ConfigFiles", "nlog.config"),
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ).GetCurrentClassLogger();

            try
            {
                logger.Debug($"init main: {Environment.MachineName}");

                Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webHostBuilder =>
                    {
                        webHostBuilder.ConfigureAppConfiguration((builderContext, configurationBuilder) =>
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
                        .UseNLog()  // NLog: setup NLog for Dependency injection   
                        .UseStartup<TStartup>();
                    })
                    .Build()
                    .Run();
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

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            Server.ConfigureServices(services);
        }

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="app">Построитель приложения.</param>
        /// <param name="env">Окружение.</param>
        /// <param name="appLifetime">Жизненный цикл приложения.</param>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime
            )
        {
            Server.Configure(app, env, appLifetime);
        }

        #endregion Public methods
    }
}
