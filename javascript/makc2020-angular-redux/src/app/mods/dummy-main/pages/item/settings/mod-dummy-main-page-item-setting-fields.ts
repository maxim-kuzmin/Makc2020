// //Author Maxim Kuzmin//makc//

/** Мод "DummyMain". Страницы. Элемент. Настройки. Поля. */
export class AppModDummyMainPageItemSettingFields {

  /** Поле "Идентификатор". */
  fieldId = {
    name: 'id',
    labelResourceKey: 'Идентификатор'
  };

  /** Поле "Имя". */
  fieldName = {
    name: 'name',
    labelResourceKey: 'Имя',
    placeholderResourceKey: 'Введите имя'
  };

  /** Поле объект сущности "DummyManyToMany". */
  fieldObjectDummyManyToMany = {
    name: 'objectDummyManyToMany',
    labelResourceKey: 'Объект сущности "DummyManyToMany"',
    placeholderResourceKey: 'Выберите объект'
  };

  /** Поле объект сущности "DummyOneToMany". */
  fieldObjectDummyOneToMany = {
    name: 'objectDummyOneToMany',
    labelResourceKey: 'Объект сущности "DummyOneToMany"',
    placeholderResourceKey: 'Выберите объект'
  };
}
