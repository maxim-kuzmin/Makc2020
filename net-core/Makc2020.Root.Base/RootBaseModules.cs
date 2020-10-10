//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Resources.Converting;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Data.Clients.PostgreSql;
using Makc2020.Core.Data.Clients.SqlServer;
using Makc2020.Data.Base;
using Makc2020.Data.Entity;
using Makc2020.Data.Entity.Clients.PostgreSql;
using Makc2020.Data.Entity.Clients.SqlServer;
using Makc2020.Data.Entity.Db;
using Makc2020.Host.Base;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;
using Makc2020.Host.Base.Parts.Ldap;
using Makc2020.Host.Base.Parts.Ldap.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Successes;
using Makc2020.Root.Base.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Root.Base
{
    /// <summary>
    /// Корень. Основа. Модули.
    /// </summary>
    public abstract class RootBaseModules
    {
        #region Properties

        private RootBaseEnumDataClients DataClient { get; }

        /// <summary>
        /// Ядро. Основа.
        /// </summary>
        public CoreBaseModule CoreBase { get; set; }

        /// <summary>
        /// Ядро. Данные. Клиенты. PostgreSQL.
        /// </summary>
        public CoreDataClientPostgreSqlModule CoreDataClientPostgreSql { get; set; }

        /// <summary>
        /// Ядро. Данные. Клиенты. SQL Server.
        /// </summary>
        public CoreDataClientSqlServerModule CoreDataClientSqlServer { get; set; }

        /// <summary>
        /// Данные. Entity Framework.
        /// </summary>
        public DataEntityModule DataEntity { get; set; }

        /// <summary>
        /// Данные. Entity Framework. Клиенты. PostgreSQL.
        /// </summary>
        public DataEntityClientPostgreSqlModule DataEntityClientPostgreSql { get; set; }

        /// <summary>
        /// Данные. Entity Framework. Клиенты. SQL Server.
        /// </summary>
        public DataEntityClientSqlServerModule DataEntityClientSqlServer { get; set; }

        /// <summary>
        /// Хост. Основа.
        /// </summary>
        public HostBaseModule HostBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonModules">Обобщённые модули.</param>
        public RootBaseModules(IEnumerable<ICoreBaseCommonModule> commonModules)
        {
            if (commonModules != null && commonModules.Any())
            {
                foreach (var commonModule in commonModules)
                {
                    TrySetModule(commonModule);
                }

                if (DataEntityClientPostgreSql != null)
                {
                    DataClient = RootBaseEnumDataClients.PostgreSql;
                }
                else if(DataEntityClientSqlServer != null)
                {
                    DataClient = RootBaseEnumDataClients.SqlServer;
                }
                else
                {
                    DataClient = RootBaseEnumDataClients.None;
                }
            }
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            CoreBase?.ConfigureServices(services);
            CoreDataClientPostgreSql?.ConfigureServices(services);
            CoreDataClientSqlServer?.ConfigureServices(services);
            DataEntity?.ConfigureServices(services);
            DataEntityClientPostgreSql?.ConfigureServices(services);
            DataEntityClientSqlServer?.ConfigureServices(services);
            HostBase?.ConfigureServices(services);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public virtual void InitConfig(CoreBaseEnvironment environment)
        {
            DataEntity?.InitConfig(environment);
            DataEntityClientPostgreSql?.InitConfig(environment);
            DataEntityClientSqlServer?.InitConfig(environment);
            HostBase?.InitConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        /// <param name="environment">Окружение.</param>
        public virtual void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            CoreBase?.InitContext(new CoreBaseExternals
            {
                ResourceConvertingLocalizer = GetLocalizer<CoreBaseResourceConverting>(serviceProvider),
                ResourceErrorsLocalizer = GetLocalizer<CoreBaseResourceErrors>(serviceProvider)
            });

            DataEntityClientPostgreSql?.InitContext(new DataEntityClientPostgreSqlExternals
            {
                Environment = environment
            });

            DataEntityClientSqlServer?.InitContext(new DataEntityClientSqlServerExternals
            {
                Environment = environment
            });

            DataEntity?.InitContext(new DataEntityExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                CoreBaseDataProvider = GetProviderForDataClient(),
                DataBaseSettings = GetSettingsForDataClient(),
                DataEntityDbFactory = GetDbFactoryForDataClient()
            });

            HostBase?.InitContext(new HostBaseExternals
            {
                PartAuth = new HostBasePartAuthExternals
                {
                    CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                    ResourceErrorsLocalizer = GetLocalizer<HostBasePartAuthResourceErrors>(serviceProvider),
                    ResourceSuccessesLocalizer = GetLocalizer<HostBasePartAuthResourceSuccesses>(serviceProvider)
                },
                PartLdap = new HostBasePartLdapExternals
                {
                    CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                    ResourceErrorsLocalizer = GetLocalizer<HostBasePartLdapResourceErrors>(serviceProvider),
                    ResourceSuccessesLocalizer = GetLocalizer<HostBasePartLdapResourceSuccesses>(serviceProvider)
                }
            });
        }

        /// <summary>
        /// Обработчик события запуска приложения.
        /// </summary>
        public virtual void OnAppStarted()
        {
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Получить фабрику базы данных для клиента данных.
        /// </summary>
        /// <returns>Фабрика базы данных.</returns>
        protected DataEntityDbFactory GetDbFactoryForDataClient()
        {
            return DataClient switch
            {
                RootBaseEnumDataClients.PostgreSql => DataEntityClientPostgreSql.Context.DbFactory,
                RootBaseEnumDataClients.SqlServer => DataEntityClientSqlServer.Context.DbFactory,
                _ => null,
            };
        }

        /// <summary>
        /// Получить поставщика для клиента данных.
        /// </summary>
        /// <returns>Поставщик.</returns>
        protected ICoreBaseDataProvider GetProviderForDataClient()
        {
            return DataClient switch
            {
                RootBaseEnumDataClients.PostgreSql => CoreDataClientPostgreSql.Context.Provider,
                RootBaseEnumDataClients.SqlServer => CoreDataClientSqlServer.Context.Provider,
                _ => null,
            };
        }

        /// <summary>
        /// Получить настройки для клиента данных.
        /// </summary>
        /// <returns>Настройки.</returns>
        protected DataBaseSettings GetSettingsForDataClient()
        {
            return DataClient switch
            {
                RootBaseEnumDataClients.PostgreSql => DataEntityClientPostgreSql.Context.Settings,
                RootBaseEnumDataClients.SqlServer => DataEntityClientSqlServer.Context.Settings,
                _ => null,
            };
        }

        /// <summary>
        /// Получить локализатор.
        /// </summary>
        /// <typeparam name="TResource">Тип ресурса.</typeparam>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        /// <returns>Локализатор.</returns>
        protected IStringLocalizer<TResource> GetLocalizer<TResource>(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IStringLocalizer<TResource>>();
        }

        /// <summary>
        /// Попробовать установить модуль.
        /// </summary>
        /// <param name="commonModule">Обобщённый модуль.</param>
        /// <returns>Результат установки.</returns>
        protected virtual bool TrySetModule(ICoreBaseCommonModule commonModule)
        {
            if (TrySet<CoreBaseModule>(x => CoreBase = x, commonModule)) return true;
            if (TrySet<CoreDataClientPostgreSqlModule>(x => CoreDataClientPostgreSql = x, commonModule)) return true;
            if (TrySet<CoreDataClientSqlServerModule>(x => CoreDataClientSqlServer = x, commonModule)) return true;
            if (TrySet<DataEntityModule>(x => DataEntity = x, commonModule)) return true;
            if (TrySet<DataEntityClientPostgreSqlModule>(x => DataEntityClientPostgreSql = x, commonModule)) return true;
            if (TrySet<DataEntityClientSqlServerModule>(x => DataEntityClientSqlServer = x, commonModule)) return true;
            if (TrySet<HostBaseModule>(x => HostBase = x, commonModule)) return true;

            return false;
        }

        /// <summary>
        /// Попробовать установить.
        /// </summary>
        /// <typeparam name="TModule">Тип модуля.</typeparam>        
        /// <param name="actionSet">Действие по установке модуля.</param>
        /// <param name="commonModule">Обобщённый модуль.</param>        
        /// <returns>Результат установки.</returns>
        protected bool TrySet<TModule>(Action<TModule> actionSet, ICoreBaseCommonModule commonModule)
        {
            if (commonModule is TModule module)
            {
                actionSet.Invoke(module);

                return true;
            }

            return false;
        }

        #endregion Protected methods
    }
}
