// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppRootPageContactsEnumActions} from '../../enums/root-page-contacts-enum-actions';
import {
  AppRootPageContactsJobContentLoadInput
} from '../../jobs/content/load/host-layout-footer-job-content-load-input';

/** Хост. Разметка. Подвал. Хранилище состояния. Действия. Загрузка. */
export class AppRootPageContactsStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageContactsEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppRootPageContactsJobContentLoadInput} jobContentLoadInput
   * Ввод задания на получение содержимого.
   */
  constructor(
    public jobContentLoadInput: AppRootPageContactsJobContentLoadInput
  ) {
  }
}
