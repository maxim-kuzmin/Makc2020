# Библиотека классов Makc2020.Host.Base

Библиотека классов, предназначенная для реализации основной функциональности хоста.

## Настройка

1. Открыть файл **Makc2020.Host.Base/ConfigFiles/Makc2020.Host.Base.config.json**.

2. В разделе **PartAuth:Users** указать информацию о пользователях, которые должны быть добавлены в базу данных.

3. В разделе **PartAuth:Groups:Administrators** указать список имён пользователей, которые должны быть добавлены в
группу администраторов.

**Пример:**

    {
      "PartAuth": {
        "Users": [
          {
            "Email": "admin@email.com",
            "FullName": "Администратор",
            "Password": "Admin(2019)",
            "UserName": "admin"
          }
        ],
        "Groups": {
          "Administrators": [
            "admin"
          ]
        }
      },
      "PartLdap": {
        "Domain": "local",
        "IsSecureSocketLayerEnabled": false,
        "Port": 389,
        "Hosts": [
          "001.local",
          "002.local"
        ]
      }
    }
