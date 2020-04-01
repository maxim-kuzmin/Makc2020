// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageIndexState} from '../pages/index/mod-dummy-tree-page-index-state';
import {AppModDummyTreePageItemState} from '../pages/item/mod-dummy-tree-page-item-state';
import {AppModDummyTreePageListState} from '../pages/list/mod-dummy-tree-page-list-state';

/** Мод "DummyTree". Хранилище состояния. Состояния. */
export interface AppModDummyTreeStoreStates {

  /**
   * Страница. Начало.
   * @type {AppModDummyTreePageIndexState}
   */
  pageIndex: AppModDummyTreePageIndexState;

  /**
   * Страница. Элемент.
   * @type {AppModDummyTreePageItemState}
   */
  pageItem: AppModDummyTreePageItemState;

  /**
   * Страница. Список.
   * @type {AppModDummyTreePageListState}
   */
  pageList: AppModDummyTreePageListState;
}
