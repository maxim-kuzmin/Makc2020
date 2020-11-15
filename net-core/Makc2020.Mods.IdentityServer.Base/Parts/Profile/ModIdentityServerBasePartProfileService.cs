//Author Maxim Kuzmin//makc//

using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Db;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Makc2020.Mods.IdentityServer.Base.Config;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Base.Parts.Profile
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Часть "Профиль". Сервис.
    /// </summary>
    public class ModIdentityServerBasePartProfileService : IProfileService
    {
        #region Properties

        private IModIdentityServerBaseConfigSettings AppConfigSettings { get; set; }

        private DataEntityDbFactory AppDbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appConfigSettings">Конфигурационные настройки.</param>
        /// <param name="appDbFactory">Фабрика базы данных.</param>
        /// <param name="extUserManager">Менеджер пользователей.</param>
        public ModIdentityServerBasePartProfileService(
            IModIdentityServerBaseConfigSettings appConfigSettings,
            DataEntityDbFactory appDbFactory
            )
        {
            AppConfigSettings = appConfigSettings;
            AppDbFactory = appDbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userClaim = context.Subject.Claims.FirstOrDefault(x => x.Type == HostBasePartAuthSettings.CLAIM_User);

            if (userClaim != null)
            {
                context.IssuedClaims.Add(userClaim);
            }
            else
            {
                var sessionId = context.Subject.Claims.First(
                    x => x.Type == HostBasePartAuthSettings.CLAIM_SessionId
                    ).Value;

                var userIds = new List<long>();

                var userIdsString = context.Subject.Claims.First(
                    x => x.Type == HostBasePartAuthSettings.CLAIM_UserIds
                    ).Value;

                if (!string.IsNullOrWhiteSpace(userIdsString) && userIdsString.Contains(','))
                {
                    var parts = userIdsString.Split(',');

                    foreach (var part in parts)
                    {
                        if (int.TryParse(part.Trim(), out var userId))
                        {
                            userIds.Add(userId);
                        }
                    }
                }
                else if (int.TryParse(userIdsString.Trim(), out var userId))
                {
                    userIds.Add(userId);
                }

                var userName = context.Subject.Claims.First(
                    x => x.Type == HostBasePartAuthSettings.CLAIM_UserName
                    ).Value;

                using var dbContext = CreateDbContext();

                var user = await userIds.HostBasePartAuthExtCreateUser(
                    dbContext,
                    userName,
                    sessionId
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                var userClaimValue = user.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForJavaScript);

                context.IssuedClaims.Add(new Claim(HostBasePartAuthSettings.CLAIM_User, userClaimValue));
            }
        }

        /// <inheritdoc/>
        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private DataEntityDbContext CreateDbContext()
        {
            var result = AppDbFactory.CreateDbContext();

            var dbCommandTimeout = AppConfigSettings.DbCommandTimeout;

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
