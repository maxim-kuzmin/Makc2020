//Author Maxim Kuzmin//makc//

using Makc2020.Root.Base;

namespace Makc2020.Root.Apps.Api.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppApiBaseServer<TContext, TModules, TConfigurator> :
        RootBaseServer<TContext, TModules, TConfigurator>
        where TContext: RootAppApiBaseContext<TModules>
        where TModules: RootAppApiBaseModules
        where TConfigurator : RootAppApiBaseConfigurator<TContext, TModules>
    {
    }
}
