//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Ext;
using Makc2020.Root.Apps.Api.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

namespace Makc2020.Apps.Api.Web.App
{
    /// <summary>
    /// Приложение. Сервер.
    /// </summary>
    public class AppServer : RootAppApiWebServer<AppContext, AppFeatures, AppConfigurator>
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

                    if (!Path.HasExtension(path) && path.Contains("/api/"))
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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseCors(AppConfigurator.CORS_POLICY_NAME);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
            return new AppContext(Features, GetService<ILogger<AppContext>>());
        }

        /// <inheritdoc/>
        protected sealed override AppFeatures CreateFeatures(
            IEnumerable<ICoreBaseCommonFeature> commonFeatures
            )
        {
            return new AppFeatures(commonFeatures);
        }

        /// <inheritdoc/>
        protected sealed override ILogger GetLogger()
        {
            return GetService<ILogger<AppServer>>();
        }

        /// <inheritdoc/>
        protected sealed override void RegisterModule(ContainerBuilder builder)
        {
            builder.RegisterModule(new AppModule());
        }

        #endregion Protected methods
    }
}
