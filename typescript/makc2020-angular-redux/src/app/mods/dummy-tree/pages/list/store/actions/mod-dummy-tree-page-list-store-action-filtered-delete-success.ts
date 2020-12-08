// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Отфильтрованное. Успех удаления. */
export class AppModDummyTreePageListStoreActionFilteredDeleteSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.FilteredDeleteSuccess;

  /**
   * Конструктор.
   * @param {AppCoreExecutionResult} jobListDeleteResult
   * Результат выполнения задания на удаление списка.
   */
  constructor(
    public jobListDeleteResult: AppCoreExecutionResult
  ) {
  }
}
