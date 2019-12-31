// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyMainJobItemGetInput} from '../../jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobListGetInput} from '../../jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainPageListEnumActions} from './enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainJobListGetResult} from '@app/mods/dummy-main/jobs/list/get/mod-dummy-main-job-list-get-result';

/** Мод "DummyMain". Страницы. Список. Состояние. */
export class AppModDummyMainPageListState extends AppCoreCommonState<AppModDummyMainPageListEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppModDummyMainJobItemGetInput}
   */
  jobItemGetInput: AppModDummyMainJobItemGetInput;

  /**
   * Результат выполнения задания на получение списка.
   * @type {AppCoreExecutionResult}
   */
  jobItemDeleteResult: AppCoreExecutionResult;

  /**
   * Ввод задания на получение списка.
   * @type {AppModDummyMainJobListGetInput}
   */
  jobListGetInput: AppModDummyMainJobListGetInput;

  /**
   * Результат выполнения задания на получение списка.
   * @type {AppModDummyMainJobListGetResult}
   */
  jobListGetResult: AppModDummyMainJobListGetResult;
}
