//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Mods.Automation.Base;
using Makc2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Automation.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppAutomationBaseConfigurator<TContext, TModules> : RootBaseConfigurator<TContext, TModules>
        where TContext: RootAppAutomationBaseContext<TModules>
        where TModules: RootAppAutomationBaseModules
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).ModAutomationBase);
        }

        /// <inheritdoc/>
        public override List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = base.CreateCommonModuleList();

            var modules = new ICoreBaseCommonModule[]
            {
                new ModAutomationBaseModule()
            };

            result.AddRange(modules);

            return result;
        }

        #endregion Public methods
    }
}
