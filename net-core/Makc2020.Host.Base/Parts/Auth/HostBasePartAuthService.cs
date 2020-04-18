//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Common.Identity;
using Makc2020.Host.Base.Parts.Auth.Config;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get;
using Makc2020.Host.Base.Parts.Auth.Jobs.Seed;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Сервис.
    /// </summary>
    public class HostBasePartAuthService
    {
        #region Properties

        private IHostBasePartAuthConfigSettings ConfigSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public HostBasePartAuthService(IHostBasePartAuthConfigSettings configSettings)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать сущность пользователя.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с созданным пользователем.</returns>
        public async Task<DataEntityObjectUser> CreateUserEntity(HostBasePartAuthJobUserEntityCreateInput input)
        {
            return await AddUser(
                input.UserManager,
                input.RoleManager,
                input.UserName,
                input.Password,
                input.Email,
                input.FullName,
                input.RoleNames,
                input.Claims,
                input.LoginProvider,
                input.ProviderDisplayName,
                input.ProviderKey,
                errors => new HostBasePartAuthJobUserEntityCreateException(errors)
                ).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <inheritdoc/>
        public async Task<HostBasePartAuthUser> GetCurrentUser(HostBasePartAuthJobCurrentUserGetInput input)
        {
            HostBasePartAuthUser result;

            var principal = input.Principal;

            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                result = new HostBasePartAuthUser()
                {
                    UserName = "UNKNOWN",
                    FullName = "Unknown user"
                };
            }
            else
            {
                result = principal.HostBasePartAuthExtCreateUser();

                if (result == null)
                {
                    result = await GetUserByName(principal.Identity.Name, input.UserManager, input.RoleManager)
                        .CoreBaseExtTaskWithCurrentCulture(false);
                }
            }

            if (result == null)
            {
                throw new HostBasePartAuthJobCurrentUserGetException();
            }

            return result;
        }

        /// <summary>
        /// Засеять.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task Seed(HostBasePartAuthJobSeedInput input)
        {
            foreach (var userName in ConfigSettings.Groups.Administrators)
            {
                var userConfig = ConfigSettings.Users.FirstOrDefault(x => x.UserName == userName);

                if (userConfig != null)
                {
                    var user = await input.UserManager.FindByNameAsync(userName)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (user == null)
                    {
                        await AddUser(
                            input.UserManager,
                            input.RoleManager,
                            userName,
                            userConfig.Password,
                            userConfig.Email,
                            userConfig.FullName,
                            new[] { HostBasePartAuthSettings.ROLE_Administrator },
                            null,
                            HostBasePartAuthSettings.LOGIN_PROVIDER_Local,
                            HostBasePartAuthSettings.PROVIDER_DISPLAY_NAME_Local,
                            null,
                            errors => new HostBasePartAuthJobSeedException(errors)
                            ).CoreBaseExtTaskWithCurrentCulture(false);
                    }
                }
            }
        }

        #endregion Public methods

        #region Private methods

        private async Task AddRole(
            RoleManager<DataEntityObjectRole> roleManager,
            string roleName
            )
        {
            var role = await roleManager.FindByNameAsync(roleName)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (role == null)
            {
                role = new DataEntityObjectRole
                {
                    Name = roleName
                };

                var identityResult = await roleManager.CreateAsync(role)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (!identityResult.Succeeded)
                {
                    throw new HostBasePartAuthJobSeedException(identityResult.Errors);
                }
            }
        }

        private async Task<DataEntityObjectUser> AddUser(
            UserManager<DataEntityObjectUser> userManager,
            RoleManager<DataEntityObjectRole> roleManager,
            string userName,
            string password,
            string email,
            string fullName,
            IEnumerable<string> roleNames,
            IEnumerable<Claim> claims,
            string loginProvider,
            string providerDisplayName,
            string providerKey,
            Func<IEnumerable<IdentityError>, HostBaseCommonIdentityException> funcCreateIdentityException
            )
        {
            var user = new DataEntityObjectUser
            {
                Email = email,
                FullName = fullName,
                UserName = userName
            };

            var identityResult = string.IsNullOrWhiteSpace(password)
                ? await userManager.CreateAsync(user)
                    .CoreBaseExtTaskWithCurrentCulture(false)
                : await userManager.CreateAsync(user, password)
                    .CoreBaseExtTaskWithCurrentCulture(false);

            if (!identityResult.Succeeded)
            {
                throw funcCreateIdentityException(identityResult.Errors);
            }

            if (roleNames != null && roleNames.Any())
            {
                foreach (var roleName in roleNames)
                {
                    await AddRole(roleManager, roleName)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    identityResult = await userManager.AddToRoleAsync(user, roleName)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (!identityResult.Succeeded)
                    {
                        throw funcCreateIdentityException(identityResult.Errors);
                    }
                }
            }

            if (claims != null && claims.Any())
            {
                identityResult = await userManager.AddClaimsAsync(user, claims)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (!identityResult.Succeeded)
                {
                    throw funcCreateIdentityException(identityResult.Errors);
                }
            }

            if (!string.IsNullOrWhiteSpace(loginProvider))
            {
                var userLoginInfo = new UserLoginInfo(
                    loginProvider,
                    providerKey ?? user.Id.ToString(),
                    providerDisplayName
                    );

                identityResult = await userManager.AddLoginAsync(user, userLoginInfo);

                if (!identityResult.Succeeded)
                {
                    throw funcCreateIdentityException(identityResult.Errors);
                }
            }

            return user;
        }

        private async Task<HostBasePartAuthUser> GetUserByName(
            string name,
            UserManager<DataEntityObjectUser> userManager
            )
        {
            HostBasePartAuthUser result = null;

            if (!string.IsNullOrEmpty(name))
            {
                var user = await userManager.FindByNameAsync(name)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (user != null)
                {
                    result = await user.HostBasePartAuthExtCreateUser(userManager)
                        .CoreBaseExtTaskWithCurrentCulture(false);
                }
            }

            return result;
        }

        #endregion Private methods
    }
}
