// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModAuthPageLogonEnumActions} from '../../enums/mod-auth-page-logon-enum-actions';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. Выход из системы. */
export class AppModAuthPageLogonStoreActionLogout implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageLogonEnumActions.Logout;

  /**
   * Конструктор.
   * @param {AppHostAuthUser} currentUser Текущий пользователь.
   * @param {boolean} isLoggedIn Признак успешного ввода.
   */
  constructor(
    public currentUser: AppHostAuthUser,
    public isLoggedIn: boolean
  ) {
  }
}
