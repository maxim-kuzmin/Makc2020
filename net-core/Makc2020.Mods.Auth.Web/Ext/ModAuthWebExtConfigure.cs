//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Enums;
using Makc2020.Core.Base.Auth.Types.Jwt;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Web.Mvc.Parts.Auth;
using Makc2020.Mods.Auth.Base.Config;
using Makc2020.Root.Apps.Api.Web.Policies.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Mods.Auth.Web.Ext
{
    /// <summary>
    /// Мод "Auth". Веб. Расширение. Настроить.
    /// </summary>
    public static class ModAuthWebExtConfigure
    {
        #region Public methods

        /// <summary>
        /// Мод "Auth". Веб. Расширение. Настроить. Аутентификацию.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="configSetting">Конфигурационная настройка.</param>
        /// <returns>Построитель аутентификации.</returns>
        public static AuthenticationBuilder ModAuthWebExtConfigureAuthentication(
            this IServiceCollection services,
            IModAuthBaseConfigSettings configSetting
            )
        {
            var configSettingTypesJwt = configSetting.Types?.Jwt;
            var configSettingTypesOidc = configSetting.Types?.Oidc;

            var authTypeIsJwt = configSetting.Type == CoreBaseAuthEnumTypes.Jwt && configSettingTypesJwt != null;
            var authTypeIsOidc = configSetting.Type == CoreBaseAuthEnumTypes.Oidc && configSettingTypesOidc != null;

            var authDefaultScheme = authTypeIsJwt || authTypeIsOidc
                ? JwtBearerDefaults.AuthenticationScheme
                : CookieAuthenticationDefaults.AuthenticationScheme;

            var result = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = authDefaultScheme;
                options.DefaultChallengeScheme = authDefaultScheme;
                options.DefaultScheme = authDefaultScheme;
            });

            if (authTypeIsOidc)
            {
                result.AddJwtBearer(authDefaultScheme, options =>
                {
                    options.Authority = configSettingTypesOidc.Authority;
                    options.RequireHttpsMetadata = configSettingTypesOidc.RequireHttpsMetadata;
                    options.Audience = configSettingTypesOidc.Audience;
                });
            }
            else if (authTypeIsJwt)
            {
#if TEST || DEBUG
                IdentityModelEventSource.ShowPII = true;
#endif
                result.AddJwtBearer();

                ConfigureAuthenticationJwt(services, configSettingTypesJwt);
            }
            else
            {
                result.AddCookie();

                ConfigureAuthenticationCookie(services);
            }

            services.AddSingleton<IAuthorizationHandler, ModAuthWebPolicyAdminHandler>();
            ConfigureAuthorization(services, new[] { authDefaultScheme });

            return result;
        }

        private static void ConfigureAuthenticationCookie(IServiceCollection services)
        {
            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.LoginPath = new PathString(HostWebMvcPartAuthSettings.PATH_LogOn);
            });
        }

        private static void ConfigureAuthenticationJwt(
            IServiceCollection services,
            ICoreBaseAuthTypeJwtSettings settings
            )
        {
            services.Configure<JwtBearerOptions>(options =>
            {
                options.ClaimsIssuer = settings.Issuer;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = settings.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = settings.SigningKey,

                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                options.SaveToken = true;

                options.IncludeErrorDetails = true;
            });
        }

        private static void ConfigureAuthorization(
            this IServiceCollection services,
            IEnumerable<string> authSchemes
            )
        {
            services.Configure<AuthorizationOptions>(options =>
            {
                options.AddPolicy(
                    HostBasePartAuthSettings.POLICY_Administrator,
                    policy =>
                    {
                        if (authSchemes != null && authSchemes.Any())
                        {
                            foreach (var authScheme in authSchemes)
                            {
                                policy.AuthenticationSchemes.Add(authScheme);
                            }
                        }

                        policy.RequireClaim(HostBasePartAuthSettings.CLAIM_User);

                        policy.Requirements.Add(new ModAuthWebPolicyAdminRequirement());
                    });
            });
        }

        #endregion Public methods
    }
}
