# Библиотека классов Makc2020.Mods.IdentityServer.Base

Библиотека классов, предназначенная для реализации основной функциональности мода "IdentityServer" -
сервера идентичности с помощью библиотеки [IdentityServer4](http://docs.identityserver.io/en/latest/index.html).

## Настройка

1. Открыть файл **Makc2020.Mods.IdentityServer.Base/ConfigFiles/Mod.IdentityServer.Base.config.json**.

2. В разделе **ApiResources** указать список аутентифицируемых ресурсов API.

3. В разделе **Clients** указать список аутентифицируемых клиентов.

4. В разделе **IdentityResources** указать список аутентифицируемых ресурсов идентичности.

**Пример**

    {
      "ApiResources": [
        {
          "DisplayName": "Makc2020 web API",
          "Name": "Makc2020WebApi"
        }
      ],
      "Clients": [
        {
          "AllowedCorsOrigins": [
            "http://localhost:4201"
          ],
          "AllowedGrantTypes": "Code",
          "AllowOfflineAccess": true,
          "AllowedScopes": [
            "offline_access",
            "openid",
            "Makc2020WebApi"
          ],
          "ClientId": "Makc2020WebClient",
          "ClientName": "Makc2020 web client",
          "ClientUri": "http://localhost:4201",
          "RequireClientSecret": false,
          "RequireConsent": false,
          "RequirePkce": true,
          "RedirectUris": [
            "http://localhost:4201/mods/auth/redirect"
          ],
          "PostLogoutRedirectUris": [
            "http://localhost:4201/mods/auth/redirect"
          ]
        }
      ],
      "IdentityResources": [
        "OpenId"
      ]
    }
