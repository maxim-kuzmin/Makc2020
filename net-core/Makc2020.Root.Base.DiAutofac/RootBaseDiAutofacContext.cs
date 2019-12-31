//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Base;
using Makc2020.Data.Entity;
using Makc2020.Data.Entity.SqlServer;
using Makc2020.Host.Base;
using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Root.Base.DiAutofac
{
    /// <summary>
    /// Корень. Основа. Внедрение зависимостей. Autofac. Контекст.
    /// </summary>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public abstract class RootBaseDiAutofacContext<TFeatures> : RootBaseContext<TFeatures>
        where TFeatures: RootBaseDiAutofacFeatures
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа.
        /// </summary>
        public CoreBaseContext CoreBase => Features.CoreBase.Context;

        /// <summary>
        /// Данные. Основа.
        /// </summary>
        public DataBaseContext DataBase => Features.DataBase.Context;

        /// <summary>
        /// Данные. Entity Framework.
        /// </summary>
        public DataEntityContext DataEntity => Features.DataEntity.Context;

        /// <summary>
        /// Данные. Entity Framework. SQL Server.
        /// </summary>
        public DataEntitySqlServerContext DataEntitySqlServer => Features.DataEntitySqlServer.Context;

        /// <summary>
        /// Хост. Основа.
        /// </summary>
        public HostBaseContext HostBase => Features.HostBase.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="features">Функциональности.</param>
        /// <param name="logger">Регистратор.</param>
        public RootBaseDiAutofacContext(TFeatures features, ILogger logger)
            : base(features, logger)
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override CoreBaseError CreateError(Exception exception)
        {
            return new CoreBaseError(exception, CoreBase.Resources.Errors);
        }

        #endregion Protected methods
    }
}
