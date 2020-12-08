// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Список. Успех удаления. */
export class AppModDummyMainPageListStoreActionListDeleteSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.ListDeleteSuccess;

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
