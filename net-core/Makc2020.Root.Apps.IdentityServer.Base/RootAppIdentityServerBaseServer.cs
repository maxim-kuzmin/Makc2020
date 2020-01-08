//Author Maxim Kuzmin//makc//

using Makc2020.Root.Base;

namespace Makc2020.Root.Apps.IdentityServer.Base
{
    /// <summary>
    /// Корень. Приложение "IdentityServer". Основа. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppIdentityServerBaseServer<TContext, TModules, TConfigurator> :
        RootBaseServer<TContext, TModules, TConfigurator>
        where TContext : RootAppIdentityServerBaseContext<TModules>
        where TModules : RootAppIdentityServerBaseModules
        where TConfigurator : RootAppIdentityServerBaseConfigurator<TContext, TModules>
    {
    }
}
