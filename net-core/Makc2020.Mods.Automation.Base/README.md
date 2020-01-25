# Библиотека классов Makc2020.Mods.Automation.Base

Библиотека классов, предназначенная для реализации основной функциональности мода "Automation" -
автоматизации.

## Настройка

1. Открыть файл **Makc2020.Mods.Automation.Base/ConfigFiles/Mod.Automation.Base.config.json**.

2. В разделе **PartAngular** указать настройки части "Angular":

- В разделе **SourcePath** указать путь к исходной папке: **строка**.

- В разделе **TargetPath** указать путь к конечной папке: **строка**.

- В разделе **SourceEntityName** указать имя исходной сущности: **строка**.

- В разделе **TargetEntityName** указать имя конечной сущности: **строка**.

3. В разделе **PartNetCore** указать настройки части "Angular":

- В разделе **SourcePath** указать путь к исходной папке: **строка**.

- В разделе **TargetPath** указать путь к конечной папке: **строка**.

- В разделе **SourceEntityName** указать имя исходной сущности: **строка**.

- В разделе **TargetEntityName** указать имя конечной сущности: **строка**.

**Пример**

    {
      "PartAngular": {
        "SourceEntityName": "DummyMain",
        "SourcePath": "E:\\TMP\\source\\javascript\\makc2020-angular-redux\\src",
        "TargetEntityName": "Product",
        "TargetPath": "E:\\TMP\\target\\javascript\\makc2020-angular-redux\\src"
      },
      "PartNetCore": {
        "SourceEntityName": "DummyMain",
        "SourcePath": "E:\\TMP\\source\\net-core",
        "TargetEntityName": "Product",
        "TargetPath": "E:\\TMP\\target\\net-core"
      }
    }

