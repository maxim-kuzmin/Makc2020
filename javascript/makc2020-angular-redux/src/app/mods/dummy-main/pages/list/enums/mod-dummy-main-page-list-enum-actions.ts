// //Author Maxim Kuzmin//makc//

/** Мод "DummyMain". Страницы. Список. Перечисления. Действия. */
export enum AppModDummyMainPageListEnumActions {

  /**
   * Очистка.
   * @type {string}
   */
  Clear = '[AppModDummyMainPageList] Clear',

  /**
   * Удаление отфильтрованного.
   * @type {string}
   */
  FilteredDelete = '[AppModDummyMainPageList] FilteredDelete',

  /**
   * Удаление отфильтрованного.
   * @type {string}
   */
  FilteredDeleteSuccess = '[AppModDummyMainPageList] FilteredDelete Success',

  /**
   * Элемент. Удаление.
   * @type {string}
   */
  ItemDelete = '[AppModDummyMainPageList] ItemDelete',

  /**
   * Элемент. Успех удаления.
   * @type {string}
   */
  ItemDeleteSuccess = '[AppModDummyMainPageList] ItemDelete Success',

  /**
   * Удаление списка.
   * @type {string}
   */
  ListDelete = '[AppModDummyMainPageList] ListDelete',


  /**
   * Удаление списка.
   * @type {string}
   */
  ListDeleteSuccess = '[AppModDummyMainPageList] ListDelete Success',

  /**
   * Загрузка.
   * @type {string}
   */
  Load = '[AppModDummyMainPageList] Load',

  /**
   * Успех загрузки.
   * @type {string}
   */
  LoadSuccess = '[AppModDummyMainPageList] Load Success',

  /**
   * Параметры. Установка.
   * @type {string}
   */
  ParametersSet = '[AppModDummyMainPageList] ParametersSet'
}
