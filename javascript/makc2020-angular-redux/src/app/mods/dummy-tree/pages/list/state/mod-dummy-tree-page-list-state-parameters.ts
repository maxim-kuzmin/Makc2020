// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageListParameters} from '../mod-dummy-tree-page-list-parameters';
import {AppModDummyTreePageItemParameters} from '../../item/mod-dummy-tree-page-item-parameters';

/** Мод "DummyTree". Страницы. Список. Состояние. Параметры. */
export class AppModDummyTreePageListStateParameters {

  /**
   * Конструктор.
   * @param {AppModDummyTreePageItemParameters} paramsPageItem Параметры страницы элемента.
   * @param {AppModDummyTreePageListParameters} paramsPageList Параметры страницы списка.
   */
  constructor(
    public paramsPageItem: AppModDummyTreePageItemParameters,
    public paramsPageList: AppModDummyTreePageListParameters
  ) {
  }
}
