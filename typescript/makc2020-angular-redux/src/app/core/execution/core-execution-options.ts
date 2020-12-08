// //Author Maxim Kuzmin//makc//

/** Ядро. Выполнение. Опции. */
export class AppCoreExecutionOptions {

  /**
   * Признак отключения логирования.
   * @type {boolean}
   */
  isLoggingDisabled = false;

  /**
   * Признак отключения извещения.
   * @type {boolean}
   */
  isNotificationDisabled = false;

  /**
   * Корнировать.
   * @returns {AppCoreExecutionOptions} Опции.
   */
  clone(): AppCoreExecutionOptions {
    const result = new AppCoreExecutionOptions();

    result.isLoggingDisabled = this.isLoggingDisabled;
    result.isNotificationDisabled = this.isNotificationDisabled;

    return result;
  }
}
