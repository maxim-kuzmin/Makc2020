// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppHostPartAuthUser} from '@app/host/parts/auth/host-part-auth-user';
import {AppHostPartAuthCommonJobLoginInput} from '@app/host/parts/auth/common/jobs/login/host-part-auth-common-job-login-input';
import {AppModAuthPageLogonEnumActions} from './enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Состояние. */
export class AppModAuthPageLogonState extends AppCoreCommonState<AppModAuthPageLogonEnumActions> {

  /**
   * Текущий пользователь.
   * @type {AppHostPartAuthUser}
   */
  currentUser: AppHostPartAuthUser;

  /**
   * Признак успешного входа в систему.
   * @type {boolean}
   */
  isLoggedIn: boolean;

  /**
   * Ввод для задания на вход в систему.
   * @type {AppHostPartAuthCommonJobLoginInput}
   */
  jobLoginInput: AppHostPartAuthCommonJobLoginInput;

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
