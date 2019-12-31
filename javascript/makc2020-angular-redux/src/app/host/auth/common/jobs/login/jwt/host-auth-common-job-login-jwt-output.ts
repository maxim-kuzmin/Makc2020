// //Author Maxim Kuzmin//makc//

import { AppHostAuthUser } from '../../../../host-auth-user';

/** Хост. Аутентификация. Общее. Задания. Вход в систему. JWT. Вывод. */
export interface AppHostAuthCommonJobLoginJwtOutput {

  /**
   * Текущий пользователь.
   * @type {AppHostAuthUser}
   */
  currentUser: AppHostAuthUser;

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
