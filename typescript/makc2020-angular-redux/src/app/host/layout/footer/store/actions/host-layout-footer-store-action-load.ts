// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostLayoutFooterActions} from '../../host-layout-footer-actions';
import {AppHostLayoutFooterJobContentLoadInput} from '../../jobs/content/load/host-layout-footer-job-content-load-input';

/** Хост. Разметка. Подвал. Хранилище состояния. Действия. Загрузка. */
export class AppHostLayoutFooterStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppHostLayoutFooterActions.Load;

  /**
   * Конструктор.
   * @param {AppHostLayoutFooterJobContentLoadInput} jobContentLoadInput
   * Ввод задания на получение содержимого.
   */
  constructor(
    public jobContentLoadInput: AppHostLayoutFooterJobContentLoadInput
  ) {
  }
}
