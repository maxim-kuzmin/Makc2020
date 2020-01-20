//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Mods.Automation.Base;
using Makc2020.Mods.Automation.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Resources.Successes;
using Makc2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Automation.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Модули.
    /// </summary>
    public class RootAppAutomationBaseModules : RootBaseModules
    {
        #region Properties

        /// <summary>
        /// Мод "Automation". Основа.
        /// </summary>
        public ModAutomationBaseModule ModAutomationBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootAppAutomationBaseModules(IEnumerable<ICoreBaseCommonModule> commonModules)
            : base(commonModules)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ModAutomationBase?.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            ModAutomationBase?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            ModAutomationBase?.InitContext(new ModAutomationBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                ResourceErrorsLocalizer = GetLocalizer<ModAutomationBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModAutomationBaseResourceSuccesses>(serviceProvider)
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            base.TrySetModule(commonModule);

            if (TrySet<ModAutomationBaseModule>(x => ModAutomationBase = x, commonModule)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
