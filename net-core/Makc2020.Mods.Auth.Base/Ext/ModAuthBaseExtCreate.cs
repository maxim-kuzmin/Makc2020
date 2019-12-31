//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Microsoft.AspNetCore.Identity;
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
        /// <param name="userManager">Менеджер пользователя.</param>
        /// <param name="jwtService">Сервис JWT.</param>
        /// <returns></returns>
        public static async Task<ModAuthBaseCommonJobLoginJwtOutput> ModAuthBaseExtCreateHostBasePartAuthJobLoginJwtOutput(
            this DataEntityObjectUser data,
            UserManager<DataEntityObjectUser> userManager,
            ICoreBaseAuthTypeJwtService jwtService
            )
        {
            var result = new ModAuthBaseCommonJobLoginJwtOutput
            {
                CurrentUser = await data.HostBasePartAuthExtCreateUser(userManager)
                    .CoreBaseExtTaskWithCurrentCulture(false)
            };

            var claims = result.CurrentUser.HostBasePartAuthExtCreateUserClaims();

            var userId = data.Id.ToString();

            result.AccessToken = jwtService.CreateAccessToken(userId, claims);

            result.RefreshToken = jwtService.CreateRefreshToken(userId);

            return result;
        }

        #endregion Public methods
    }
}
