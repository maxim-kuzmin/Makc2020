// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppHostPartAuthUser} from '@app/host/parts/auth/host-part-auth-user';
import {AppModAuthPageRedirectEnumActions} from './enums/mod-auth-page-redirect-enum-actions';

/** Мод "Auth". Страницы. Перенаправление. Состояние. */
export class AppModAuthPageRedirectState extends AppCoreCommonState<AppModAuthPageRedirectEnumActions> {

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
   * Результат выполнения задания на получение текущего пользователя.
   * @type {AppCoreExecutionResult}
   */
  jobCurrentUserGetResult: AppCoreExecutionResult;

  /**
   * URL возврата.
   * @param {string}
   */
  returnUrl: string;
}
