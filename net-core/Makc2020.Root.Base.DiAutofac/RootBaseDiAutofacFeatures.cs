//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.DiAutofac;
using Makc2020.Core.Base.Resources.Converting;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Data.SqlServer.DiAutofac;
using Makc2020.Data.Base.DiAutofac;
using Makc2020.Data.Entity;
using Makc2020.Data.Entity.DiAutofac;
using Makc2020.Data.Entity.SqlServer;
using Makc2020.Data.Entity.SqlServer.DiAutofac;
using Makc2020.Host.Base;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;
using Makc2020.Host.Base.DiAutofac;
using Makc2020.Host.Base.Parts.Ldap;
using Makc2020.Host.Base.Parts.Ldap.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Successes;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Base.DiAutofac
{
    /// <summary>
    /// Корень. Основа. Внедрение зависимостей. Autofac. Функциональности.
    /// </summary>
    public class RootBaseDiAutofacFeatures : RootBaseFeatures
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа.
        /// </summary>
        public CoreBaseDiAutofacFeature CoreBase { get; set; }

        /// <summary>
        /// Ядро. Данные. SQL Server.
        /// </summary>
        public CoreDataSqlServerDiAutofacFeature CoreDataSqlServer { get; set; }

        /// <summary>
        /// Данные. Основа.
        /// </summary>
        public DataBaseDiAutofacFeature DataBase { get; set; }

        /// <summary>
        /// Данные. Entity Framework.
        /// </summary>
        public DataEntityDiAutofacFeature DataEntity { get; set; }

        /// <summary>
        /// Данные. Entity Framework. SQL Server.
        /// </summary>
        public DataEntitySqlServerDiAutofacFeature DataEntitySqlServer { get; set; }

        /// <summary>
        /// Хост. Основа.
        /// </summary>
        public HostBaseDiAutofacFeature HostBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonFeatures">Обобщённые функциональности.</param>
        public RootBaseDiAutofacFeatures(IEnumerable<ICoreBaseCommonFeature> commonFeatures)
            : base(commonFeatures)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void InitConfig(CoreBaseEnvironment environment)
        {
            DataEntitySqlServer?.InitConfig(environment);
            HostBase?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
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
        /// Зарегистрировать модуль.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public virtual void RegisterModule(ContainerBuilder builder)
        {
            CoreBase?.Register(builder);
            CoreDataSqlServer?.Register(builder);
            DataBase?.Register(builder);
            DataEntity?.Register(builder);
            DataEntitySqlServer?.Register(builder);
            HostBase?.Register(builder);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override bool TrySetFeature(ICoreBaseCommonFeature commonFeature)
        {
            if (TrySet<CoreBaseDiAutofacFeature>(x => CoreBase = x, commonFeature)) return true;
            if (TrySet<CoreDataSqlServerDiAutofacFeature>(x => CoreDataSqlServer = x, commonFeature)) return true;
            if (TrySet<DataBaseDiAutofacFeature>(x => DataBase = x, commonFeature)) return true;
            if (TrySet<DataEntityDiAutofacFeature>(x => DataEntity = x, commonFeature)) return true;
            if (TrySet<DataEntitySqlServerDiAutofacFeature>(x => DataEntitySqlServer = x, commonFeature)) return true;
            if (TrySet<HostBaseDiAutofacFeature>(x => HostBase = x, commonFeature)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
