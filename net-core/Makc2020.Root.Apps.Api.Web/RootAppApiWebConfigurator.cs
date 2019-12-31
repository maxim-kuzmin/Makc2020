//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Core.Caching.DiAutofac;
using Makc2020.Core.Web.DiAutofac;
using Makc2020.Mods.Auth.Base.Config;
using Makc2020.Mods.Auth.Web.Ext;
using Makc2020.Mods.DummyMain.Caching.DiAutofac;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Конфигуратор.
    /// </summary>
    public abstract class RootAppApiWebConfigurator : RootAppApiBaseConfigurator
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

            if (ModAuthWebAuthenticationIsEnabled)
            {
                services.ModAuthWebExtConfigureAuthentication(ModAuthBaseConfigSettings);
            }
        }

        /// <inheritdoc/>
        public sealed override List<ICoreBaseCommonFeature> CreateCommonFeatureList()
        {
            var result = base.CreateCommonFeatureList();

            var features = new ICoreBaseCommonFeature[]
            {
                new CoreCachingDiAutofacFeature(),
                new CoreWebDiAutofacFeature(),
                new ModDummyMainCachingDiAutofacFeature()
            };

            result.AddRange(features);

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
