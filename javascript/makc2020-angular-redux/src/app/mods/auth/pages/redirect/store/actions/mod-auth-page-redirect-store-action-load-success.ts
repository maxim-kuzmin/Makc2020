// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';
import {AppModAuthPageRedirectEnumActions} from '../../enums/mod-auth-page-redirect-enum-actions';

/** Мод "Auth". Страницы. Перенаправление. Хранилище состояния. Действия. Успех загрузки. */
export class AppModAuthPageRedirectStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageRedirectEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppHostAuthUser} currentUser Текущий пользователь.
   * @param {boolean} isLoggedIn Признак успешного ввода.
   * @param {AppCoreExecutionResult} jobCurrentUserGetResult
   * Результат выполнения задания на получение текущего пользователя.
   * @param {string} redirectUrl URL для перенаправления после ввода.
   */
  constructor(
    public currentUser: AppHostAuthUser,
    public isLoggedIn: boolean,
    public jobCurrentUserGetResult: AppCoreExecutionResult,
    public redirectUrl: string
  ) {
  }
}
