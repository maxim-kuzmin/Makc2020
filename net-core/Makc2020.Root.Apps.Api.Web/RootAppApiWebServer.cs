//Author Maxim Kuzmin//makc//

using Makc2020.Root.Web.DiAutofac;

namespace Makc2020.Root.Apps.Api.Web
{
    /// <summary>
    /// Корень. Приложение "API". Веб. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppApiWebServer<TContext, TFeatures, TConfigurator> :
        RootWebDiAutofacServer<TContext, TFeatures, TConfigurator>
        where TContext : RootAppApiWebContext<TFeatures>
        where TFeatures : RootAppApiWebFeatures
        where TConfigurator : RootAppApiWebConfigurator
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void InitConfigurator(TConfigurator configurator)
        {
            base.InitConfigurator(configurator);

            configurator.HostWebPartAuthenticationEnable(Features.ModAuthBase?.Config?.Settings);
        }

        #endregion Protected methods
    }
}
