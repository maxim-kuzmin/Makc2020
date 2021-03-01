# Консольное приложение Makc2020.Apps.Automation.Base

Реализовано на .NET Core 3.x, C#.

Предоставляет автоматизацию работы с исходным кодом приложения:
генерацию файлов с кодом на Angular и .NET Core.

## Настройка приложения

1. Открыть файл **Makc2020.Apps.Automation.Base/ConfigFiles/App.config.json**.

2. В разделе **Logging:LogLevel:Default** указать уровень логирования по умолчанию.

**Пример:**

    {
      "Logging": {
        "LogLevel": {
          "Default": "Warning"
        }
      }
    }

## Настройка хоста

Описание настроек основной функциональности хоста можно увидеть
[здесь](../Makc2020.Host.Base/README.md).

## Настройка мода "Automation"

Описание настроек основной функциональности мода "Automation" можно увидеть
[здесь](../Makc2020.Mods.Automation.Base/README.md).
