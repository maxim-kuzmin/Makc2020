//Author Maxim Kuzmin//makc//

using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.IdentityServer.Base.Config;
using Makc2020.Mods.IdentityServer.Base.Config.Enums;
using Makc2020.Mods.IdentityServer.Base.Config.Settings;
using Makc2020.Mods.IdentityServer.Base.Parts.Profile;
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

#if TEST || DEBUG
            IdentityModelEventSource.ShowPII = true;
#endif
            //makc//!!!//Раскомментировать после тестирования//>//
            //// to create a certificate:
            //// makecert -r -pe -n "CN=Makc2020.IdentityServer" -b 01/01/2000 -e 01/01/2036 -eku 1.3.6.1.5.5.7.3.1 -ss my -sr localMachine -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 -len 2048
            //// https://www.hanselman.com/blog/WorkingWithSSLAtDevelopmentTimeIsEasierWithIISExpress.aspx
            //// https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/working-with-ssl-in-web-api
            //builder.AddSigningCredential(configSettings.Certificate);
            //makc//<//

            //makc//!!!//Закомментировать после тестирования//>//
            // not recommended for production - you need to store your key material somewhere secure            
            builder.AddDeveloperSigningCredential();
            //makc//<//

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
                var resource = new ApiResource(configSetting.Name, configSetting.DisplayName);

                result.Add(resource);
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
                    case ModIdentityServerBaseConfigEnumGrantTypes.Implicit:
                        allowedGrantTypes = GrantTypes.Implicit;
                        break;
                }

                var client = new Client
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
                    PostLogoutRedirectUris = configSetting.PostLogoutRedirectUris,
                    AllowAccessTokensViaBrowser = configSetting.AllowAccessTokensViaBrowser
                };

                if (configSetting.AccessTokenLifetime > 0)
                {
                    client.AccessTokenLifetime = configSetting.AccessTokenLifetime;
                }

                if (configSetting.IdentityTokenLifetime > 0)
                {
                    client.IdentityTokenLifetime = configSetting.IdentityTokenLifetime;
                }

                result.Add(client);
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
