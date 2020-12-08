// //Author Maxim Kuzmin//makc//

/** Хост. Часть "Auth". Пользователь. */
export interface AppHostPartAuthUser {

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
