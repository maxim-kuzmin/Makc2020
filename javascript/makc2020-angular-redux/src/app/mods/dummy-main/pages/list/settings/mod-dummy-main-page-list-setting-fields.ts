// //Author Maxim Kuzmin//makc//

/** Мод "DummyMain". Страницы. Список. Настройки. Поля. */
export class AppModDummyMainPageListSettingFields {

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

  /** Поле объекта сущности "DummyOneToMany". */
  fieldObjectDummyOneToMany = {
    name: 'objectDummyOneToMany',
    labelResourceKey: 'Объект сущности "DummyOneToMany"',
    placeholderResourceKey: 'Выберите объект'
  };
}
