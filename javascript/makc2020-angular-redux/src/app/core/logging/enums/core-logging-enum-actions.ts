// //Author Maxim Kuzmin//makc//

/** Ядро. Логирование. Перечисления. Действия. */
export enum AppCoreLoggingEnumActions {

  /**
   * Очистка.
   * @type {string}
   */
  Clear = '[AppCoreLogging] Clear',

  /**
   * Зарегистрировать отладочное сообщение.
   * @type {string}
   */
  LogDebug = '[AppCoreLogging] LogDebug',

  /**
   * Зарегистрировать ошибку.
   * @type {string}
   */
  LogError = '[AppCoreLogging] LogError',

 /**
   * Зарегистрировать успех.
   * @type {string}
   */
  LogSuccess = '[AppCoreLogging] LogSuccess',

  /**
   * Зарегистрировать предупреждение.
   * @type {string}
   */
  LogWarning = '[AppCoreLogging] LogWarning'
}
