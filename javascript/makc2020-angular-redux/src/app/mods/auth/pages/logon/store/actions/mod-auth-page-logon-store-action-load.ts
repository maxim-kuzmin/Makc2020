// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';
import {AppModAuthPageLogonEnumActions} from '../../enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. Загрузка. */
export class AppModAuthPageLogonStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageLogonEnumActions.Load;

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
