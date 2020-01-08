//Author Maxim Kuzmin//makc//

using IdentityServer4.Models;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.IdentityServer.Base.Config;
using Makc2020.Mods.IdentityServer.Base.Config.Enums;
using Makc2020.Mods.IdentityServer.Base.Config.Settings;
using Makc2020.Mods.IdentityServer.Base.Parts.Profile;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Web.Ext
{
    /// <summary>
    /// Мод "IdentityServer". Веб. Расширение. Настроить.
    /// </summary>
    public static class ModIdentityServerWebExtConfigure
    {
        #region Public methods

        /// <summary>
        /// Мод "IdentityServer". Веб. Расширение. Настроить. Аутентификацию.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="configSettings">Кнфигурационные настройки.</param>
        public static AuthenticationBuilder ModIdentityServerWebExtConfigureAuthentication(
            this IServiceCollection services,
            IModIdentityServerBaseConfigSettings configSettings
            )
        {
            var apiResources = CreateApiResources(configSettings.ApiResources);
            var clients = CreateClients(configSettings.Clients);
            var identityResources = CreateIdentityResources(configSettings.IdentityResources);

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddInMemoryIdentityResources(identityResources)
            .AddInMemoryApiResources(apiResources)
            .AddInMemoryClients(clients)
            .AddAspNetIdentity<DataEntityObjectUser>()
            .AddProfileService<ModIdentityServerBasePartProfileService>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            return services.AddAuthentication();
        }

        #endregion Public methods

        #region Private methods

        private static IEnumerable<ApiResource> CreateApiResources(
            IModIdentityServerBaseConfigSettingApiResource[] configSettings
            )
        {
            var result = new List<ApiResource>();

            foreach (var configSetting in configSettings)
            {
                var item = new ApiResource(configSetting.Name, configSetting.DisplayName);

                result.Add(item);
            }

            return result;
        }

        private static IEnumerable<Client> CreateClients(
            IModIdentityServerBaseConfigSettingClient[] configSettings
            )
        {
            var result = new List<Client>();

            foreach (var configSetting in configSettings)
            {
                ICollection<string> allowedGrantTypes = null;

                switch (configSetting.AllowedGrantTypes)
                {
                    case ModIdentityServerBaseConfigEnumGrantTypes.Code:
                        allowedGrantTypes = GrantTypes.Code;
                        break;
                }

                var item = new Client
                {
                    AllowedCorsOrigins = configSetting.AllowedCorsOrigins,
                    AllowedGrantTypes = allowedGrantTypes,
                    AllowOfflineAccess = configSetting.AllowOfflineAccess,
                    AllowedScopes = configSetting.AllowedScopes,
                    ClientId = configSetting.ClientId,
                    ClientName = configSetting.ClientName,
                    ClientUri = configSetting.ClientUri,
                    RequireClientSecret = configSetting.RequireClientSecret,
                    RequireConsent = configSetting.RequireConsent,
                    RequirePkce = configSetting.RequirePkce,
                    RedirectUris = configSetting.RedirectUris,
                    PostLogoutRedirectUris = configSetting.PostLogoutRedirectUris
                };

                result.Add(item);
            }

            return result;
        }

        private static IEnumerable<IdentityResource> CreateIdentityResources(
            ModIdentityServerBaseConfigEnumIdentityResources[] configSettings
            )
        {
            var result = new List<IdentityResource>();

            foreach (var configSetting in configSettings)
            {
                IdentityResource item = null;

                switch (configSetting)
                {
                    case ModIdentityServerBaseConfigEnumIdentityResources.OpenId:
                        item = new IdentityResources.OpenId();
                        break;
                }

                if (item != null)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        #endregion Private methods
    }
}
