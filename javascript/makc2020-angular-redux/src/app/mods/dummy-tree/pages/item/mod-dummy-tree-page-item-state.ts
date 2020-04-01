// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppModDummyTreeJobItemGetInput} from '../../jobs/item/get/mod-dummy-tree-job-item-get-input';
import {AppModDummyTreeJobItemGetOutput} from '../../jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreeJobItemGetResult} from '../../jobs/item/get/mod-dummy-tree-job-item-get-result';
import {AppModDummyTreePageItemEnumActions} from './enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Состояние. */
export class AppModDummyTreePageItemState extends AppCoreCommonState<AppModDummyTreePageItemEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppModDummyTreeJobItemGetInput}
   */
  jobItemGetInput: AppModDummyTreeJobItemGetInput;

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
