//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Http;

namespace Srtdb.Core.Web.Ext
{
    /// <summary>
    /// Ядро. Веб. Расширение. Получить.
    /// </summary>
    public static class CoreWebExtGet
    {
        #region Public methods

        /// <summary>
        /// Ядро. Веб. Расширение. Получить. Значение куки.
        /// </summary>
        /// <param name="value">Зеачение.</param>
        /// <returns>Строка запроса.</returns>
        public static string CoreWebExtGetCookieValue(this HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers.Values)
            {
                foreach (var header in headers)
                {
                    if (header.StartsWith($"{cookieName}="))
                    {
                        var p1 = header.IndexOf('=');
                        var p2 = header.IndexOf(';');

                        return header.Substring(p1 + 1, p2 - p1 - 1);
                    }
                }
            }

            return null;
        }

        #endregion Public methods
    }
}
