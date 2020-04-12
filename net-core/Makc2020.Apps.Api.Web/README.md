# Серверное веб-приложение Makc2020.Apps.Api.Web

Реализовано на .NET Core 3.x, C#, Entity Framework, MS SQL Server.

Предоставляет HTTP REST API для доступа к базе данных.

## Настройка приложения

1. Открыть файл **Makc2020.Apps.Api.Web/ConfigFiles/App.config.json**.

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

## Настройка кэширования

Описание настроек кэширования можно увидеть
[здесь](../Makc2020.Core.Caching/README.md).

## Настройка хоста

Описание настроек основной функциональности хоста можно увидеть
[здесь](../Makc2020.Host.Base/README.md).

## Настройка мода "Auth"

Описание настроек основной функциональности мода "Auth" можно увидеть
[здесь](../Makc2020.Mods.Auth.Base/README.md).

## Настройка мода "DummyMain"

Описание настроек основной функциональности мода "DummyMain" можно увидеть
[здесь](../Makc2020.Mods.DummyMain.Base/README.md).

Описание настроек связанной с кэшированием функциональности мода "DummyMain" можно увидеть
[здесь](../Makc2020.Mods.DummyMain.Caching/README.md).

## Развёртывание

1. Подготовить компьютер, на котором будет развёрнуто приложение, установив на нём последнюю версию
[.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1).

2. Открыть консоль и перейти в папку Makc2020.Apps.Api.Web.

3. Выполнить сборку и публикацию приложения:
 
- для продуктовой среды выполнить команду **dotnet publish Makc2020.Apps.Api.Web.csproj -c Release**;

- для тестовой среды выполнить команду **dotnet publish Makc2020.Apps.Api.Web.csproj -c Test**. 

4. Перейти в папку с файлами, предназначенными для публикации:
 
- для продуктовой среды: **Makc2020.Apps.Api.Web/bin/Release/netcoreapp3.1/publish**;

- для тестовой среды: **Makc2020.Apps.Api.Web/bin/Test/netcoreapp3.1/publish**.

5. Скопировать всё содержимое папки с файлами, предназначенными для публикации,
в папку компьютера, на котором должно быть развёрнуто приложение.

6. Настроить веб-сервер на обслуживание папки, в которой развёрнуто приложение.

## Пример настройки веб-сервера IIS, втроенного в операционную систему Windows

1. Если строка подключения к базе данных в файле Data.Entity.Clients.SqlServer.config.json, размещённом в папке
ConfigFiles, содержит настройку "Integrated Security=True", то в операционной системе Windows нужно
создать пользователя, предназначенного для доступа к базе данных. Этому пользователю нужно дать в базе
данных приложения права на чтение, запись и изменение структуры так, чтобы при запуске приложения от имени
этого пользователя база данных могла быть создана в случае её отсутствия и наполнена начальными данными.  

2. Открыть программу Internet Information services (IIS) Manager.

3. Создать пул приложений со следующими основными настройками:

- *Версия среды CLR .NET* (*.NET CLR version*): **Без управляемого кода** (**No managed Code**);

- *Режим управляемого конвейера* (*Managed pipeline mode*): **Встроенный** (**Integrated**).

4. Если были выполнены действия, перечисленные в пункте 1, то нужно открыть дополнительные настройки
пула приложений, созданного в пункте 3. Далее для настройки *Process Model / Identity* установить значение,
соответствующее имени пользователя, созданного в пункте 1.

5. Создать сайт со следующими основными настройками:

- *Пул приложений* (*Application pool*): **Имя пула приложений, созданного в пункте 3**;

- *Физический путь* (*Physical path*): **Путь к папке, в которой развёрнуто приложение**.

6. Для сайта, созданного в пункте 5, включить следующие настройки проверки подлинности: Анонимная и Windows.

## Тестирование

### **DummyTree**

- GET Item => Axis=0(Self)[default], RootId=1

      api/dummy-tree/item?rootId=1

- GET Item => Axis=1(Parent), RootId=125

      api/dummy-tree/item?axis=1&rootId=125

- GET List => Axis=0(All)[default], OpenIdsString=2,3,4,123,124,125
    
      api/dummy-tree/list?openIdsString=2,3,4,123,124,125

- GET List => Axis=1(Ancestor), RootId=125
        
      api/dummy-tree/list?axis=1&rootId=125

- GET List => Axis=2(AncestorOrSelf), RootId=125
        
      api/dummy-tree/list?axis=2&rootId=125

- GET List => Axis=3(Child), RootId=1
        
      api/dummy-tree/list?axis=3&rootId=1

- GET List => Axis=4(ChildOrSelf), RootId=1
        
      api/dummy-tree/list?axis=4&rootId=1

- GET List => Axis=5(Descendant), RootId=1, OpenIdsString=2,3,4
        
      api/dummy-tree/list?axis=5&rootId=1&openIdsString=2,3,4

- GET List => Axis=6(DescendantOrSelf), RootId=1, OpenIdsString=2,3,4
        
      api/dummy-tree/list?axis=6&rootId=1&openIdsString=2,3,4

- GET List => Axis=7(ParentOrSelf), RootId=125
        
      api/dummy-tree/list?axis=7&rootId=125
