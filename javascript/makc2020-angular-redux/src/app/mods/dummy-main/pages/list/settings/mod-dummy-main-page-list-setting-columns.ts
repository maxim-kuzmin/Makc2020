// //Author Maxim Kuzmin//makc//

/** Мод "DummyMain". Страницы. Список. Настройки. Столбцы. */
export class AppModDummyMainPageListSettingColumns {

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
