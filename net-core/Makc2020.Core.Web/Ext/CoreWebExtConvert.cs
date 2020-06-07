//Author Maxim Kuzmin//makc//

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Makc2020.Core.Web.Ext
{
    /// <summary>
    /// Ядро. Веб. Расширение. Преобразовать.
    /// </summary>
    public static class CoreWebExtConvert
    {
        #region Public methods

        /// <summary>
        /// Ядро. Веб. Расширение. Преобразовать. В строку запроса.
        /// </summary>
        /// <param name="value">Зеачение.</param>
        /// <returns>Строка запроса.</returns>
        public static string CoreWebExtConvertToQueryString(this NameValueCollection value, IEnumerable<string> uriEncoded = null)
        {
            HashSet<string> uriEncodedLookup = null;

            if (uriEncoded != null)
            {
                uriEncodedLookup = new HashSet<string>(uriEncoded);
            }

            var array = (
                from key in value.AllKeys
                from val in value.GetValues(key)
                select string.Format(
                    "{0}={1}",
                    HttpUtility.UrlEncode(key),
                    uriEncodedLookup?.Contains(key) == true ? Uri.EscapeUriString(val) : HttpUtility.UrlEncode(val)
                    )
                ).ToArray();

            return "?" + string.Join("&", array);
        }

        #endregion Public methods
    }
}
