//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching;
using Makc2020.Core.Web;
using Makc2020.Mods.DummyMain.Caching;
using Makc2020.Root.Apps.Api.Base;
using Microsoft.Extensions.Logging;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Контекст.
    /// </summary>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public class RootAppApiWebContext<TFeatures> : RootAppApiBaseContext<TFeatures>
        where TFeatures: RootAppApiWebFeatures
    {
        #region Properties

        /// <summary>
        /// Ядро. Кэширование.
        /// </summary>
        public CoreCachingContext CoreCaching => Features.CoreCaching.Context;

        /// <summary>
        /// Ядро. Веб.
        /// </summary>
        public CoreWebContext CoreWeb => Features.CoreWeb.Context;

        /// <summary>
        /// Мод "DummyMain". Кэширование.
        /// </summary>
        public ModDummyMainCachingContext ModDummyMainCaching => Features.ModDummyMainCaching.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="features">Функциональности.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppApiWebContext(TFeatures features, ILogger logger)
            : base(features, logger)
        {
        }

        #endregion Constructors
    }
}