// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobItemGetInput} from '../../../../jobs/item/get/mod-dummy-tree-job-item-get-input';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Удаление. */
export class AppModDummyTreePageListStoreActionDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.Delete;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModDummyTreeJobItemGetInput
  ) { }
}
