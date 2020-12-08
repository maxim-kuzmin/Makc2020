// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppRootPageContactsEnumActions} from './enums/root-page-contacts-enum-actions';
import {AppRootPageContactsJobContentLoadInput} from './jobs/content/load/host-layout-footer-job-content-load-input';
import {AppRootPageContactsJobContentLoadResult} from './jobs/content/load/host-layout-footer-job-content-load-result';

/** Корень. Страницы. Контакты. Состояние. */
export class AppRootPageContactsState extends AppCoreCommonState<AppRootPageContactsEnumActions> {
  /**
   * Ввод задания на загрузку содержимого.
   * @type {AppRootPageContactsJobContentLoadInput}
   */
  jobContentLoadInput: AppRootPageContactsJobContentLoadInput;

  /**
   * Результат выполнения задания на загрузку содержимого.
   * @type {AppRootPageContactsJobContentLoadResult}
   */
  jobContentLoadResult: AppRootPageContactsJobContentLoadResult;
}
