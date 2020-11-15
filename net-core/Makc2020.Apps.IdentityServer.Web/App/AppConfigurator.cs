//Author Maxim Kuzmin//makc//

using Makc2020.Root.Apps.IdentityServer.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Apps.IdentityServer.Web.Root
{
    /// <summary>
    /// Приложение. Конфигуратор.
    /// </summary>
    public class AppConfigurator : RootAppIdentityServerWebConfigurator<AppContext, RootAppIdentityServerWebModules>
    {
        #region Constants

        public const string CORS_POLICY_NAME = "MyPolicy";

        #endregion Constants

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => AppServer.Instance.GetContext());

            var mvcBuilder = services.AddControllersWithViews();

            if (LocalizationIsEnabled)
            {
                mvcBuilder.AddDataAnnotationsLocalization().AddViewLocalization();
            }

            // configures IIS out-of-proc settings (see https://github.com/aspnet/AspNetCore/issues/14882)
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // configures IIS in-proc settings
            services.Configure<IISServerOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            services.Configure<CorsOptions>(options =>
                options.AddPolicy(
                    CORS_POLICY_NAME,
                    corsBuilder => corsBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    //.AllowCredentials()
                    )
                );
        }

        #endregion Public methods
    }
}
