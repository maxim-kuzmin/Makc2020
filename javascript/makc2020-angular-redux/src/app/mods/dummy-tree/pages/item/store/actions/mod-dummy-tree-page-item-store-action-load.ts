// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobItemGetInput} from '../../../../jobs/item/get/mod-dummy-tree-job-item-get-input';
import {AppModDummyTreePageItemEnumActions} from '../../enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. Действия. Загрузка. */
export class AppModDummyTreePageItemStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageItemEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModDummyTreeJobItemGetInput
  ) {
  }
}
