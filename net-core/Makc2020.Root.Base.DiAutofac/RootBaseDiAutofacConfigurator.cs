//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.DiAutofac;
using Makc2020.Core.Data.SqlServer.DiAutofac;
using Makc2020.Data.Base.DiAutofac;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.DiAutofac;
using Makc2020.Data.Entity.Ext;
using Makc2020.Data.Entity.SqlServer.DiAutofac;
using Makc2020.Host.Base.DiAutofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Base.DiAutofac
{
    /// <summary>
    /// Корень. Основа. Внедрение зависимостей. Autofac. Конфигуратор.
    /// </summary>
    public abstract class RootBaseDiAutofacConfigurator : RootBaseConfigurator
    {
        #region Properties

        private Func<DataEntityDbFactory> FuncGetDataEntityDbFactory { get; set; }

        private bool DataEntityDbContextIsEnabled
        { 
            get 
            {
                return FuncGetDataEntityDbFactory != null;
            } 
        }

        private bool IdentityIsEnabled { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            if (DataEntityDbContextIsEnabled)
            {
                services.DataEntityExtConfigureDbContext(FuncGetDataEntityDbFactory);

                if (IdentityIsEnabled)
                {
                    services.DataEntityExtConfigureIdentity();
                }
            }
        }

        /// <inheritdoc/>
        public override List<ICoreBaseCommonFeature> CreateCommonFeatureList()
        {
            var result = base.CreateCommonFeatureList();

            var features = new ICoreBaseCommonFeature[]
            {
                new CoreBaseDiAutofacFeature(),
                new CoreDataSqlServerDiAutofacFeature(),
                new DataBaseDiAutofacFeature(),
                new DataEntityDiAutofacFeature(),
                new DataEntitySqlServerDiAutofacFeature(),
                new HostBaseDiAutofacFeature()                
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

        #endregion Public methods
    }
}
