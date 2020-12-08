// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreeJobListGetInput} from '../../../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Загрузка. */
export class AppModDummyTreePageListStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.Load;

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
