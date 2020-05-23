// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';
import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppModDummyTreeJobListGetInput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreePageListEnumActions} from './enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreeJobListGetResult} from '@app/mods/dummy-tree/jobs/list/get/mod-dummy-tree-job-list-get-result';

/** Мод "DummyTree". Страницы. Список. Состояние. */
export class AppModDummyTreePageListState extends AppCoreCommonState<AppModDummyTreePageListEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppCoreCommonModJobItemGetInput}
   */
  jobItemGetInput: AppCoreCommonModJobItemGetInput;

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
