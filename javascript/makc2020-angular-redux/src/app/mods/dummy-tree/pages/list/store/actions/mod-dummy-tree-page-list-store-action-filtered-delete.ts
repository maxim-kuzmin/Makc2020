// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobListGetInput} from '../../../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Отфильтрованное. Удаление. */
export class AppModDummyTreePageListStoreActionFilteredDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.FilteredDelete;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobListGetInput} jobListGetInput
   * Ввод задания на получение списка.
   */
  constructor(
    public jobListGetInput: AppModDummyTreeJobListGetInput
  ) {
  }
}
