//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.DependencyInjection;
using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Mods.IdentityServer.Base;
using Makc2020.Mods.IdentityServer.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using Makc2020.Root.Base;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.IdentityServer.Base
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Основа. Модули.
    /// </summary>
    public class RootAppIdentityServerBaseModules : RootBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "IdentityServer". Основа.
        /// </summary>
        public ModIdentityServerBaseModule ModIdentityServerBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootAppIdentityServerBaseModules(IEnumerable<ICoreBaseCommonModule> commonModules)
            : base(commonModules)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ModIdentityServerBase?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            ModIdentityServerBase?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            ModIdentityServerBase?.InitContext(new ModIdentityServerBaseExternals
            {
                ResourceErrorsLocalizer = GetLocalizer<ModIdentityServerBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModIdentityServerBaseResourceSuccesses>(serviceProvider)
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            base.TrySetModule(commonModule);

            if (TrySet<ModIdentityServerBaseModule>(x => ModIdentityServerBase = x, commonModule)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
