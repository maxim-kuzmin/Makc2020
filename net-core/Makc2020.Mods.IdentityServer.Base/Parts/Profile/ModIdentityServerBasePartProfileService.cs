//Author Maxim Kuzmin//makc//

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Base.Parts.Profile
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Части. Профиль. Сервис.
    /// </summary>
    public class ModIdentityServerBasePartProfileService : IProfileService
    {
        #region Properties

        private UserManager<DataEntityObjectUser> UserManager { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userManager">Менеджер пользователей.</param>
        public ModIdentityServerBasePartProfileService(UserManager<DataEntityObjectUser> userManager)
        {
            UserManager = userManager;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = UserManager.GetUserAsync(context.Subject).Result;

            if (user != null)
            {
                var roles = UserManager.GetRolesAsync(user).Result;

                var authUser = user.HostBasePartAuthExtCreateUser(roles);

                if (context.Caller == IdentityServerConstants.ProfileDataCallers.UserInfoEndpoint)
                {
                    var claim = new Claim(
                        HostBasePartAuthSettings.CLAIM_User,
                        authUser.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForJavaScript)
                        );

                    context.IssuedClaims.Add(claim);
                }
                else
                {
                    var claims = authUser.HostBasePartAuthExtCreateUserClaims();

                    context.IssuedClaims.AddRange(claims);
                }
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }

        #endregion Public methods
    }
}
