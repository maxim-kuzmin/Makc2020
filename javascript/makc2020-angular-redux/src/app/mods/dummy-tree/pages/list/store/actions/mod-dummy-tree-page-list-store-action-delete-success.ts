// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Успех удаления. */
export class AppModDummyTreePageListStoreActionDeleteSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.DeleteSuccess;

  /**
   * Конструктор.
   * @param {AppCoreExecutionResult} jobItemDeleteResult
   * Результат выполнения задания на удаление элемента.
   */
  constructor(
    public jobItemDeleteResult: AppCoreExecutionResult
  ) { }
}
