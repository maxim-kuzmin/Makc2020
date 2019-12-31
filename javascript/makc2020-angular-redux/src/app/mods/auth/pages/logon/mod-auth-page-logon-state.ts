// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';
import {AppHostAuthCommonJobLoginInput} from '@app/host/auth/common/jobs/login/host-auth-common-job-login-input';
import {AppModAuthPageLogonEnumActions} from './enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Состояние. */
export class AppModAuthPageLogonState extends AppCoreCommonState<AppModAuthPageLogonEnumActions> {

  /**
   * Текущий пользователь.
   * @type {AppHostAuthUser}
   */
  currentUser: AppHostAuthUser;

  /**
   * Признак успешного входа в систему.
   * @type {boolean}
   */
  isLoggedIn: boolean;

  /**
   * Ввод для задания на вход в систему.
   * @type {AppHostAuthCommonJobLoginInput}
   */
  jobLoginInput: AppHostAuthCommonJobLoginInput;

  /**
   * Результат выполнения задания на вход в систему.
   * @type {AppCoreExecutionResult}
   */
  jobLoginResult: AppCoreExecutionResult;

  /**
   * URL для перенаправления после входа в систему.
   * @param {string}
   */
  redirectUrl: string;
}
