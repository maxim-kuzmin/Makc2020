//Author Maxim Kuzmin//makc//

using Makc2020.Host.Web;
using Makc2020.Root.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

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

        /// <summary>
        /// Обработать событие окончания запроса.
        /// </summary>
        /// <param name="httpContext">HTTP-контекст.</param>
        protected virtual void OnEndRequest(HttpContext httpContext)
        {
            Logger.LogDebug("RootWebServer.OnEndRequest begin");

            Logger.LogDebug($"Request path: {httpContext.Request.Path}");

            const string headerKey = "Set-Cookie";

            var isOk = httpContext.Response.Headers.TryGetValue(headerKey, out var oldHeaderValues)
                && oldHeaderValues.Count > 0;

            if (isOk)
            {
                const string oldPhrase = "samesite=none";
                const string newPhrase = "samesite=strict";

                var newHeaderValues = new string[oldHeaderValues.Count];

                for (var i = 0; i < oldHeaderValues.Count; i++)
                {
                    var oldHeaderValue = oldHeaderValues[i];

                    if (oldHeaderValue.Contains(oldPhrase))
                    {
                        var newHeaderValue = oldHeaderValue.Replace(oldPhrase, newPhrase);

                        newHeaderValues[i] = newHeaderValue;
                    }
                    else
                    {
                        newHeaderValues[i] = oldHeaderValue;
                    }
                }

                httpContext.Response.Headers[headerKey] = new StringValues(newHeaderValues);
            }

            Logger.LogDebug("RootWebServer.OnEndRequest end");
        }

        #endregion Protected methods
    }
}
