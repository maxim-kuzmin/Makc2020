//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Makc2020.Host.Base.Parts.Auth.Ext
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Расширение. Получить.
    /// </summary>
    public static class HostBasePartAuthExtGet
    {
        #region Public methods

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Получить. Утверждения ролей из групп Windows.
        /// </summary>
        /// <param name="windowsGroups">Группы Windows.</param>
        /// <returns>Утверждения ролей.</returns>
        public static IEnumerable<Claim> HostBasePartAuthExtGetRoleClaimsFromWindowsGroups(
            this IdentityReferenceCollection windowsGroups
            )
        {
            return windowsGroups
                .Select(x => ConvertFromWindowGroupToRoleName(x.Value))
                .Where(x => x != null)
                .Select(x => new Claim(HostBasePartAuthSettings.CLAIM_Role, x));
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Получить. Имена ролей из утверждений.
        /// </summary>
        /// <param name="claims">Утверждения.</param>
        /// <returns>Имена ролей.</returns>
        public static IEnumerable<string> HostBasePartAuthExtGetRoleNamesFromClaims(
            this IEnumerable<Claim> claims
            )
        {
            return claims
                .Where(x => x.Type == HostBasePartAuthSettings.CLAIM_Role && !string.IsNullOrWhiteSpace(x.Value))
                .Select(x => x.Value)
                .Distinct();
        }

        #endregion Public methods

        #region Private methods

        private static string ConvertFromWindowGroupToRoleName(string windowGroup)
        {
            var parts = windowGroup.Split('\\');

            var value = parts.Length > 1 ? parts[1] : parts[0];

            return value switch
            {
                HostBasePartAuthSettings.WINDOWS_GROUP_SiteAdministrator =>
                    HostBasePartAuthSettings.ROLE_Administrator,
                _ => null,
            };
        }

        #endregion Private methods
    }
}
