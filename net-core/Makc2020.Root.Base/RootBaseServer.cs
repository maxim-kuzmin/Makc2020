//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Jobs.Database.Migrate;
using Makc2020.Data.Entity.Jobs.TestData.Seed;
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
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootBaseServer<TContext, TModules, TConfigurator> : ICoreBaseCommonServer
        where TContext : RootBaseContext<TModules>
        where TModules : RootBaseModules
        where TConfigurator : RootBaseConfigurator<TContext, TModules>
    {
        #region Constants

        /// <summary>
        /// Имя культуры.
        /// </summary>
        protected const string CULTURE_NAME = "ru";

        #endregion Constants

        #region Fields

        private readonly ReaderWriterLockSlim contextLocker = new ReaderWriterLockSlim();
        private readonly ReaderWriterLockSlim databaseLocker = new ReaderWriterLockSlim();

        #endregion Fields

        #region Events

        /// <inheritdoc/>
        public event EventHandler AfterInit;

        #endregion Events

        #region Properties

        private TContext Context { get; set; }

        private bool IsDatabaseInitialized { get; set; }

        private IServiceProvider ServiceProvider { get; set; }

        private IServiceScope ServiceScope { get; set; }

        /// <summary>
        /// Признак необходимости проведения миграции базы данных.
        /// </summary>
        protected bool IsMigrateDatabaseEnabled { get; set; }

        /// <summary>
        /// Признак необходимости добавления пользователей и ролей по-умолчанию.
        /// </summary>
        protected bool IsSeedAuthEnabled { get; set; }

        /// <summary>
        /// Признак необходимости добавления тестовых данных.
        /// </summary>
        protected bool IsSeedTestDataEnabled { get; set; }

        /// <summary>
        /// Модули.
        /// </summary>
        protected TModules Modules { get; private set; }

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
            contextLocker.EnterReadLock();

            try
            {
                return Context;
            }
            finally
            {
                contextLocker.ExitReadLock();
            }
        }

        /// <inheritdoc/>
        public void Init()
        {
            contextLocker.EnterWriteLock();

            try
            {
                var services = CreateServices();

                UseServiceProvider(services.BuildServiceProvider());

                InitContext();

                OnAfterInit(EventArgs.Empty);
            }
            finally
            {
                contextLocker.ExitWriteLock();
            }
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var configurator = CreateConfigurator();

            Modules = CreateModules(configurator.CreateCommonModuleList());

            Modules?.InitConfig(Environment);

            Modules?.ConfigureServices(services);

            InitConfigurator(configurator);

            configurator.ConfigureServices(services);
        }

        /// <summary>
        /// Обработать событие запуска.
        /// </summary>
        public virtual void OnStarted()
        {
            Logger.LogDebug("RootBaseServer.OnStarted begin");

            EnsureInitialization();

            var context = GetContext();

            context.InitCurrentCulture(CULTURE_NAME);

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
        /// Создать модули.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        protected abstract TModules CreateModules(IEnumerable<ICoreBaseCommonModule> commonModules);

        /// <summary>
        /// Обеспечить инициализацию.
        /// </summary>
        protected virtual void EnsureInitialization()
        {
            EnsureContextInitialization();
            EnsureDatabaseInitialization();
        }

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

            configurator.DataEntityDbContextEnable(GetService<DataEntityDbFactory>);

            IsMigrateDatabaseEnabled = true;

#if TEST || DEBUG
            IsSeedTestDataEnabled = true;
#endif

            configurator.IdentityEnable();
            
            IsSeedAuthEnabled = true;
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

        private void EnsureContextInitialization()
        {
            contextLocker.EnterUpgradeableReadLock();

            try
            {
                if (Context == null)
                {
                    contextLocker.EnterWriteLock();

                    try
                    {
                        Modules?.OnAppStarted();

                        InitContext();

                        OnAfterInit(EventArgs.Empty);
                    }
                    finally
                    {
                        contextLocker.ExitWriteLock();
                    }
                }
            }
            finally
            {
                contextLocker.ExitUpgradeableReadLock();
            }
        }

        private void EnsureDatabaseInitialization()
        {
            databaseLocker.EnterUpgradeableReadLock();

            try
            {
                if (!IsDatabaseInitialized)
                {
                    databaseLocker.EnterWriteLock();

                    try
                    {
                        if (IsMigrateDatabaseEnabled)
                        {
                            MigrateDatabase();
                        }

                        if (IsSeedTestDataEnabled)
                        {
                            SeedTestData();
                        }

                        if (IsSeedAuthEnabled)
                        {
                            SeedAuth();
                        }

                        IsDatabaseInitialized = true;
                    }
                    finally
                    {
                        databaseLocker.ExitWriteLock();
                    }
                }
            }
            finally
            {
                databaseLocker.ExitUpgradeableReadLock();
            }
        }

        private void InitContext()
        {
            Context = CreateContext();

            Modules?.InitContext(ServiceProvider, Environment);
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

        private void SeedTestData()
        {
            var job = GetService<DataEntityJobTestDataSeedService>();

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

        #endregion Private methods
    }
}
