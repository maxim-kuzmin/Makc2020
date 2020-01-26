# Серверное веб-приложение Makc2020.Apps.IdentityServer.Web

Реализовано на .NET Core 3.x, C#, Entity Framework, MS SQL Server.

Предоставляет HTTP REST API для аутентификации с помощью библиотеки
[IdentityServer4](http://docs.identityserver.io/en/latest/index.html)
по технологии [Single Sign-On](https://ru.wikipedia.org/wiki/Технология_единого_входа).

## Настройка

1. Открыть файл **Makc2020.Apps.IdentityServer.Web/ConfigFiles/App.config.json**.

2. В разделе **Logging:LogLevel:Default** указать уровень логирования по-умолчанию.

**Пример:**

    {  
      "Logging": {
        "IncludeScopes": false,
        "LogLevel": {
          "Default": "Warning"
        }
      },
      "AllowedHosts": "*"
    }

## Настройка хоста

Описание настроек основной функциональности хоста можно увидеть
[здесь](../Makc2020.Host.Base/README.md).

## Настройка мода "IdentityServer"

Описание настроек основной функциональности мода "IdentityServer" можно увидеть
[здесь](../Makc2020.Mods.IdentityServer.Base/README.md).

Описание настроек связанной с веб-интерфейсом функциональности мода "IdentityServer" можно увидеть
[здесь](../Makc2020.Mods.IdentityServer.Web/README.md).

## Развёртывание

1. Подготовить компьютер, на котором будет развёрнуто приложение, установив на нём
[.NET Core 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1).

2. Открыть консоль и перейти в папку Makc2020.Apps.Api.Web.

3. Выполнить сборку и публикацию приложения:
 
- для продуктовой среды выполнить команду **dotnet publish Makc2020.Apps.IdentityServer.Web.csproj -c Release**;

- для тестовой среды выполнить команду **dotnet publish Makc2020.Apps.IdentityServer.Web.csproj -c Test**. 

4. Перейти в папку с файлами, предназначенными для публикации:
 
- для продуктовой среды: **Makc2020.Apps.IdentityServer.Web/bin/Release/netcoreapp3.1/publish**;

- для тестовой среды: **Makc2020.Apps.IdentityServer.Web/bin/Test/netcoreapp3.1/publish**.

5. Скопировать всё содержимое папки с файлами, предназначенными для публикации,
в папку компьютера, на котором должно быть развёрнуто приложение.

6. Настроить веб-сервер на обслуживание папки, в которой развёрнуто приложение.

## Пример настройки веб-сервера IIS, втроенного в операционную систему Windows

1. В операционной системы Windows создать пользователя, предназначенного для 
доступа к базе данных.

2. Пользователю, созданному в пункте 1, дать в базе данных приложения права на чтение, 
запись и изменение структуры так, чтобы при запуске приложения от имени этого пользователя
база данных могла быть создана в случае её отсутствия и наполнена начальными данными.  

3. Открыть программу Internet Information services (IIS) Manager.

4. Создать пул приложений со следующими основными настройками:

- *.NET CLR version*: **No managed Code**;

- *Managed pipeline mode*: **Classic**.

5. Открыть дополнительные настройки пула приложений, созданного в пункте 4.

6. Для настройки *Process Model / Identity* установить значение, соответствующее
имени пользователя, созданного в пункте 1.

7. Создать сайт со следующими основными настройками:

- *Application pool*: **Имя пула приложений, созданного в пункте 4**;

- *Physical path*: **Путь к папке, в которой развёрнуто приложение**.
