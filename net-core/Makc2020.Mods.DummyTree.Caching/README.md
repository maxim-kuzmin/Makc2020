# Библиотека классов Makc2020.Mods.DummyTree.Caching

Библиотека классов, предназначенная для реализации связанной с кэшированием
функциональности мода "DummyTree".

## Настройка

1. Открыть файл **Makc2020.Mods.DummyTree.Caching/ConfigFiles/Mod.DummyTree.Caching.config.json**.

2. В разделе **CacheExpiryInSeconds** указать срок хранения записей в кэше в секундах:
**целое число**.

3. В разделе **CacheKeyPrefix** указать префикс ключа кэша:
**строка**.

4. В разделе **IsCachingEnabled** указать признак того, что кэширование вкючено:
**логическое значение**.

**Пример**

    {
      "CacheExpiryInSeconds": 0,
      "CacheKeyPrefix": "Mod:DummyTree:",
      "IsCachingEnabled": true
    }
