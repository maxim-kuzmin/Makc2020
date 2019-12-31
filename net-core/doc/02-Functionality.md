﻿# Функциональность


## Сущности


### Сущность "DummyMain"


Главная сущность.

Содержит свойства:

- Id

Идентификатор. Тип: целое 64-разрядное число.

- Name

Имя. Тип: строка.

- ObjectDummyOneToManyId

Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".

- PropBoolean

Свойство, содержащее логическое значение.

- PropBooleanNullable

Свойство, содержащее логическое значение или NULL.

- PropDate

Свойство, содержащее дату.

- PropDateNullable

Свойство, содержащее дату или NULL.

- PropDateTimeOffset

Свойство, содержащее дату и время с часовым поясом.

- PropDateTimeOffsetNullable

Свойство, содержащее дату и время с часовым поясом или NULL.

- PropDecimal

Свойство, содержащее десятичную дробь.

- PropDecimalNullable

Свойство, содержащее десятичную дробь или NULL.

- PropInt32

Свойство, содержащее целое 32-разрядное число.

- PropInt32Nullable

Свойство, содержащее целое 32-разрядное число или NULL.

- PropInt64

Свойство, содержащее целое 64-разрядное число.

- PropInt64Nullable

Свойство, содержащее целое 64-разрядное число или NULL.

- PropString

Свойство, содержащее строку.

- PropStringNullable

Свойство, содержащее строку или NULL.


### Сущность "DummyMainDummyManyToMany"


Связь сущностей "DummyMain" и "DummyManyToMany".

Содержит свойства:

- ObjectDummyMainId

Идентификатор объекта, где хранятся данные сущности "DummyMain".

- ObjectDummyManyToManyId

Идентификатор объекта, где хранятся данные сущности "DummyManyToMany".


### Сущность "DummyManyToMany"


Сущность, связанная с сущностью "DummyMain" по типу "многие-ко-многим", когда один экземпляр сущности "DummyManyToMany" может быть связан с несколькими экземплярами сущности "DummyMain" и наоборот.

Содержит свойства:

- Id

Идентификатор. Тип: целое 64-разрядное число.

- Name

Имя. Тип: строка.


### Сущность "DummyOneToMany"


Сущность, связанная с сущностью "DummyMain" по типу "один-ко-многим", когда один экземпляр сущности "DummyOneToMany" может быть связан с несколькими экземплярами сущности "DummyMain".

Содержит свойства:

- Id

Идентификатор. Тип: целое 64-разрядное число.

- Name

Имя. Тип: строка.


### Сущность "DummyTree"


Узел дерева. Сущность, связанная с сущностью "DummyMain" по типу "многие-к-одному", когда несколько экземпляров сущности "DummyTree" могут быть связаны с одним экземпляром сущности "DummyMain", а также связанная с сущностью "DummyTree" по типу "один-ко-многим" или не связанная с ней.

Содержит свойства:

- Id

Идентификатор узла. Тип: целое 64-разрядное число.

- ParentId

Идентификатор родительского узла. Тип: целое 64-разрядное число или NULL.

- ChildCount

Число дочерних узлов. Тип: целое 64-разрядное число.

- DescendantCount

Число узлов-потомков. Тип: целое 64-разрядное число.

- ObjectDummyMainId

Идентификатор объекта, где хранятся данные сущности "DummyMain".

- Level

Уровень узла в дереве. Тип: целое 64-разрядное число.


### Сущность "Role"


Соответствует аналогичной сущности .Net Core Identity с идентификатором типа целое 64-разрядное число. Предназначена для аутентификации и авторизации.


### Сущность "RoleClaim"


Соответствует аналогичной сущности .Net Core Identity. Предназначена для аутентификации и авторизации.


### Сущность "User"


Соответствует аналогичной сущности .Net Core Identity с идентификатором типа целое 64-разрядное число. Предназначена для аутентификации и авторизации.


### Сущность "UserClaim"


Соответствует аналогичной сущности .Net Core Identity. Предназначена для аутентификации и авторизации.


### Сущность "UserLogin"


Соответствует аналогичной сущности .Net Core Identity. Предназначена для аутентификации и авторизации.


### Сущность "UserRole"


Соответствует аналогичной сущности .Net Core Identity. Предназначена для аутентификации и авторизации.


### Сущность "UserToken"


Соответствует аналогичной сущности .Net Core Identity. Предназначена для аутентификации и авторизации.


## Хранение


Все сущности хранятся в реляционной базе данных.


## Объектно-реляционное отображение


Для взаимодействия с хранилищем используется объектно-реляционное отображение на основе технологии Entity Framework, которое позволяет использовать в качестве хранилища любую реляционную базу данных.


## Внедрение зависимостей


Передача внешних зависимостей программным компонентам осуществляется при помощи инверсии управления.


## Визуализация


Экземпляры сущностей выводятся постранично в виде сортируемого и фильтруемого списка, а также в форме редактирования.


## Авторизация и аутентификация


Доступ к экземплярам сущностей осуществляется аутентифицированным пользователям на основе их ролей.


## Локализация


Тексты выводимых пользователю сообщений хранятся в ресурсах приложения и могут выводиться на различных языках.


## Логирование


Информация о различных событиях, происходящих в приложении, может быть сохранена в лог-файлах.


## Кэширование


Для ускорения работы приложения данные могут быть сохранены в кэше - локальном или распределённом.