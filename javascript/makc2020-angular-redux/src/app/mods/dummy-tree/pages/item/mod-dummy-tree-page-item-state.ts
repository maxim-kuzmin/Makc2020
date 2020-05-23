// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobTreeItemGetInput} from '@app/core/common/mod/jobs/tree/item/get/core-common-mod-job-tree-item-get-input';
import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppModDummyTreeJobItemGetOutput} from '../../jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreeJobItemGetResult} from '../../jobs/item/get/mod-dummy-tree-job-item-get-result';
import {AppModDummyTreePageItemEnumActions} from './enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Состояние. */
export class AppModDummyTreePageItemState extends AppCoreCommonState<AppModDummyTreePageItemEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppCoreCommonModJobTreeItemGetInput}
   */
  jobItemGetInput: AppCoreCommonModJobTreeItemGetInput;

  /**
   * Выход задания на получение элемента.
   * @type {AppModDummyTreeJobItemGetOutput}
   */
  jobItemGetOutput: AppModDummyTreeJobItemGetOutput;

  /**
   * Результат выполнения задания на получение элемента.
   * @type {AppModDummyTreeJobItemGetResult}
   */
  jobItemGetResult: AppModDummyTreeJobItemGetResult;
}
