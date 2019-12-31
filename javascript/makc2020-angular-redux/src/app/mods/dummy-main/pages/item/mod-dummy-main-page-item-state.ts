// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppModDummyMainJobItemGetInput} from '../../jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobItemGetOutput} from '../../jobs/item/get/mod-dummy-main-job-item-get-output';
import {AppModDummyMainJobItemGetResult} from '../../jobs/item/get/mod-dummy-main-job-item-get-result';
import {AppModDummyMainPageItemEnumActions} from './enums/mod-dummy-main-page-item-enum-actions';
import {AppModDummyMainJobOptionsDummyManyToManyGetResult} from '../../jobs/options/dummy-many-to-many/get/mod-dummy-main-job-options-dummy-many-to-many-get-result';
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from '../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get-result';

/** Мод "DummyMain". Страницы. Элемент. Состояние. */
export class AppModDummyMainPageItemState extends AppCoreCommonState<AppModDummyMainPageItemEnumActions> {

  /**
   * Ввод задания на получение элемента.
   * @type {AppModDummyMainJobItemGetInput}
   */
  jobItemGetInput: AppModDummyMainJobItemGetInput;

  /**
   * Выход задания на получение элемента.
   * @type {AppModDummyMainJobItemGetOutput}
   */
  jobItemGetOutput: AppModDummyMainJobItemGetOutput;

  /**
   * Результат выполнения задания на получение элемента.
   * @type {AppModDummyMainJobItemGetResult}
   */
  jobItemGetResult: AppModDummyMainJobItemGetResult;

  /**
   * Результат выполнения задания на получение вариантов выбора сущности "DummyManyToMany".
   * @type {AppModDummyMainJobOptionsDummyManyToManyGetResult}
   */
  jobOptionsDummyManyToManyGetResult: AppModDummyMainJobOptionsDummyManyToManyGetResult;

  /**
   * Результат выполнения задания на получение вариантов выбора сущности "DummyOneToMany".
   * @type {AppModDummyMainJobOptionsDummyOneToManyGetResult}
   */
  jobOptionsDummyOneToManyGetResult: AppModDummyMainJobOptionsDummyOneToManyGetResult;
}
