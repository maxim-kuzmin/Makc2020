// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemDeleteInput} from '../../../../jobs/item/delete/mod-dummy-main-job-item-delete-input';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Элемент. Удаление. */
export class AppModDummyMainPageListStoreActionItemDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.ItemDelete;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemDeleteInput} jobItemDeleteInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemDeleteInput: AppModDummyMainJobItemDeleteInput
  ) {
  }
}
