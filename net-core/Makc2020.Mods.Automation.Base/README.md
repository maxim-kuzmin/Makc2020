# Библиотека классов Makc2020.Mods.Automation.Base

Библиотека классов, предназначенная для реализации основной функциональности мода "Automation" -
автоматизации.

## Настройка

1. Открыть файл **Makc2020.Mods.Automation.Base/ConfigFiles/Mod.Automation.Base.config.json**.

2. В разделе **PathToJavascriptCodeFolder** указать путь к папке с кодом "Javascript": **строка**.

3. В разделе **PathToNetCoreCodeFolder** указать путь к папке с кодом ".NET Core": **строка**.

4. В разделе **SourceEntityName** указать имя исходной сущности: **строка**.

5. В разделе **TargetEntityName** указать имя целевой сущности: **строка**.

**Пример**

    {
      "PathToJavascriptCodeFolder": "D:\\Git\\maxim-kuzmin\\Makc2020\\javascript\\makc2020-angular-redux",
      "PathToNetCoreCodeFolder": "D:\\Git\\maxim-kuzmin\\Makc2020\\net-core",
      "SourceEntityName": "",
      "TargetEntityName": "Product"
    }
