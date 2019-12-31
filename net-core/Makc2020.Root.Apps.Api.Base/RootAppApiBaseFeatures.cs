//Author Maxim Kuzmin//makc//

using Autofac;
using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Mods.Auth.Base;
using Makc2020.Mods.Auth.Base.DiAutofac;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Successes;
using Makc2020.Mods.DummyMain.Base;
using Makc2020.Mods.DummyMain.Base.DiAutofac;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using Makc2020.Root.Base.DiAutofac;
using System;
using System.Collections.Generic;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Функциональности.
    /// </summary>
    public class RootAppApiBaseFeatures : RootBaseDiAutofacFeatures
    {
        #region Properties

        /// <summary>
        /// Мод "Auth". Основа.
        /// </summary>
        public ModAuthBaseDiAutofacFeature ModAuthBase { get; set; }

        /// <summary>
        /// Мод "DummyMain". Основа.
        /// </summary>
        public ModDummyMainBaseDiAutofacFeature ModDummyMainBase { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonFeatures">Обобщённые функциональности.</param>
        public RootAppApiBaseFeatures(IEnumerable<ICoreBaseCommonFeature> commonFeatures)
            : base(commonFeatures)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public override void InitConfig(CoreBaseEnvironment environment)
        {
            base.InitConfig(environment);

            ModAuthBase?.InitConfig(environment);
            ModDummyMainBase?.InitConfig(environment);
        }

        /// <inheritdoc/>
        public override void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment)
        {
            base.InitContext(serviceProvider, environment);

            ModAuthBase?.InitContext(new ModAuthBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                ResourceErrorsLocalizer = GetLocalizer<ModAuthBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModAuthBaseResourceSuccesses>(serviceProvider)
            });

            ModDummyMainBase?.InitContext(new ModDummyMainBaseExternals
            {
                CoreBaseResourceErrors = CoreBase?.Context.Resources.Errors,
                CoreBaseDataProvider = CoreDataSqlServer?.Context.Provider,
                DataBaseSettings = DataBase?.Context.Settings,
                DataEntityDbFactory = DataEntitySqlServer?.Context.DbFactory,
                ResourceErrorsLocalizer = GetLocalizer<ModDummyMainBaseResourceErrors>(serviceProvider),
                ResourceSuccessesLocalizer = GetLocalizer<ModDummyMainBaseResourceSuccesses>(serviceProvider)
            });
        }

        /// <summary>
        /// Зарегистрировать модуль.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public override void RegisterModule(ContainerBuilder builder)
        {
            base.RegisterModule(builder);

            ModAuthBase?.Register(builder);
            ModDummyMainBase?.Register(builder);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override bool TrySetFeature(ICoreBaseCommonFeature commonFeature)
        {
            base.TrySetFeature(commonFeature);

            if (TrySet<ModDummyMainBaseDiAutofacFeature>(x => ModDummyMainBase = x, commonFeature)) return true;
            if (TrySet<ModAuthBaseDiAutofacFeature>(x => ModAuthBase = x, commonFeature)) return true;

            return false;
        }

        #endregion Protected methods
    }
}
