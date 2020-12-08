// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostLayoutFooterActions} from '../../host-layout-footer-actions';
import {AppHostLayoutFooterJobContentLoadResult} from '../../jobs/content/load/host-layout-footer-job-content-load-result';

/** Хост. Разметка. Подвал. Хранилище состояния. Действия. Успех загрузки. */
export class AppHostLayoutFooterStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppHostLayoutFooterActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppHostLayoutFooterJobContentLoadResult} jobContentLoadResult
   * Результат выполнения задания на получение содержимого.
   */
  constructor(
    public jobContentLoadResult: AppHostLayoutFooterJobContentLoadResult
  ) {
  }
}
