# Библиотека классов Makc2020.Mods.DummyMain.Caching

Библиотека классов, предназначенная для реализации связанной с кэшированием
функциональности мода "DummyMain".

## Настройка

1. Открыть файл **Makc2020.Mods.DummyMain.Caching/ConfigFiles/Mod.DummyMain.Caching.config.json**.

2. В разделе **CacheExpiryInSeconds** указать срок хранения записей в кэше в секундах:
**целое число**.

3. В разделе **CacheKeyPrefix** указать префикс ключа кэша:
**строка**.

4. В разделе **IsCachingEnabled** указать признак того, что кэширование вкючено:
**логическое значение**.

**Пример**

    {
      "CacheExpiryInSeconds": 0,
      "CacheKeyPrefix": "Mod:DummyMain:",
      "IsCachingEnabled": true
    }
