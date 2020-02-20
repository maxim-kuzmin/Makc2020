// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostPartAuthEnumActions} from './enums/host-part-auth-enum-actions';
import {AppHostPartAuthUser} from './host-part-auth-user';

/** Хост. Часть "Auth". Состояние. */
export class AppHostPartAuthState extends AppCoreCommonState<AppHostPartAuthEnumActions> {

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
   * URL входа в систему.
   * @type {string}
   */
  logonUrl: string;

  /**
   * URL регистрации.
   * @type {string}
   */
  registerUrl: string;

  /**
   * URL возврата.
   * @type {string}
   */
  returnUrl: string;
}
