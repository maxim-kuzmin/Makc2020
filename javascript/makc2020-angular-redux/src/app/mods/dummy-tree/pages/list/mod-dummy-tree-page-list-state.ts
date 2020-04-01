// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyTreeJobItemGetInput} from '../../jobs/item/get/mod-dummy-tree-job-item-get-input';
import {AppModDummyTreeJobListGetInput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreePageListEnumActions} from './enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreeJobListGetResult} from '@app/mods/dummy-tree/jobs/list/get/mod-dummy-tree-job-list-get-result';

/** Мод "DummyTree". Страницы. Список. Состояние. */
export class AppModDummyTreePageListState extends AppCoreCommonState<AppModDummyTreePageListEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppModDummyTreeJobItemGetInput}
   */
  jobItemGetInput: AppModDummyTreeJobItemGetInput;

  /**
   * Результат выполнения задания на получение списка.
   * @type {AppCoreExecutionResult}
   */
  jobItemDeleteResult: AppCoreExecutionResult;

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
}
