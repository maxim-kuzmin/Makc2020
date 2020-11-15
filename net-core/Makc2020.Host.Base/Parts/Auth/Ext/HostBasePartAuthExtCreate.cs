//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Value.Objects;
using Microsoft.EntityFrameworkCore;
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
        /// <param name="dbContext">Контекст базы данных.</param>
        /// <param name="userName">Имя пользователя для входа.</param>
        /// <param name="sessionId">Идентификатор сессии.</param>
        /// <returns>Пользователь хоста.</returns>
        public static async Task<HostBasePartAuthUser> HostBasePartAuthExtCreateUser(
            this IEnumerable<long> userIds,
            DataEntityDbContext dbContext,
            string userName,
            string sessionId
            )
        {
            long id = 0;
            string fullName = null;
            string email = null;
            var roles = new List<HostBasePartAuthValueObjectRole>();

            foreach (var userId in userIds)
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

                if (user == null)
                {
                    continue;
                }

                if (id < 1)
                {
                    email = user.Email;
                    fullName = userName == user.UserName ? user.FullName : userName;
                    id = user.Id;
                }

                var userRoles = await user.HostBasePartAuthExtGetRolesAsync(dbContext)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (userRoles.Any())
                {
                    roles.AddRange(userRoles);
                }
            }

            var roleIds = roles.Select(x => x.Id).Distinct().ToArray();

            return new HostBasePartAuthUser
            {
                Email = email,
                FullName = fullName ?? userName,
                Id = id,
                Roles = roles.Distinct(),
                SessionId = sessionId,
                UserIds = userIds,
                UserName = userName
            };
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <param name="dbContext">Контекст базы данных.</param>
        /// <param name="sessionId">Идентификатор сессии.</param>
        /// <returns>Пользователь хоста.</returns>
        public static async Task<HostBasePartAuthUser> HostBasePartAuthExtCreateUser(
            this DataEntityObjectUser user,
            DataEntityDbContext dbContext,
            string sessionId = null
            )
        {
            var roles = await user.HostBasePartAuthExtGetRolesAsync(dbContext)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var roleIds = roles.Select(x => x.Id).Distinct().ToArray();

            return new HostBasePartAuthUser
            {
                Email = user.Email,
                FullName = user.FullName ?? user.UserName,
                Id = user.Id,
                Roles = roles,
                SessionId = sessionId,
                UserIds = new[] { user.Id },
                UserName = user.UserName
            };
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

            if (claims != null)
            {
                result = claims.HostBasePartAuthExtCreateUser();
            }

            return result;
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Создать. Пользователя.
        /// </summary>
        /// <param name="claims">Утверждения.</param>
        /// <returns>Пользователь хоста.</returns>
        public static HostBasePartAuthUser HostBasePartAuthExtCreateUser(this IEnumerable<Claim> claims)
        {
            HostBasePartAuthUser result = null;

            var claim = claims.FirstOrDefault(x => x.Type == HostBasePartAuthSettings.CLAIM_User);

            if (claim != null)
            {
                result = claim.Value.CoreBaseExtJsonDeserialize<HostBasePartAuthUser>(
                    CoreBaseExtJson.OptionsForJavaScript
                    );
            }

            return result;
        }

        #endregion Public methods
    }
}
