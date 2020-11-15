//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Base.Ext
{
    /// <summary>
    /// Мод "Auth". Основа. Расширение. Создать.
    /// </summary>
    public static class ModAuthBaseExtCreate
    {
        #region Public methods

        /// <summary>
        /// Мод "Auth". Основа. Расширение. Создать. Вывод от задания на вход в систему при помощи JWT.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="dbContext">Контекст базы данных.</param>
        /// <param name="jwtService">Сервис JWT.</param>
        /// <returns></returns>
        public static async Task<ModAuthBaseCommonJobLoginJwtOutput> ModAuthBaseExtCreateHostBasePartAuthJobLoginJwtOutput(
            this DataEntityObjectUser data,
            DataEntityDbContext dbContext,
            ICoreBaseAuthTypeJwtService jwtService
            )
        {
            var user = await data.HostBasePartAuthExtCreateUser(dbContext)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var result = new ModAuthBaseCommonJobLoginJwtOutput
            {
                CurrentUser = user
            };

            var userClaimValue = user.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForJavaScript);

            var claims = new[]
            {
                new Claim(HostBasePartAuthSettings.CLAIM_User, userClaimValue)
            };

            var userId = data.Id.ToString();

            result.AccessToken = jwtService.CreateAccessToken(userId, claims);

            result.RefreshToken = jwtService.CreateRefreshToken(userId);

            return result;
        }

        #endregion Public methods
    }
}
