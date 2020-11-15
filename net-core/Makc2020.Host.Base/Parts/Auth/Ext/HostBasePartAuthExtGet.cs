//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;
using Makc2020.Data.Entity.Db;
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
    /// Хост. Основа. Часть "Auth". Расширение. Получить.
    /// </summary>
    public static class HostBasePartAuthExtGet
    {
        #region Public methods

        public static Task<List<HostBasePartAuthValueObjectRole>> HostBasePartAuthExtGetRolesAsync(
            this DataBaseObjectUser user,
            DataEntityDbContext dbContext
            )
        {
            return (
                from ur in dbContext.UserRoles
                join r in dbContext.Roles on ur.RoleId equals r.Id
                where ur.UserId == user.Id
                select new HostBasePartAuthValueObjectRole(r.Id, r.Name)
                ).ToListAsync();
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Получить. Идентификатор сессии.
        /// </summary>
        /// <param name="identity">Идентичность.</param>
        /// <returns>Пользователь хоста.</returns>
        public static string HostBasePartAuthExtGetSessionId(this IIdentity identity)
        {
            string result = null;

            var claims = (identity as ClaimsIdentity)?.Claims;

            if (claims != null)
            {
                result = claims.HostBasePartAuthExtGetSessionId();
            }

            return result;
        }

        /// <summary>
        /// Хост. Основа. Часть "Auth". Расширение. Получить. Идентификатор сессии.
        /// </summary>
        /// <param name="claims">Утверждения.</param>
        /// <returns>Пользователь хоста.</returns>
        public static string HostBasePartAuthExtGetSessionId(this IEnumerable<Claim> claims)
        {
            string result = null;

            var claim = claims.FirstOrDefault(x => x.Type == HostBasePartAuthSettings.CLAIM_SessionId);

            if (claim != null)
            {
                result = claim.Value;
            }

            return result;
        }

        #endregion Public methods
    }
}
