//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Mods.IdentityServer.Web.Mvc
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Модуль.
    /// </summary>
    public class ModIdentityServerWebMvcModule : ICoreBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModIdentityServerWebMvcConfig Config { get; private set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ModIdentityServerWebMvcContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Config);
            services.AddTransient(x => GetContext(x).Config.Settings);
            services.AddTransient(x => GetContext(x).PartAccount);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLoginGetProcess);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLoginGetProduce);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLoginPostProcess);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLoginPostProduce);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLogoutGet);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLogoutPostProcess);
            services.AddTransient(x => GetContext(x).PartAccount.Jobs.JobLogoutPostProduce);
            services.AddTransient(x => GetContext(x).PartAccount.Service);
            services.AddTransient<ModIdentityServerWebMvcPartAccountModel>();
            services.AddTransient(x => GetContext(x).PartExternal);
            services.AddTransient(x => GetContext(x).PartExternal.Jobs.JobCallbackGet);
            services.AddTransient(x => GetContext(x).PartExternal.Jobs.JobChallengeGet);
            services.AddTransient(x => GetContext(x).PartExternal.Service);
            services.AddTransient<ModIdentityServerWebMvcPartExternalModel>();
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(CoreBaseEnvironment environment)
        {
            Config = new ModIdentityServerWebMvcConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ModIdentityServerWebMvcExternals externals)
        {
            Context = new ModIdentityServerWebMvcContext(Config, externals);
        }

        #endregion Public methods

        #region Private methods

        private ModIdentityServerWebMvcContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ModIdentityServerWebMvcContext>();
        }

        #endregion Private methods
    }
}