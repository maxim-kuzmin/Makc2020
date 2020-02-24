//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Data.SqlServer;
using Makc2020.Data.Base;
using Makc2020.Data.Entity;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Ext;
using Makc2020.Data.Entity.SqlServer;
using Makc2020.Host.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Base
{
    /// <summary>
    /// Корень. Основа. Конфигуратор.
    /// </summary>
    public abstract class RootBaseConfigurator<TContext, TModules>
        where TContext : RootBaseContext<TModules>
        where TModules : RootBaseModules
    {
        #region Properties

        private bool DataEntityDbContextIsEnabled
        {
            get
            {
                return FuncGetDataEntityDbFactory != null;
            }
        }

        private Func<DataEntityDbFactory> FuncGetDataEntityDbFactory { get; set; }

        /// <summary>
        /// Идентичность. Признак включения.
        /// </summary>
        protected bool IdentityIsEnabled { get; private set; }

        /// <summary>
        /// Локализация. Признак включения.
        /// </summary>
        protected bool LocalizationIsEnabled { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).CoreBase);
            services.AddTransient(x => GetContext(x).DataBase);
            services.AddTransient(x => GetContext(x).DataEntity);
            services.AddTransient(x => GetContext(x).DataEntitySqlServer);
            services.AddTransient(x => GetContext(x).HostBase);

            if (LocalizationIsEnabled)
            {
                services.AddLocalization(options => { options.ResourcesPath = "ResourceFiles"; });
            }

            if (DataEntityDbContextIsEnabled)
            {
                services.DataEntityExtConfigureDbContext(FuncGetDataEntityDbFactory);

                if (IdentityIsEnabled)
                {
                    services.DataEntityExtConfigureIdentity();
                }
            }
        }

        /// <summary>
        /// Создать список обобщённых модулей.
        /// </summary>
        /// <returns>Список обобщённых модулей.</returns>
        public virtual List<ICoreBaseCommonModule> CreateCommonModuleList()
        {
            var result = new List<ICoreBaseCommonModule>();

            var modules = new ICoreBaseCommonModule[]
            {
                new CoreBaseModule(),
                new CoreDataSqlServerModule(),
                new DataBaseModule(),
                new DataEntityModule(),
                new DataEntitySqlServerModule(),
                new HostBaseModule()
            };

            result.AddRange(modules);

            return result;
        }

        /// <summary>
        /// Данные. Entity Framework. База данных. Контекст. Отключить.
        /// </summary>
        public void DataEntityDbContextDisable()
        {
            FuncGetDataEntityDbFactory = null;
        }

        /// <summary>
        /// Данные. Entity Framework. База данных. Контекст. Включить.
        /// </summary>
        /// <param name="funcGetDataEntityDbFactory">Функция получения. Данные. Entity Framework. База данных. Фабрика.</param>
        public void DataEntityDbContextEnable(Func<DataEntityDbFactory> funcGetDataEntityDbFactory)
        {
            FuncGetDataEntityDbFactory = funcGetDataEntityDbFactory;
        }

        /// <summary>
        /// Идентичность. Отключить.
        /// </summary>
        public void IdentityDisable()
        {
            IdentityIsEnabled = false;
        }

        /// <summary>
        /// Идентичность. Включить.
        /// </summary>
        public void IdentityEnable()
        {
            IdentityIsEnabled = true;
        }

        /// <summary>
        /// Локализация. Отключить.
        /// </summary>
        public void LocalizationDisable()
        {
            LocalizationIsEnabled = false;
        }

        /// <summary>
        /// Локализация. Включить.
        /// </summary>
        public void LocalizationEnable()
        {
            LocalizationIsEnabled = true;
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Получить контекст.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        /// <returns>Контекст.</returns>
        protected TContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<TContext>();
        }

        #endregion Protected methods
    }
}
