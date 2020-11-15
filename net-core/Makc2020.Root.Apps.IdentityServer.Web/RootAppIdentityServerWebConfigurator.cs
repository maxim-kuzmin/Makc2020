//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Makc2020.Core.Base.Common;
using Makc2020.Mods.IdentityServer.Base.Config;
using Makc2020.Mods.IdentityServer.Web.Ext;
using Makc2020.Mods.IdentityServer.Web.Mvc;
using Makc2020.Root.Apps.IdentityServer.Base;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.IdentityServer.Web
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Веб. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppIdentityServerWebConfigurator<TContext, TModules> : RootAppIdentityServerBaseConfigurator<TContext, TModules>
        where TContext : RootAppIdentityServerWebContext<TModules>
        where TModules : RootAppIdentityServerWebModules
    {
        #region Properties

        private IModIdentityServerBaseConfigSettings ModIdentityServerBaseConfigSettings { get; set; }

        private bool ModIdentityServerWebAuthenticationIsEnabled
        {
            get
            {
                return ModIdentityServerBaseConfigSettings != null;
            }
        }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).ModIdentityServerWebMvc);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.OnAppendCookie = context =>
                {
                    if (context.CookieOptions.SameSite == SameSiteMode.None)
                    {
                        context.CookieOptions.SameSite = SameSiteMode.Strict;
                    }
                };
            });

            if (ModIdentityServerWebAuthenticationIsEnabled)
            {
                services.ModIdentityServerWebExtConfigureAuthentication(ModIdentityServerBaseConfigSettings);
            }
        }

        /// <inheritdoc/>
        public sealed override List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = base.CreateCommonModuleList();

            var modules = new ICoreBaseCommonModule[]
            {
                new ModIdentityServerWebMvcModule()
            };

            result.AddRange(modules);

            return result;
        }

        /// <summary>
        /// Мод "IdentityServer". Веб. Аутентификация. Отключить.
        /// </summary>
        public void ModIdentityServerWebAuthenticationDisable()
        {
            ModIdentityServerBaseConfigSettings = null;
        }

        /// <summary>
        /// Мод "IdentityServer". Веб. Аутентификация. Включить.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public void ModIdentityServerWebAuthenticationEnable(IModIdentityServerBaseConfigSettings configSettings)
        {
            ModIdentityServerBaseConfigSettings = configSettings;
        }

        #endregion Public methods
    }
}
