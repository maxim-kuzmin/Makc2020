//Author Maxim Kuzmin//makc//

using System;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Сеть.
    /// </summary>
    public static class CoreBaseExtNetwork
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Сеть. URL. Заменить хост.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="host">Новый хост.</param>
        /// <returns>URL с новым хостом.</returns>
        public static string CoreBaseExtNetworkUrlReplaceHost(this string url, string host)
        {
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(host)) return url;

            var uri = new Uri(url);

            var port = uri.IsDefaultPort ? string.Empty : ":" + uri.Port;

            url = string.Concat(uri.Scheme, Uri.SchemeDelimiter, host, port, uri.PathAndQuery);

            return url;
        }

        #endregion Public methods
    }
}
