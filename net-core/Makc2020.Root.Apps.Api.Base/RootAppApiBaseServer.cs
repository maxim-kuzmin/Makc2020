//Author Maxim Kuzmin//makc//

using Makc2020.Root.Base.DiAutofac;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppApiBaseServer<TContext, TFeatures, TConfigurator> :
        RootBaseDiAutofacServer<TContext, TFeatures, TConfigurator>
        where TContext : RootAppApiBaseContext<TFeatures>
        where TFeatures : RootAppApiBaseFeatures
        where TConfigurator : RootAppApiBaseConfigurator
    {
    }
}
