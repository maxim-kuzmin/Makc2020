// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {
  AppRootPageContactsJobContentLoadResult
} from '../../jobs/content/load/host-layout-footer-job-content-load-result';
import {AppRootPageContactsEnumActions} from '../../enums/root-page-contacts-enum-actions';

/** Хост. Разметка. Подвал. Хранилище состояния. Действия. Успех загрузки. */
export class AppRootPageContactsStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageContactsEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppRootPageContactsJobContentLoadResult} jobContentLoadResult
   * Результат выполнения задания на получение содержимого.
   */
  constructor(
    public jobContentLoadResult: AppRootPageContactsJobContentLoadResult
  ) {
  }
}
