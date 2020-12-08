// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobItemGetResult} from '../../../../jobs/item/get/mod-dummy-tree-job-item-get-result';
import {AppModDummyTreePageItemEnumActions} from '../../enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. Действия. Успех загрузки. */
export class AppModDummyTreePageItemStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageItemEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemGetResult} jobItemGetResult
   * Результат выполнения задания на получение элемента.
   */
  constructor(
    public jobItemGetResult: AppModDummyTreeJobItemGetResult
  ) {
  }
}
