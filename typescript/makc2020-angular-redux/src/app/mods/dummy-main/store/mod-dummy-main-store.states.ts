// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageIndexState} from '../pages/index/mod-dummy-main-page-index-state';
import {AppModDummyMainPageItemState} from '../pages/item/mod-dummy-main-page-item-state';
import {AppModDummyMainPageListState} from '../pages/list/mod-dummy-main-page-list-state';

/** Мод "DummyMain". Хранилище состояния. Состояния. */
export interface AppModDummyMainStoreStates {

  /**
   * Страница. Начало.
   * @type {AppModDummyMainPageIndexState}
   */
  pageIndex: AppModDummyMainPageIndexState;

  /**
   * Страница. Элемент.
   * @type {AppModDummyMainPageItemState}
   */
  pageItem: AppModDummyMainPageItemState;

  /**
   * Страница. Список.
   * @type {AppModDummyMainPageListState}
   */
  pageList: AppModDummyMainPageListState;
}
