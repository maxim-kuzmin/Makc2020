// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobItemDeleteInput} from '../../../../jobs/item/delete/mod-dummy-tree-job-item-delete-input';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Элемент. Удаление. */
export class AppModDummyTreePageListStoreActionItemDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.ItemDelete;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemDeleteInput} jobItemDeleteInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemDeleteInput: AppModDummyTreeJobItemDeleteInput
  ) {
  }
}
