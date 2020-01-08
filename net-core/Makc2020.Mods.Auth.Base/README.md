# Библиотека классов Makc2020.Mods.Auth.Base

Библиотека классов, предназначенная для реализации основной функциональности мода "Auth" -
аутентификации и авторизации.

## Настройка

1. Открыть файл **Makc2020.Mods.Auth.Base/ConfigFiles/Mod.Auth.Base.config.json**.

2. В разделе **Type** указать тип аутентификации:
**"Jwt"** или **"Oidc"**.

3. В разделе **Types:Oidc:Audience** указать имя аутентифицируемого ресурса API:
**строка**.

4. В разделе **Types:Oidc:Authority** указать адрес сервера идентичности:
**"строка**.

5. В разделе **Types:Oidc:RequireHttpsMetadata** указать признак того, что обмен информацией должен происходить по
протоколу HTTPs: **логическое значение**.


**Пример**

    {
      "Type": "Oidc",
      "Types": {
        "Jwt": {
          "Issuer": "Makc2020",
          "Audience": "Makc2020WebApi",
          "SecretKey": "mysupersecret_secretkey!123",
          "TimeToLiveInMinutesOfAccessToken": "5",
          "TimeToLiveInDaysOfRefreshToken": "7"
        },
        "Oidc": {
          "Audience": "Makc2020WebApi",
          "Authority": "http://localhost:6002",
          "RequireHttpsMetadata": false
        }
      }
    }
