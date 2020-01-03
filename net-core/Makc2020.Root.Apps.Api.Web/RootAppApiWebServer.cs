//Author Maxim Kuzmin//makc//

using Makc2020.Root.Web;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppApiWebServer<TContext, TModules, TConfigurator> :
        RootWebServer<TContext, TModules, TConfigurator>
        where TContext: RootAppApiWebContext<TModules>
        where TModules: RootAppApiWebModules
        where TConfigurator : RootAppApiWebConfigurator<TContext, TModules>
    {
        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void InitConfigurator(TConfigurator configurator)
        {
            base.InitConfigurator(configurator);

            configurator.HostWebPartAuthenticationEnable(Modules.ModAuthBase?.Config?.Settings);
        }

        #endregion Protected methods
    }
}
