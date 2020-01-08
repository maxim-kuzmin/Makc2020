# Библиотека классов Makc2020.Mods.IdentityServer.Web

Библиотека классов, предназначенная для реализации связанной с веб-интерфейсом функциональности мода "IdentityServer" -
сервера идентичности с помощью библиотеки [IdentityServer4](http://docs.identityserver.io/en/latest/index.html).

## Настройка MVC

1. Открыть файл **Makc2020.Mods.IdentityServer.Web/ConfigFiles/Mod.IdentityServer.Web.Mvc.config.json**.

2. В разделе **PartAccount** указать:

- **AllowLocalLogin** - Признак разрешения локального входа в систему:
**логическое значение**;

- **AllowRememberLogin** - Признак разрешения запоминания входа в систему:
**логическое значение**;

- **RememberLoginDurationInDays** - Длительность запоминания входа в систему в днях:
**целое число**;

- **ShowLogoutPrompt** - Признак необходимости показать напоминание о выходе из системы:
**логическое значение**;

- **AutomaticRedirectAfterSignOut** - Признак необходимости автоматического перенаправления после выхода из системы:
**логическое значение**;

- **WindowsAuthenticationSchemeName** - Имя схемы аутентификации Windows:
**строка**.

- IncludeWindowsGroups - Признак необходимости включения групп Windows:
**логическое значение**.

**Пример**

    {
      "PartAccount": {
        "AllowLocalLogin": true,
        "AllowRememberLogin": true,
        "RememberLoginDurationInDays": 30,
        "ShowLogoutPrompt": true,
        "AutomaticRedirectAfterSignOut": true,
        "WindowsAuthenticationSchemeName": "Windows",
        "IncludeWindowsGroups": true
      }
    }