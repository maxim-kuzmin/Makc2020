//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Ext;
using Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Register;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Сервис.
    /// </summary>
    public class ModAuthBaseService
    {
        #region Properties

        private ICoreBaseAuthTypeJwtService JwtService { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="jwtService">JWT. Сервис.</param>
        public ModAuthBaseService(ICoreBaseAuthTypeJwtService jwtService)
        {
            JwtService = jwtService;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// JWT. Войти в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModAuthBaseCommonJobLoginJwtOutput> JwtLogin(ModAuthBaseCommonJobLoginInput input)
        {
            ModAuthBaseCommonJobLoginJwtOutput result = null;

            if (!string.IsNullOrEmpty(input.DataPassword))
            {
                DataEntityObjectUser user = null;

                var userManager = input.UserManager;

                if (!string.IsNullOrEmpty(input.DataUserName))
                {
                    user = await userManager.FindByNameAsync(input.DataUserName)
                        .CoreBaseExtTaskWithCurrentCulture(false);
                }
                else if (!string.IsNullOrEmpty(input.DataEmail))
                {
                    user = await userManager.FindByEmailAsync(input.DataEmail)
                        .CoreBaseExtTaskWithCurrentCulture(false);
                }

                if (user != null)
                {
                    var isOk = await userManager.CheckPasswordAsync(user, input.DataPassword)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (isOk)
                    {
                        result = await user.ModAuthBaseExtCreateHostBasePartAuthJobLoginJwtOutput(
                            userManager,
                            JwtService
                            );
                    }
                }
            }

            if (result == null)
            {
                throw new ModAuthBaseCommonJobLoginException();
            }

            return result;
        }

        /// <summary>
        /// JWT. Освежить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<ModAuthBaseCommonJobLoginJwtOutput> JwtRefresh(ModAuthBaseJobRefreshJwtInput input)
        {
            ModAuthBaseCommonJobLoginJwtOutput result = null;

            var userId = JwtService.GetUserIdByRefreshToken(input.DataToken);

            if (userId.CoreBaseExtConvertToNumericInt64() > 0)
            {
                var userManager = input.UserManager;

                var data = await userManager.FindByIdAsync(userId)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (data != null)
                {
                    result = await data.ModAuthBaseExtCreateHostBasePartAuthJobLoginJwtOutput(
                        userManager,
                        JwtService
                        );
                }

                JwtService.RemoveRefreshToken(input.DataToken);
            }

            if (result == null)
            {
                throw new ModAuthBaseJobRefreshJwtException();
            }

            return result;
        }

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с зарегистрированным пользователем.</returns>
        public async Task<HostBasePartAuthUser> Register(ModAuthBaseJobRegisterInput input)
        {
            HostBasePartAuthUser result;

            var data = new DataEntityObjectUser
            {
                UserName = input.DataUserName,
                Email = input.DataEmail,
                FullName = input.DataFullName
            };

            var userManager = input.UserManager;

            var identityResult = await userManager.CreateAsync(data, input.DataPassword)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (identityResult.Succeeded)
            {
                result = await data.HostBasePartAuthExtCreateUser(userManager)
                    .CoreBaseExtTaskWithCurrentCulture(false);
            }
            else
            {
                throw new ModAuthBaseJobRegisterException(identityResult.Errors);
            }

            return result;
        }

        #endregion Public methods
    }
}
