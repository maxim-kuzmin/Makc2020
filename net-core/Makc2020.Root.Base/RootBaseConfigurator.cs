//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Root.Base
{
    /// <summary>
    /// Корень. Основа. Конфигуратор.
    /// </summary>
    public abstract class RootBaseConfigurator
    {
        #region Properties

        private bool LocalizationIsEnabled { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            if (LocalizationIsEnabled)
            {
                services.AddLocalization();
            }            
        }

        /// <summary>
        /// Создать список обобщённых функциональностей.
        /// </summary>
        /// <returns>Список обобщённых функциональностей.</returns>
        public virtual List<ICoreBaseCommonFeature> CreateCommonFeatureList()
        {
            return new List<ICoreBaseCommonFeature>();
        }

        /// <summary>
        /// Локализация. Включить.
        /// </summary>
        public void LocalizationEnable()
        {
            LocalizationIsEnabled = true;
        }

        #endregion Public methods
    }
}
