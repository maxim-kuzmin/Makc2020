//Author Maxim Kuzmin//makc//

using Makc2020.Root.Web;

namespace Makc2020.Root.Apps.IdentityServer.Web
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Веб. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppIdentityServerWebServer<TContext, TModules, TConfigurator> :
        RootWebServer<TContext, TModules, TConfigurator>
        where TContext : RootAppIdentityServerWebContext<TModules>
        where TModules : RootAppIdentityServerWebModules
        where TConfigurator : RootAppIdentityServerWebConfigurator<TContext, TModules>
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void InitConfigurator(TConfigurator configurator)
        {
            base.InitConfigurator(configurator);

            configurator.ModIdentityServerWebAuthenticationEnable(Modules.ModIdentityServerBase?.Config?.Settings);
        }

        #endregion Protected methods
    }
}
