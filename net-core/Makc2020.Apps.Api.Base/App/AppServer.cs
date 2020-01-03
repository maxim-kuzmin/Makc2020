//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Сервер.
    /// </summary>
    public class AppServer : RootAppApiBaseServer<AppContext, RootAppApiBaseModules, AppConfigurator>
    {
        #region Fields

        private static readonly Lazy<AppServer> lazy = new Lazy<AppServer>(() => new AppServer());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static AppServer Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        #endregion Properties

        #region Constructors

        private AppServer()
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Конфигурировать.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        public void Configure(IServiceProvider serviceProvider)
        {
            UseServiceProvider(serviceProvider);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override AppConfigurator CreateConfigurator()
        {
            return new AppConfigurator();
        }

        /// <inheritdoc/>
        protected sealed override AppContext CreateContext()
        {
            return new AppContext(Modules, GetService<ILogger<AppContext>>());
        }

        /// <inheritdoc/>
        protected sealed override RootAppApiBaseModules CreateModules(
            IEnumerable<ICoreBaseCommonModule> commonModules
            )
        {
            return new RootAppApiBaseModules(commonModules);
        }

        /// <inheritdoc/>
        protected sealed override ILogger GetLogger()
        {
            return GetService<ILogger<AppServer>>();
        }

        #endregion Protected methods
    }
}
