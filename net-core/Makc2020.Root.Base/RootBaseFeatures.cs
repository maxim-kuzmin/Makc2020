//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Resources.Converting;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Data.SqlServer;
using Makc2020.Data.Base;
using Makc2020.Data.Entity;
using Makc2020.Data.Entity.SqlServer;
using Makc2020.Host.Base;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;
using Makc2020.Host.Base.Parts.Ldap;
using Makc2020.Host.Base.Parts.Ldap.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Successes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Root.Base
{
    /// <summary>
    /// Корень. Основа. Функциональности.
    /// </summary>
    public abstract class RootBaseFeatures
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа.
        /// </summary>
        public CoreBaseFeature CoreBase { get; set; }

        /// <summary>
        /// Ядро. Данные. SQL Server.
        /// </summary>
        public CoreDataSqlServerFeature CoreDataSqlServer { get; set; }

        /// <summary>
        /// Данные. Основа.
        /// </summary>
        public DataBaseFeature DataBase { get; set; }

        /// <summary>
        /// Данные. Entity Framework.
        /// </summary>
        public DataEntityFeature DataEntity { get; set; }

        /// <summary>
        /// Данные. Entity Framework. SQL Server.
        /// </summary>
        public DataEntitySqlServerFeature DataEntitySqlServer { get; set; }

        /// <summary>
        /// Хост. Основа.
        /// </summary>
        public HostBaseFeature HostBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonFeatures">Обобщённые функциональности.</param>
        public RootBaseFeatures(IEnumerable<ICoreBaseCommonFeature> commonFeatures)
        {
            if (commonFeatures != null && commonFeatures.Any())
            {
                foreach (var commonFeature in commonFeatures)
                {
                    TrySetFeature(commonFeature);
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
            DataBase?.ConfigureServices(services);
            CoreDataSqlServer?.ConfigureServices(services);
            DataEntity?.ConfigureServices(services);
            DataEntitySqlServer?.ConfigureServices(services);
            HostBase?.ConfigureServices(services);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public virtual void InitConfig(CoreBaseEnvironment environment)
        {
            DataEntitySqlServer?.InitConfig(environment);
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

            DataEntitySqlServer?.InitContext(new DataEntitySqlServerExternals
            {
                DataBaseSettings = DataBase?.Context.Settings,
                Environment = environment
            });

            DataEntity?.InitContext(new DataEntityExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                DataEntityDbFactory = DataEntitySqlServer?.Context.DbFactory
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
        /// Попробовать установить функциональность.
        /// </summary>
        /// <param name="commonFeature">Обобщённая функциональность.</param>
        /// <returns>Результат установки.</returns>
        protected virtual bool TrySetFeature(ICoreBaseCommonFeature commonFeature)
        {
            if (TrySet<CoreBaseFeature>(x => CoreBase = x, commonFeature)) return true;
            if (TrySet<CoreDataSqlServerFeature>(x => CoreDataSqlServer = x, commonFeature)) return true;
            if (TrySet<DataBaseFeature>(x => DataBase = x, commonFeature)) return true;
            if (TrySet<DataEntityFeature>(x => DataEntity = x, commonFeature)) return true;
            if (TrySet<DataEntitySqlServerFeature>(x => DataEntitySqlServer = x, commonFeature)) return true;
            if (TrySet<HostBaseFeature>(x => HostBase = x, commonFeature)) return true;

            return false;
        }

        /// <summary>
        /// Попробовать установить.
        /// </summary>
        /// <typeparam name="TFeature">Тип функциональности.</typeparam>        
        /// <param name="actionSet">Действие по установке функциональности.</param>
        /// <param name="commonFeature">Обобщённая функциональность.</param>        
        /// <returns>Результат установки.</returns>
        protected bool TrySet<TFeature>(Action<TFeature> actionSet, ICoreBaseCommonFeature commonFeature)
        {
            if (commonFeature is TFeature)
            {
                actionSet.Invoke((TFeature)commonFeature);

                return true;
            }

            return false;
        }

        #endregion Protected methods
    }
}
