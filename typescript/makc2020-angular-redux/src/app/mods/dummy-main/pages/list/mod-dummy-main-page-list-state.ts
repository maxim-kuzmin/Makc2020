// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyMainJobItemDeleteInput} from '../../jobs/item/delete/mod-dummy-main-job-item-delete-input';
import {AppModDummyMainJobItemGetInput} from '../../jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobListDeleteInput} from '../../jobs/list/delete/mod-dummy-main-job-list-delete-input';
import {AppModDummyMainJobListGetInput} from '../../jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainJobListGetResult} from '../../jobs/list/get/mod-dummy-main-job-list-get-result';
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from '../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get-result';
import {AppModDummyMainPageListEnumActions} from './enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainPageListStateParameters} from './state/mod-dummy-main-page-list-state-parameters';

/** Мод "DummyMain". Страницы. Список. Состояние. */
export class AppModDummyMainPageListState extends AppCoreCommonState<AppModDummyMainPageListEnumActions> {

  /**
   * Ввод задания на удаление элемента.
   * @type {AppModDummyMainJobItemDeleteInput}
   */
  jobItemDeleteInput: AppModDummyMainJobItemDeleteInput;

  /**
   * Результат выполнения задания на удаление списка.
   * @type {AppCoreExecutionResult}
   */
  jobItemDeleteResult: AppCoreExecutionResult;

  /**
   * Ввод задания на получение элемента.
   * @type {AppModDummyMainJobItemGetInput}
   */
  jobItemGetInput: AppModDummyMainJobItemGetInput;

  /**
   * Ввод задания на удаление списка.
   * @type {AppModDummyMainJobListDeleteInput}
   */
  jobListDeleteInput: AppModDummyMainJobListDeleteInput;

  /**
   * Результат выполнения задания на удаление списка.
   * @type {AppCoreExecutionResult}
   */
  jobListDeleteResult: AppCoreExecutionResult;

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

  /**
   * Результат выполнения задания на получение вариантов выбора сущности "DummyOneToMany".
   * @type {AppModDummyMainJobOptionsDummyOneToManyGetResult}
   */
  jobOptionsDummyOneToManyGetResult: AppModDummyMainJobOptionsDummyOneToManyGetResult;

  /**
   * Параметры.
   * @type {AppModDummyMainPageListStateParameters}
   */
  parameters: AppModDummyMainPageListStateParameters;
}
