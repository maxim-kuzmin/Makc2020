//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2020.Mods.DummyTree.Web.Api
{
    /// <summary>
    /// Мод "DummyTree". Веб. API. Модуль.
    /// </summary>
    public class ModDummyTreeWebApiModule : ICoreBaseCommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ModDummyTreeWebApiModel>();
        }

        #endregion Public methods
    }
}