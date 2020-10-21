// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobListDeleteInput} from '../../../../jobs/list/delete/mod-dummy-tree-job-list-delete-input';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Список. Удаление. */
export class AppModDummyTreePageListStoreActionListDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.ListDelete;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobListDeleteInput} jobListDeleteInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobListDeleteInput: AppModDummyTreeJobListDeleteInput
  ) {
  }
}
