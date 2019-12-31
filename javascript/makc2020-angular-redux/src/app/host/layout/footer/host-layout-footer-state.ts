// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostLayoutFooterActions} from './host-layout-footer-actions';
import {AppHostLayoutFooterJobContentLoadInput} from './jobs/content/load/host-layout-footer-job-content-load-input';
import {AppHostLayoutFooterJobContentLoadResult} from './jobs/content/load/host-layout-footer-job-content-load-result';

/** Хост. Разметка. Подвал. Состояние. */
export class AppHostLayoutFooterState extends AppCoreCommonState<AppHostLayoutFooterActions> {

  /**
   * Ввод задания на загрузку содержимого.
   * @type {AppHostLayoutFooterJobContentLoadInput}
   */
  jobContentLoadInput: AppHostLayoutFooterJobContentLoadInput;

  /**
   * Результат выполнения задания на загрузку содержимого.
   * @type {AppHostLayoutFooterJobContentLoadResult}
   */
  jobContentLoadResult: AppHostLayoutFooterJobContentLoadResult;
}
