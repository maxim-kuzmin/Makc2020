// //Author Maxim Kuzmin//makc//

/** Мод "DummyTree". Страницы. Список. Перечисления. Действия. */
export enum AppModDummyTreePageListEnumActions {

  /**
   * Очистка.
   * @type {string}
   */
  Clear = '[AppModDummyTreePageList] Clear',

  /**
   * Удаление отфильтрованного.
   * @type {string}
   */
  FilteredDelete = '[AppModDummyTreePageList] FilteredDelete',

  /**
   * Удаление отфильтрованного.
   * @type {string}
   */
  FilteredDeleteSuccess = '[AppModDummyTreePageList] FilteredDelete Success',

  /**
   * Элемент. Удаление.
   * @type {string}
   */
  ItemDelete = '[AppModDummyTreePageList] ItemDelete',

  /**
   * Элемент. Успех удаления.
   * @type {string}
   */
  ItemDeleteSuccess = '[AppModDummyTreePageList] ItemDelete Success',

  /**
   * Удаление списка.
   * @type {string}
   */
  ListDelete = '[AppModDummyTreePageList] ListDelete',


  /**
   * Удаление списка.
   * @type {string}
   */
  ListDeleteSuccess = '[AppModDummyTreePageList] ListDelete Success',

  /**
   * Загрузка.
   * @type {string}
   */
  Load = '[AppModDummyTreePageList] Load',

  /**
   * Успех загрузки.
   * @type {string}
   */
  LoadSuccess = '[AppModDummyTreePageList] Load Success',

  /**
   * Параметры. Установка.
   * @type {string}
   */
  ParametersSet = '[AppModDummyTreePageList] ParametersSet'
}
