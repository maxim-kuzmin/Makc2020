//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Core.Caching;
using Makc2020.Host.Web.Api.Parts.Auth;
using Makc2020.Mods.Auth.Base.Config;
using Makc2020.Mods.Auth.Web.Api;
using Makc2020.Mods.Auth.Web.Ext;
using Makc2020.Mods.DummyMain.Caching;
using Makc2020.Mods.DummyMain.Web.Api;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppApiWebConfigurator<TContext, TModules> : RootAppApiBaseConfigurator<TContext, TModules>
        where TContext : RootAppApiWebContext<TModules>
        where TModules : RootAppApiWebModules
    {
        #region Properties

        private IModAuthBaseConfigSettings ModAuthBaseConfigSettings { get; set; }

        private bool ModAuthWebAuthenticationIsEnabled
        {
            get
            {
                return ModAuthBaseConfigSettings != null;
            }
        }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).CoreCaching);
            services.AddTransient(x => GetContext(x).ModDummyMainCaching);

            if (ModAuthWebAuthenticationIsEnabled)
            {
                services.ModAuthWebExtConfigureAuthentication(ModAuthBaseConfigSettings);
            }
        }

        /// <inheritdoc/>
        public sealed override List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = base.CreateCommonModuleList();

            var modules = new ICoreBaseCommonModule[]
            {
                new CoreCachingModule(),
                new HostWebApiPartAuthModule(),
                new ModAuthWebApiModule(),
                new ModDummyMainCachingModule(),
                new ModDummyMainWebApiModule()
            };

            result.AddRange(modules);

            return result;
        }

        /// <summary>
        /// Хост. Веб. Часть "Auth". Включить.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public void HostWebPartAuthenticationEnable(IModAuthBaseConfigSettings configSettings)
        {
            ModAuthBaseConfigSettings = configSettings;
        }

        #endregion Public methods
    }
}
