// //Author Maxim Kuzmin//makc//

/** Мод "DummyTree". Страницы. Список. Настройки. Столбцы. */
export class AppModDummyTreePageListSettingColumns {

  /** Столбец "Действие". */
  columnAction = {
    name: 'action',
    labelResourceKey: '',
  };

  /** Столбец "Идентификатор". */
  columnId = {
    name: 'id',
    labelResourceKey: 'Идентификатор',
    placeholderResourceKey: 'Введите идентификатор'
  };

  /** Столбец "Имя". */
  columnName = {
    name: 'name',
    labelResourceKey: 'Имя',
    placeholderResourceKey: 'Введите имя'
  };
}
