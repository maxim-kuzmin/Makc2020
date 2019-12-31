// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostAuthEnumActions} from './enums/host-auth-enum-actions';
import {AppHostAuthUser} from './host-auth-user';

/** Хост. Аутентификация. Состояние. */
export class AppHostAuthState extends AppCoreCommonState<AppHostAuthEnumActions> {

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
   * URL входа в систему.
   * @type {string}
   */
  logonUrl: string;

  /**
   * URL для перенаправления просле входа в систему.
   * @type {string}
   */
  redirectUrl: string;

  /**
   * URL регистрации.
   * @type {string}
   */
  registerUrl: string;
}
