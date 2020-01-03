//Author Maxim Kuzmin//makc//

using Makc2020.Root.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
        #region Constants

        private const string CULTURE_PARAMETER_NAME = "lang";

        #endregion Constants

        #region Protected methods

        /// <summary>
        /// Обработать событие начала запроса.
        /// </summary>
        protected virtual void OnBeginRequest(HttpContext httpContext)
        {
            Logger.LogDebug("RootWebDiAutofacServer.OnBeginRequest begin");

            Logger.LogDebug($"Request path: {httpContext.Request.Path}");

            var cultureName = CULTURE_NAME;

            if (httpContext.Request.Query.ContainsKey(CULTURE_PARAMETER_NAME))
            {
                cultureName = httpContext.Request.Query[CULTURE_PARAMETER_NAME];
            }

            var context = GetContext();

            context.InitCurrentCulture(cultureName);

            Logger.LogDebug("RootWebDiAutofacServer.OnBeginRequest end");
        }

        #endregion Protected methods
    }
}
