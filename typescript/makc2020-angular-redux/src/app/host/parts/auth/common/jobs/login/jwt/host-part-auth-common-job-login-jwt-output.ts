// //Author Maxim Kuzmin//makc//

import { AppHostPartAuthUser } from '../../../../host-part-auth-user';

/** Хост. Часть "Auth". Общее. Задания. Вход в систему. JWT. Вывод. */
export interface AppHostPartAuthCommonJobLoginJwtOutput {

  /**
   * Текущий пользователь.
   * @type {AppHostPartAuthUser}
   */
  currentUser: AppHostPartAuthUser;

  /**
   * Токен доступа.
   * @type {string}
   */
  accessToken: string;

  /**
   * Токен обновления.
   * @type {string}
   */
  refreshToken: string;
}
