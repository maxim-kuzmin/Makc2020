// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppCoreExecutionResultWithData } from '@app/core/execution/core-execution-result-with-data';
import { AppHostPartAuthUser } from '@app/host/parts/auth/host-part-auth-user';
import { AppModAuthPageRegisterEnumActions } from '../../enums/mod-auth-page-register-enum-actions';

/** Мод "Auth". Страницы. Регистрация. Хранилище состояния. Действия. Успех сохранения. */
export class AppModAuthPageRegisterStoreActionSaveSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageRegisterEnumActions.SaveSuccess;

  /**
   * Конструктор.
   * @param {AppCoreExecutionResultWithData<AppHostPartAuthUser>} jobRegisterResult
   * Результат выполнения задания на регистрацию.
   */
  constructor(
    public jobRegisterResult: AppCoreExecutionResultWithData<AppHostPartAuthUser>
  ) { }
}
