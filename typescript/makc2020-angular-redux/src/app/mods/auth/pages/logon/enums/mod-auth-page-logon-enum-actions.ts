// //Author Maxim Kuzmin//makc//

/** Мод "Auth". Страницы. Вход в систему. Перечисления. Действия. */
export enum AppModAuthPageLogonEnumActions {

  /**
   * Очистка.
   * @type {string}
   */
  Clear = '[AppModAuthPageLogon] Clear',

  /**
   * Загрузка.
   * @type {string}
   */
  Load = '[AppModAuthPageLogon] Load',

  /**
   * Вход в систему.
   * @type {string}
   */
  Login = '[AppModAuthPageLogon] Login',

  /**
   * Успех входа в систему.
   * @type {string}
   */
  LoginSuccess = '[AppModAuthPageLogon] Login Success',

  /**
   * Выход из системы.
   * @type {string}
   */
  Logout = '[AppModAuthPageLogout] Logout'
}
