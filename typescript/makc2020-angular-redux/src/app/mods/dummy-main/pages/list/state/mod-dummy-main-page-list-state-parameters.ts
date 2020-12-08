// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageListParameters} from '../mod-dummy-main-page-list-parameters';
import {AppModDummyMainPageItemParameters} from '../../item/mod-dummy-main-page-item-parameters';

/** Мод "DummyMain". Страницы. Список. Состояние. Параметры. */
export class AppModDummyMainPageListStateParameters {

  /**
   * Конструктор.
   * @param {AppModDummyMainPageItemParameters} paramsPageItem Параметры страницы элемента.
   * @param {AppModDummyMainPageListParameters} paramsPageList Параметры страницы списка.
   */
  constructor(
    public paramsPageItem: AppModDummyMainPageItemParameters,
    public paramsPageList: AppModDummyMainPageListParameters
  ) {
  }
}
