//Author Maxim Kuzmin//makc//

using Makc2020.Host.Web;
using Makc2020.Root.Base;
using Microsoft.AspNetCore.Http;

namespace Makc2020.Root.Web
{
    /// <summary>
    /// Корень. Веб. Внедрение зависимостей. Autofac. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootWebServer<TContext, TModules, TConfigurator> :
        RootBaseServer<TContext, TModules, TConfigurator>
        where TContext : RootBaseContext<TModules>
        where TModules : RootBaseModules
        where TConfigurator : RootBaseConfigurator<TContext, TModules>
    {
        #region Protected methods

        /// <summary>
        /// Обработать событие начала запроса.
        /// </summary>
        /// <param name="httpContext">HTTP-контекст.</param>
        protected virtual void OnBeginRequest(HttpContext httpContext)
        {
            Logger.LogDebug("RootWebServer.OnBeginRequest begin");

            Logger.LogDebug($"Request path: {httpContext.Request.Path}");

            var cultureName = CULTURE_NAME;

            if (httpContext.Request.Query.ContainsKey(HostWebSettings.PARAM_Lang))
            {
                cultureName = httpContext.Request.Query[HostWebSettings.PARAM_Lang];
            }

            EnsureInitialization();

            var context = GetContext();

            context.InitCurrentCulture(cultureName);

            Logger.LogDebug("RootWebServer.OnBeginRequest end");
        }

        #endregion Protected methods
    }
}
