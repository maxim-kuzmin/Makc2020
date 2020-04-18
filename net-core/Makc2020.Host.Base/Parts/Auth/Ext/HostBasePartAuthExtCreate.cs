//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Makc2020.Host.Base.Parts.Auth.Ext
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Расширение. Создать.
    /// </summary>
    public static class HostBasePartAuthExtCreate
    {
        #region Public methods

        /// <summary>
        /// Создать утверждения ролей из групп Windows.
        /// </summary>
        /// <param name="windowsGroups">Группы Windows.</param>
        /// <returns>Утверждения ролей.</returns>
        public static IEnumerable<Claim> HostBasePartAuthExtCreateRoleClaimsFromWindowsGroups(
            this IdentityReferenceCollection windowsGroups
            )
        {
            var result = new List<Claim>();

            foreach (var windowsGroup in windowsGroups)
            {
                string roleName;

                switch (windowsGroup.Value)
                {
                    case "Administrators":
                        roleName = HostBasePartAuthSettings.ROLE_Administrator;
                        break;
                    default:
                        continue;
                }

                var claim = new Claim(HostBasePartAuthSettings.CLAIM_Role, roleName);

                result.Add(claim);
            }

            return result;
        }

        /// <summary>
        /// Создать имена ролей из групп Windows.
        /// </summary>
        /// <param name="windowsGroups">Группы Windows.</param>
        /// <returns>Утверждения ролей.</returns>
        public static IEnumerable<string> HostBasePartAuthExtCreateRoleNamesFromClaims(
            this IEnumerable<Claim> claims
            )
        {
            return claims
                .Where(x => x.Type == HostBasePartAuthSettings.CLAIM_Role && !string.IsNullOrWhiteSpace(x.Value))
                .Select(x => x.Value)
                .Distinct();
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <param name="userManager">Менеджер пользователя.</param>
        /// <returns>Пользователь хоста.</returns>
        public static async Task<HostBasePartAuthUser> HostBasePartAuthExtCreateUser(
            this DataEntityObjectUser user,
            UserManager<DataEntityObjectUser> userManager
            )
        {
            var roleNames = await userManager.GetRolesAsync(user)
                .CoreBaseExtTaskWithCurrentCulture(false);

            return user.HostBasePartAuthExtCreateUser(roleNames);
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Пользователя.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="roles">Роли.</param>
        /// <returns>Пользователь хоста.</returns>
        public static HostBasePartAuthUser HostBasePartAuthExtCreateUser(
            this DataEntityObjectUser data,
            IEnumerable<string> roles
            )
        {
            var result = new HostBasePartAuthUser
            {
                Id = data.Id,
                UserName = data.UserName,
                Email = data.Email,
                FullName = data.FullName,
                Roles = roles
            };

            return result;
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Утверждения пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public static IEnumerable<Claim> HostBasePartAuthExtCreateUserClaims(this HostBasePartAuthUser user)
        {
            var result = new List<Claim>()
            {
                new Claim(HostBasePartAuthSettings.CLAIM_UserName, user.UserName)
            };

            var roleNames = user.Roles;

            if (roleNames != null && roleNames.Any())
            {
                foreach (var roleName in roleNames)
                {
                    result.Add(new Claim(HostBasePartAuthSettings.CLAIM_Role, roleName));
                }
            }

            return result;
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Пользователя.
        /// </summary>
        /// <param name="principal">Принципал.</param>
        /// <returns>Пользователь хоста.</returns>
        public static HostBasePartAuthUser HostBasePartAuthExtCreateUser(this IPrincipal principal)
        {
            HostBasePartAuthUser result = null;

            var claims = (principal as ClaimsPrincipal)?.Claims;

            var userClaim = claims?.FirstOrDefault(x => x.Type == HostBasePartAuthSettings.CLAIM_User);

            if (userClaim != null)
            {
                result = userClaim.Value.CoreBaseExtJsonDeserialize<HostBasePartAuthUser>(
                    CoreBaseExtJson.OptionsForJavaScript
                    );
            }

            return result;
        }

        #endregion Public methods
    }
}
