//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Routing;

namespace Makc2020.Core.Web.Ext
{
    /// <summary>
    /// Ядро. Веб. Расширение. Данные маршрута.
    /// </summary>
    public static class CoreWebExtRouteData
    {
        #region Constants

        /// <summary>
        /// Ключ для хранения имени области.
        /// </summary>
        public const string KEY_AREA_NAME = "area";

        /// <summary>
        /// Ключ для хранения имени действия.
        /// </summary>
        public const string KEY_ACTION_NAME = "action";

        /// <summary>
        /// Ключ для хранения имени контроллера.
        /// </summary>
        public const string KEY_CONTROLLER_NAME = "controller";

        /// <summary>
        /// Ключ для хранения имени маршрута.
        /// </summary>
        public const string KEY_ROUTE_NAME = "RouteName";

        #endregion Constants

        #region Public methods

        /// <summary>
        /// Ядро. Веб. Расширение. Данные маршрута. Имя области. Получить.
        /// </summary>
        /// <param name="routeData">Данные маршрута.</param>
        /// <returns>Имя области.</returns>
        public static string CoreWebExtRouteDataAreaNameGet(this RouteData routeData)
        {
            return (string)routeData.DataTokens[KEY_AREA_NAME];
        }

        /// <summary>
        /// Ядро. Веб. Расширение. Данные маршрута. Имя области. Установить.
        /// </summary>
        /// <param name="routeData">Данные маршрута.</param>
        /// <param name="name">Имя области.</param>
        public static void CoreWebExtRouteDataAreaNameSet(this RouteData routeData, string name)
        {
            routeData.DataTokens[KEY_AREA_NAME] = name;
        }

        /// <summary>
        /// Ядро. Веб. Расширение. Данные маршрута. Имя контроллера. Установить.
        /// </summary>
        /// <param name="routeData">Данные маршрута.</param>
        /// <param name="name">Имя контроллера.</param>
        public static void CoreWebExtRouteDataControllerNameSet(this RouteData routeData, string name)
        {
            routeData.Values[KEY_CONTROLLER_NAME] = name;
        }

        /// <summary>
        /// Ядро. Веб. Расширение. Данные маршрута. Имя действия. Установить.
        /// </summary>
        /// <param name="routeData">Данные маршрута.</param>
        /// <param name="name">Имя действия.</param>
        public static void CoreWebExtRouteDataActionNameSet(this RouteData routeData, string name)
        {
            routeData.Values[KEY_ACTION_NAME] = name;
        }

        /// <summary>
        /// Ядро. Веб. Расширение. Данные маршрута. Имя маршрута. Установить.
        /// </summary>
        /// <param name="routeData">Данные маршрута.</param>
        /// <param name="name">Имя маршрута.</param>
        public static void CoreWebExtRouteDataRouteNameSet(this RouteData routeData, string name)
        {
            routeData.DataTokens[KEY_ROUTE_NAME] = name;
        }

        /// <summary>
        /// Ядро. Веб. Расширение. Данные маршрута. Имя маршрута. Получить.
        /// </summary>
        /// <param name="routeData">Данные маршрута.</param>
        /// <returns>Имя маршрута.</returns>
        public static string CoreWebExtRouteDataRouteNameGet(this RouteData routeData)
        {
            return (string)routeData.DataTokens[KEY_ROUTE_NAME];
        }

        #endregion Public methods
    }
}
