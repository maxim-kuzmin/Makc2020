// //Author Maxim Kuzmin//makc//

/** Хост. Аутентификация. Пользователь. */
export interface AppHostAuthUser {

  /**
   * Идентификатор.
   * @type {number}
   */
  id: number;

  /**
   * Имя пользователя.
   * @type {string}
   */
  userName: string;

  /**
   * Адрес электронной почты.
   * @type {string}
   */
  email: string;

  /**
   * Полное имя.
   * @type {?string}
   */
  fullName?: string;

  /**
   * Роли.
   * @type {?string[]}
   */
  roles?: string[];
}
