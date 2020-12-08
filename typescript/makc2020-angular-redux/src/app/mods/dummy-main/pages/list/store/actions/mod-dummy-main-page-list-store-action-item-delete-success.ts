// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Элемент. Успех удаления. */
export class AppModDummyMainPageListStoreActionItemDeleteSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.ItemDeleteSuccess;

  /**
   * Конструктор.
   * @param {AppCoreExecutionResult} jobItemDeleteResult
   * Результат выполнения задания на удаление элемента.
   */
  constructor(
    public jobItemDeleteResult: AppCoreExecutionResult
  ) {
  }
}
