// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyTreeJobItemDeleteInput} from '../../jobs/item/delete/mod-dummy-tree-job-item-delete-input';
import {AppModDummyTreeJobItemGetInput} from '../../jobs/item/get/mod-dummy-tree-job-item-get-input';
import {AppModDummyTreeJobListDeleteInput} from '../../jobs/list/delete/mod-dummy-tree-job-list-delete-input';
import {AppModDummyTreeJobListGetInput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreeJobListGetResult} from '../../jobs/list/get/mod-dummy-tree-job-list-get-result';
import {AppModDummyTreePageListEnumActions} from './enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreePageListStateParameters} from './state/mod-dummy-tree-page-list-state-parameters';

/** Мод "DummyTree". Страницы. Список. Состояние. */
export class AppModDummyTreePageListState extends AppCoreCommonState<AppModDummyTreePageListEnumActions> {

  /**
   * Ввод задания на удаление элемента.
   * @type {AppModDummyTreeJobItemDeleteInput}
   */
  jobItemDeleteInput: AppModDummyTreeJobItemDeleteInput;

  /**
   * Результат выполнения задания на удаление списка.
   * @type {AppCoreExecutionResult}
   */
  jobItemDeleteResult: AppCoreExecutionResult;

  /**
   * Ввод задания на получение элемента.
   * @type {AppModDummyTreeJobItemGetInput}
   */
  jobItemGetInput: AppModDummyTreeJobItemGetInput;

  /**
   * Ввод задания на удаление списка.
   * @type {AppModDummyTreeJobListDeleteInput}
   */
  jobListDeleteInput: AppModDummyTreeJobListDeleteInput;

  /**
   * Результат выполнения задания на удаление списка.
   * @type {AppCoreExecutionResult}
   */
  jobListDeleteResult: AppCoreExecutionResult;

  /**
   * Ввод задания на получение списка.
   * @type {AppModDummyTreeJobListGetInput}
   */
  jobListGetInput: AppModDummyTreeJobListGetInput;

  /**
   * Результат выполнения задания на получение списка.
   * @type {AppModDummyTreeJobListGetResult}
   */
  jobListGetResult: AppModDummyTreeJobListGetResult;

  /**
   * Параметры.
   * @type {AppModDummyTreePageListStateParameters}
   */
  parameters: AppModDummyTreePageListStateParameters;
}
