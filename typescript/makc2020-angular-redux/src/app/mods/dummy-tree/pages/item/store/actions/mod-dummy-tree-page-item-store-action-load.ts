// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreCommonModJobTreeItemGetInput} from '@app/core/common/mod/jobs/tree/item/get/core-common-mod-job-tree-item-get-input';
import {AppModDummyTreePageItemEnumActions} from '../../enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. Действия. Загрузка. */
export class AppModDummyTreePageItemStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageItemEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppCoreCommonModJobTreeItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppCoreCommonModJobTreeItemGetInput
  ) {
  }
}
