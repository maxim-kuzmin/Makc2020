// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreeJobListGetResult} from '@app/mods/dummy-tree/jobs/list/get/mod-dummy-tree-job-list-get-result';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Успех загрузки. */
export class AppModDummyTreePageListStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobListGetResult} jobListGetResult
   * Результат выполнения задания на получение списка.
   */
  constructor(
    public jobListGetResult: AppModDummyTreeJobListGetResult
  ) {
  }
}
