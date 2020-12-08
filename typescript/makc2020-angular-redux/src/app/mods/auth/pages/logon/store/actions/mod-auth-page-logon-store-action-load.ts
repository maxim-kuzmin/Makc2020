// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostPartAuthUser} from '@app/host/parts/auth/host-part-auth-user';
import {AppModAuthPageLogonEnumActions} from '../../enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. Загрузка. */
export class AppModAuthPageLogonStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageLogonEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppHostPartAuthUser} currentUser Текущий пользователь.
   * @param {boolean} isLoggedIn Признак успешного ввода.
   */
  constructor(
    public currentUser: AppHostPartAuthUser,
    public isLoggedIn: boolean
  ) {
  }
}
