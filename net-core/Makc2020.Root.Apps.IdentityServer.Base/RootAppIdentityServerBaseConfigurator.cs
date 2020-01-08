//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Mods.IdentityServer.Base;
using Makc2020.Root.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.IdentityServer.Base
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Основа. Конфигуратор.
    /// </summary>
    ///<typeparam name="TContext">Тип контекста.</typeparam>
    ///<typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppIdentityServerBaseConfigurator<TContext, TModules> : RootBaseConfigurator<TContext, TModules>
        where TContext : RootAppIdentityServerBaseContext<TModules>
        where TModules : RootAppIdentityServerBaseModules
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient(x => GetContext(x).ModIdentityServerBase);
        }

        /// <inheritdoc/>
        public override List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = base.CreateCommonModuleList();

            var modules = new ICoreBaseCommonModule[]
            {
                new ModIdentityServerBaseModule()
            };

            result.AddRange(modules);

            return result;
        }

        #endregion Public methods
    }
}
