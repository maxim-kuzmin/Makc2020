// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobItemGetOutput} from '../../../../jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreePageItemEnumActions} from '../../enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. Действия. Сохранение. */
export class AppModDummyTreePageItemStoreActionSave implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageItemEnumActions.Save;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemGetOutput} jobItemGetOutput
   * Выход задания на получение элемента.
   */
  constructor(
    public jobItemGetOutput: AppModDummyTreeJobItemGetOutput
  ) {
  }
}
