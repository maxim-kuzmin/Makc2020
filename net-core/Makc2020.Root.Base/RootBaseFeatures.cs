//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common;
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
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public abstract void InitConfig(CoreBaseEnvironment environment);

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        /// <param name="environment">Окружение.</param>
        public abstract void InitContext(IServiceProvider serviceProvider, CoreBaseEnvironment environment);

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
        protected abstract bool TrySetFeature(ICoreBaseCommonFeature commonFeature);

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
