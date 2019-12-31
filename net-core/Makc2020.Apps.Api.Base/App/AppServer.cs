//Author Maxim Kuzmin//makc//

using Autofac;
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
    public class AppServer : RootAppApiBaseServer<AppContext, AppFeatures, AppConfigurator>
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
            return new AppContext(Features, GetService<ILogger<AppContext>>());
        }

        /// <inheritdoc/>
        protected sealed override AppFeatures CreateFeatures(
            IEnumerable<ICoreBaseCommonFeature> commonFeatures
            )
        {
            return new AppFeatures(commonFeatures);
        }

        /// <inheritdoc/>
        protected sealed override ILogger GetLogger()
        {
            return GetService<ILogger<AppServer>>();
        }

        /// <inheritdoc/>
        protected sealed override void RegisterModule(ContainerBuilder builder)
        {
            builder.RegisterModule(new AppModule());
        }

        #endregion Protected methods
    }
}
