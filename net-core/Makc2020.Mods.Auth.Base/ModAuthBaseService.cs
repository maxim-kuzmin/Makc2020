//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Config;
using Makc2020.Mods.Auth.Base.Ext;
using Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Register;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Сервис.
    /// </summary>
    public class ModAuthBaseService
    {
        #region Properties

        private IModAuthBaseConfigSettings ConfigSettings { get; set; }

        private DataEntityDbFactory DbFactory { get; set; }

        private ICoreBaseAuthTypeJwtService JwtService { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        /// <param name="jwtService">JWT. Сервис.</param>
        public ModAuthBaseService(
            IModAuthBaseConfigSettings configSettings,
            DataEntityDbFactory dbFactory,
            ICoreBaseAuthTypeJwtService jwtService
            )
        {
            ConfigSettings = configSettings;
            DbFactory = dbFactory;
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
                        using var dbContext = CreateDbContext();

                        result = await user.ModAuthBaseExtCreateHostBasePartAuthJobLoginJwtOutput(
                            dbContext,
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
                    using var dbContext = CreateDbContext();

                    result = await data.ModAuthBaseExtCreateHostBasePartAuthJobLoginJwtOutput(
                        dbContext,
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
#if !INITIAL_CREATE
                Email = input.DataEmail,
#endif
                UserName = input.DataUserName
            };

            var userManager = input.UserManager;

            var identityResult = await userManager.CreateAsync(data, input.DataPassword)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (identityResult.Succeeded)
            {
                using var dbContext = CreateDbContext();

                result = await data.HostBasePartAuthExtCreateUser(dbContext)
                    .CoreBaseExtTaskWithCurrentCulture(false);
            }
            else
            {
                throw new ModAuthBaseJobRegisterException(identityResult.Errors);
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private DataEntityDbContext CreateDbContext()
        {
            var result = DbFactory.CreateDbContext();

            var dbCommandTimeout = ConfigSettings.DbCommandTimeout;

            if (dbCommandTimeout < 1)
            {
                dbCommandTimeout = 3600;
            }

            result.Database.SetCommandTimeout(dbCommandTimeout);

            return result;
        }

        #endregion Private methods
    }
}
