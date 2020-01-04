// //Author Maxim Kuzmin//makc//

/** Хост. Часть "Auth". Перечисления. Действия. */
export enum AppHostPartAuthEnumActions {

  /**
   * Очистка.
   * @type {string}
   */
  Clear = '[AppHostAuth] Clear',

  /**
   * Текущий пользователь. Установка.
   * @type {string}
   */
  CurrentUserSet = '[AppHostAuth] CurrentUserSet',

  /**
   * Ошибка.
   * @type {string}
   */
  Error = '[AppHostAuth] Error',

  /**
   * Инициализация.
   * @type {string}
   */
  Init = '[AppHostAuth] Init',

  /**
   * URL для перенаправления просле входа в систему. Установка.
   * @type {string}
   */
  RedirectUrlSet = '[AppHostAuth] RedirectUrlSet'
}
