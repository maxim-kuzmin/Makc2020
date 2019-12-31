// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';
import {AppModAuthPageRedirectEnumActions} from './enums/mod-auth-page-redirect-enum-actions';

/** Мод "Auth". Страницы. Перенаправление. Состояние. */
export class AppModAuthPageRedirectState extends AppCoreCommonState<AppModAuthPageRedirectEnumActions> {

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
   * Результат выполнения задания на получение текущего пользователя.
   * @type {AppCoreExecutionResult}
   */
  jobCurrentUserGetResult: AppCoreExecutionResult;

  /**
   * URL для перенаправления после входа в систему.
   * @param {string}
   */
  redirectUrl: string;
}
