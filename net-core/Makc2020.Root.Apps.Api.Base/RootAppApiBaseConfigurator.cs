//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Mods.Auth.Base.DiAutofac;
using Makc2020.Mods.DummyMain.Base.DiAutofac;
using Makc2020.Root.Base.DiAutofac;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Конфигуратор.
    /// </summary>
    public abstract class RootAppApiBaseConfigurator : RootBaseDiAutofacConfigurator
    {
        #region Public methods

        /// <inheritdoc/>
        public override List<ICoreBaseCommonFeature> CreateCommonFeatureList()
        {
            var result = base.CreateCommonFeatureList();

            var features = new ICoreBaseCommonFeature[]
            {
                new ModAuthBaseDiAutofacFeature(),
                new ModDummyMainBaseDiAutofacFeature()
            };

            result.AddRange(features);

            return result;
        }

        #endregion Public methods
    }
}
