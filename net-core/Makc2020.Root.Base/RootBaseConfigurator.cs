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
    public abstract class RootBaseConfigurator<TContext, TFeatures>
        where TContext : RootBaseContext<TFeatures>
        where TFeatures : RootBaseFeatures
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

        private bool IdentityIsEnabled { get; set; }

        private bool LocalizationIsEnabled { get; set; }

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
                services.AddLocalization();
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
        /// Создать список обобщённых функциональностей.
        /// </summary>
        /// <returns>Список обобщённых функциональностей.</returns>
        public virtual List<ICoreBaseCommonFeature> CreateCommonFeatureList()
        {
            var result = new List<ICoreBaseCommonFeature>();

            var features = new ICoreBaseCommonFeature[]
            {
                new CoreBaseFeature(),
                new CoreDataSqlServerFeature(),
                new DataBaseFeature(),
                new DataEntityFeature(),
                new DataEntitySqlServerFeature(),
                new HostBaseFeature()
            };

            result.AddRange(features);

            return result;
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
        /// Идентичность. Включить.
        /// </summary>
        public void IdentityEnable()
        {
            IdentityIsEnabled = true;
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
