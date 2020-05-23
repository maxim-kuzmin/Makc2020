// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Удаление. */
export class AppModDummyTreePageListStoreActionDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.Delete;

  /**
   * Конструктор.
   * @param {AppCoreCommonModJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppCoreCommonModJobItemGetInput
  ) {
  }
}
