// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';
import {AppModAuthPageLogonEnumActions} from '../../enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. Успех входа в систему. */
export class AppModAuthPageLogonStoreActionLoginSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageLogonEnumActions.LoginSuccess;

  /**
   * Конструктор.
   * @param {AppHostAuthUser} currentUser Текущий пользователь.
   * @param {boolean} isLoggedIn Признак успешного ввода.
   * @param {AppCoreExecutionResult} jobLoginResult
   * Результат выполнения задания на вход в систему.
   * @param {string} redirectUrl URL для перенаправления после ввода.
   */
  constructor(
    public currentUser: AppHostAuthUser,
    public isLoggedIn: boolean,
    public jobLoginResult: AppCoreExecutionResult,
    public redirectUrl: string
  ) {
  }
}
