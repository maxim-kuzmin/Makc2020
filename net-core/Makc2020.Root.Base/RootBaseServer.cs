//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Jobs.Database.Migrate;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Jobs.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Makc2020.Root.Base
{
    /// <summary>
    /// Корень. Основа. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootBaseServer<TContext, TFeatures, TConfigurator> : ICoreBaseCommonServer
        where TContext : RootBaseContext<TFeatures>
        where TFeatures : RootBaseFeatures
        where TConfigurator : RootBaseConfigurator
    {
        #region Constants

        /// <summary>
        /// Имя культуры.
        /// </summary>
        protected const string CULTURE_NAME = "ru";

        #endregion Constants

        #region Fields

        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        #endregion Fields

        #region Events

        /// <inheritdoc/>
        public event EventHandler AfterInit;

        #endregion Events

        #region Properties

        private TContext Context { get; set; }

        private IServiceProvider ServiceProvider { get; set; }

        private IServiceScope ServiceScope { get; set; }

        /// <summary>
        /// Функциональности.
        /// </summary>
        protected TFeatures Features { get; private set; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger Logger { get; private set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        public CoreBaseEnvironment Environment { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить конфигурацию приложения.
        /// </summary>
        /// <param name="configurationBuilder">Построитель конфигурации.</param>
        /// <param name="basePath">
        /// Абсолютный путь к папке, относительно которой указываются пути к файлам.
        /// </param>
        /// <param name="environmentName">Имя окружения.</param>
        public void ConfigureAppConfiguration(
            IConfigurationBuilder configurationBuilder,
            string basePath,
            string environmentName
            )
        {
            Environment = new CoreBaseEnvironment
            {
                BasePath = basePath,
                Name = environmentName
            };

            var appConfigFilePath = Path.Combine(Environment.BasePath, "ConfigFiles", "App.config");

            configurationBuilder.CoreBaseExtConfigAddFromJsonFile(
                appConfigFilePath,
                Environment.Name
                ).AddEnvironmentVariables();
        }

        /// <summary>
        /// Получить контекст.
        /// </summary>
        public TContext GetContext()
        {
            locker.EnterReadLock();

            try
            {
                return Context;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }

        /// <inheritdoc/>
        public void Init()
        {
            locker.EnterWriteLock();

            try
            {
                var services = CreateServices();

                UseServiceProvider(services.BuildServiceProvider());

                InitContext();
            }
            finally
            {
                locker.ExitWriteLock();
            }

            OnAfterInit(EventArgs.Empty);
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var configurator = CreateConfigurator();

            Features = CreateFeatures(configurator.CreateCommonFeatureList());

            Features?.InitConfig(Environment);

            InitConfigurator(configurator);

            configurator.ConfigureServices(services);
        }

        /// <summary>
        /// Обработать событие запуска.
        /// </summary>
        public virtual void OnStarted()
        {
            Logger.LogDebug("RootBaseServer.OnStarted begin");

            Features?.OnAppStarted();

            InitContext();

            var context = GetContext();

            context.InitCurrentCulture(CULTURE_NAME);

            MigrateDatabase();

            SeedAuth();

            Logger.LogDebug("RootBaseServer.OnStarted end");
        }

        /// <summary>
        /// Обработать событие остановки.
        /// </summary>
        public virtual void OnStopped()
        {
            ServiceScope.Dispose();
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать сервисы.
        /// </summary>
        /// <returns>Сервисы.</returns>
        protected virtual IServiceCollection CreateServices()
        {
            var result = new ServiceCollection();

            ConfigureServices(result);

            return result;
        }

        /// <summary>
        /// Создать конфигуратор.
        /// </summary>
        /// <returns>Конфигуратор.</returns>
        protected abstract TConfigurator CreateConfigurator();

        /// <summary>
        /// Создать контекст.
        /// </summary>
        /// <returns>Контекст.</returns>
        protected abstract TContext CreateContext();

        /// <summary>
        /// Создать функциональности.
        /// </summary>
        /// <param name="commonFeatures">Обобщённые функциональности.</param>
        protected abstract TFeatures CreateFeatures(IEnumerable<ICoreBaseCommonFeature> commonFeatures);

        /// <summary>
        /// Получить регистратор.
        /// </summary>
        /// <returns>Регистратор.</returns>
        protected abstract ILogger GetLogger();

        /// <summary>
        /// Обработчик события, возникающего после инициализации.
        /// </summary>
        /// <param name="e">Аргументы события.</param>
        protected void OnAfterInit(EventArgs e)
        {
            var handler = AfterInit;

            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        /// <inheritdoc/>
        protected virtual TService GetService<TService>()
            where TService : class
        {
            return ServiceScope.ServiceProvider.GetService<TService>();
        }

        /// <summary>
        /// Инициализировать конфигуратор.
        /// </summary>
        /// <param name="configurator">Конфигуратор.</param>
        protected virtual void InitConfigurator(TConfigurator configurator)
        {
            configurator.LocalizationEnable();
        }

        /// <summary>
        /// Использовать поставщик сервисов.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        protected virtual void UseServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            ServiceScope = ServiceProvider.CreateScope();

            Logger = GetLogger();
        }

        #endregion Protected methods

        #region Private methods

        private void InitContext()
        {
            Context = CreateContext();

            Features?.InitContext(ServiceProvider, Environment);
        }

        private void MigrateDatabase()
        {
            var job = GetService<DataEntityJobDatabaseMigrateService>();

            if (job != null)
            {
                var result = new CoreBaseExecutionResult();

                try
                {
                    job.Execute().CoreBaseExtTaskWithCurrentCulture(false).GetResult();

                    job.OnSuccess(Logger, result);
                }
                catch (Exception ex)
                {
                    job.OnError(ex, Logger, result);
                }
            }
        }

        private void SeedAuth()
        {
            var job = GetService<HostBasePartAuthJobSeedService>();

            if (job != null)
            {
                var result = new CoreBaseExecutionResult();

                try
                {
                    var input = new HostBasePartAuthJobSeedInput
                    {
                        RoleManager = GetService<RoleManager<DataEntityObjectRole>>(),
                        UserManager = GetService<UserManager<DataEntityObjectUser>>()
                    };

                    job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false).GetResult();

                    job.OnSuccess(Logger, result, input);
                }
                catch (Exception ex)
                {
                    job.OnError(ex, Logger, result);
                }
            }
        }

        #endregion Private methods
    }
}
