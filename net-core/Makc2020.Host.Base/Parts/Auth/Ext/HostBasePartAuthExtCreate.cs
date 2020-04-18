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
        /// <param name="user">Пользователь.</param>
        /// <param name="roles">Роли.</param>
        /// <returns>Пользователь хоста.</returns>
        public static HostBasePartAuthUser HostBasePartAuthExtCreateUser(
            this DataEntityObjectUser user,
            IEnumerable<string> roles
            )
        {
            var result = new HostBasePartAuthUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Roles = roles
            };

            return result;
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Утверждения пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Утверждения пользователя.</returns>
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
