// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemGetInput} from '../../../../jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Элемент. Удаление. */
export class AppModDummyMainPageListStoreActionItemDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.ItemDelete;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModDummyMainJobItemGetInput
  ) { }
}
