//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Auth.Base;
using Makc2020.Mods.DummyMain.Base;
using Makc2020.Root.Base;
using Microsoft.Extensions.Logging;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Контекст.
    /// </summary>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public class RootAppApiBaseContext<TFeatures> : RootBaseContext<TFeatures>
        where TFeatures: RootAppApiBaseFeatures
    {
        #region Properties

        /// <summary>
        /// Мод "Auth". Основа.
        /// </summary>
        public ModAuthBaseContext ModAuthBase => Features.ModAuthBase.Context;

        /// <summary>
        /// Мод "DummyMain". Основа.
        /// </summary>
        public ModDummyMainBaseContext ModDummyMainBase => Features.ModDummyMainBase.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="features">Функциональности.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppApiBaseContext(TFeatures features, ILogger logger)
            : base(features, logger)
        {
        }

        #endregion Constructors
    }
}
