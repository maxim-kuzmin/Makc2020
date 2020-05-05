//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;
using Makc2020.Mods.IdentityServer.Web.Mvc;
using Makc2020.Root.Apps.IdentityServer.Base;

namespace Makc2020.Root.Apps.IdentityServer.Web
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Веб. Контекст.
    /// </summary>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    public abstract class RootAppIdentityServerWebContext<TModules> :
        RootAppIdentityServerBaseContext<TModules>
        where TModules: RootAppIdentityServerWebModules
    {
        #region Properties

        /// <summary>
        /// Мод "IdentityServer". Веб. MVC.
        /// </summary>
        public ModIdentityServerWebMvcContext ModIdentityServerWebMvc => Modules.ModIdentityServerWebMvc.Context;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="modules">Модули.</param>
        /// <param name="logger">Регистратор.</param>
        public RootAppIdentityServerWebContext(TModules modules, CoreBaseLoggingService logger)
            : base(modules, logger)
        {
        }

        #endregion Constructors
    }
}
