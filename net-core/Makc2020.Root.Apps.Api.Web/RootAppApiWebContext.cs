//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;
using Makc2020.Core.Caching;
using Makc2020.Mods.DummyMain.Caching;
using Makc2020.Mods.DummyTree.Caching;
using Makc2020.Root.Apps.Api.Base;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Контекст.
    /// </summary>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    public class RootAppApiWebContext<TModules> : RootAppApiBaseContext<TModules>
        where TModules: RootAppApiWebModules
    {
        #region Properties

        /// <summary>
        /// Ядро. Кэширование.
        /// </summary>
        public CoreCachingContext CoreCaching => Modules.CoreCaching.Context;

        /// <summary>
        /// Мод "DummyMain". Кэширование.
        /// </summary>
        public ModDummyMainCachingContext ModDummyMainCaching => Modules.ModDummyMainCaching.Context;

        /// <summary>
        /// Мод "DummyTree". Кэширование.
        /// </summary>
        public ModDummyTreeCachingContext ModDummyTreeCaching => Modules.ModDummyTreeCaching.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppApiWebContext(TModules modules, CoreBaseLoggingService logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}