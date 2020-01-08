//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Ext;
using Makc2020.Root.Apps.IdentityServer.Web;
using System;
using System.Collections.Generic;
using System.IO;

namespace Makc2020.Apps.IdentityServer.Web.Root
{
    /// <summary>
    /// Приложение. Сервер.
    /// </summary>
    public class AppServer : RootAppIdentityServerWebServer<AppContext, RootAppIdentityServerWebModules, AppConfigurator>
    {
        #region Fields

        private static readonly Lazy<AppServer> lazy = new Lazy<AppServer>(() => new AppServer());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static AppServer Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        #endregion Properties

        #region Constructors

        private AppServer()
        {
        }

        #endregion Constructors

        #region Public methods

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
            UseServiceProvider(app.ApplicationServices);

            app.Use(async (httpContext, next) =>
            {
                if (httpContext.Request.Path.HasValue)
                {
                    var path = httpContext.Request.Path.Value;

                    if (!Path.HasExtension(path))
                    {
                        OnBeginRequest(httpContext);
                    }
                }

                await next().CoreBaseExtTaskWithCurrentCulture(false);
            });

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopped.Register(OnStopped);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override AppConfigurator CreateConfigurator()
        {
            return new AppConfigurator();
        }

        /// <inheritdoc/>
        protected sealed override AppContext CreateContext()
        {
            return new AppContext(Modules, GetService<ILogger<AppContext>>());
        }

        /// <inheritdoc/>
        protected sealed override RootAppIdentityServerWebModules CreateModules(
            IEnumerable<ICoreBaseCommonModule> commonModules
            )
        {
            return new RootAppIdentityServerWebModules(commonModules);
        }

        /// <inheritdoc/>
        protected sealed override ILogger GetLogger()
        {
            return GetService<ILogger<AppServer>>();
        }

        /// <inheritdoc/>
        protected sealed override void InitConfigurator(AppConfigurator configurator)
        {
            base.InitConfigurator(configurator);

            configurator.ModIdentityServerWebAuthenticationEnable(Modules.ModIdentityServerBase?.Config?.Settings);
        }

        #endregion Protected methods
    }
}
