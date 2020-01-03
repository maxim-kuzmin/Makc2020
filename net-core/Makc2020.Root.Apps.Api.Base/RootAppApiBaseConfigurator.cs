//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Mods.Auth.Base;
using Makc2020.Mods.DummyMain.Base;
using Makc2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public abstract class RootAppApiBaseConfigurator<TContext, TFeatures> : RootBaseConfigurator<TContext, TFeatures>
        where TContext: RootAppApiBaseContext<TFeatures>
        where TFeatures: RootAppApiBaseFeatures
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).ModAuthBase);
            services.AddTransient(x => GetContext(x).ModDummyMainBase);
        }

        /// <inheritdoc/>
        public override List<ICoreBaseCommonFeature> CreateCommonFeatureList()
        {
            var result = base.CreateCommonFeatureList();

            var features = new ICoreBaseCommonFeature[]
            {
                new ModAuthBaseFeature(),
                new ModDummyMainBaseFeature()
            };

            result.AddRange(features);

            return result;
        }

        #endregion Public methods
    }
}
