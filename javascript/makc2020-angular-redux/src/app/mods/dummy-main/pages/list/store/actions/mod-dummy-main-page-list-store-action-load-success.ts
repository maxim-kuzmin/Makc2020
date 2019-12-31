// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModDummyMainJobListGetOutput} from '../../../../jobs/list/get/mod-dummy-main-job-list-get-output';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainJobListGetResult} from '@app/mods/dummy-main/jobs/list/get/mod-dummy-main-job-list-get-result';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Успех загрузки. */
export class AppModDummyMainPageListStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobListGetResult} jobListGetResult
   * Результат выполнения задания на получение списка.
   */
  constructor(
    public jobListGetResult: AppModDummyMainJobListGetResult
  ) { }
}
