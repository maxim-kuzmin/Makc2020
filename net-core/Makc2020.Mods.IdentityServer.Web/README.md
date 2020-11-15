# Библиотека классов Makc2020.Mods.IdentityServer.Base

Библиотека классов, предназначенная для реализации веб-интерфейса мода "IdentityServer" -
сервера идентичности с помощью библиотеки [IdentityServer4](http://docs.identityserver.io/en/latest/index.html).

## Настройка

1. Открыть файл **Makc2020.Mods.IdentityServer/ConfigFiles/Mod.IdentityServer.Web.Mvc.config.json**.

2. В разделе **PartAccount** указать настройки для входа в систему:
        
    - "AllowLoginWithoutPassword" - Признак разрешения входа пользователя без пароля.
        Тип значения: логический (true или false).

    - "AutomaticRedirectAfterSignOut" - Признак необходимости автоматического перенаправления после выхода из системы.
        Тип значения: логический (true или false).

    - "ClientIsFirstLoginParamName" - Имя параметра признака первого входа в систему на стороне клиента.
        Тип значения: строка.

    - "ClientIsFirstLoginParamValue" - Значение параметра признака первого входа в систему на стороне клиента.
        Тип значения: строка.

    - "ClientLangParamName" - Имя параметра языка на стороне клиента.
        Тип значения: строка.

    - "DbCommandTimeout" - Таймаут выполнения команды запроса к базе данных в секундах.
        Тип значения: целое число.
        Если будет указано значение **0**, таймаут будет установлен в 3600 секунд.

    - "IsWindowsAuthenticationMandatory" - Признак необходимости использования автоматической аутентификации Windows.
        Тип значения: логический (true или false).

    - "LoginMethodCookieName" - Имя куки для хранения метода входа в систему.
        Тип значения: строка.

    - "LoginUserNameCookieName" - Имя куки для хранения имени вошедшего в систему пользователя.
        Тип значения: строка.

    - "RememberLoginDurationInDays" - Длительность запоминания входа в систему в днях.
        Тип значения: целое число.

    - "ShowLogoutPrompt" - Признак необходимости показать напоминание о выходе из системы.
        Тип значения: логический (true или false).

**Пример**

    {
      "PartAccount": {
        "AllowLoginWithoutPassword": true,
        "AutomaticRedirectAfterSignOut": true,
        "ClientIsFirstLoginParamName": "core--is-first-login",
        "ClientIsFirstLoginParamValue": "true",
        "ClientLangParamName": "core--lang",
        "DbCommandTimeout": 0,
        "IsWindowsAuthenticationMandatory": true,
        "LoginMethodCookieName": "LoginMethod",
        "LoginUserNameCookieName": "LoginUserName",
        "RememberLoginDurationInDays": 30,
        "ShowLogoutPrompt": false
      }
    }
