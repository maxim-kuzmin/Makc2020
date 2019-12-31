// //Author Maxim Kuzmin//makc//

/** Хост. Аутентификация. Перечисления. Действия. */
export enum AppHostAuthEnumActions {

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
