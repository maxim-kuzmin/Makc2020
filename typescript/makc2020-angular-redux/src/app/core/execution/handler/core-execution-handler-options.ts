// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionOptions} from '../core-execution-options';

/** Ядро. Выполнение. Обработчик. Опции. */
export class AppCoreExecutionHandlerOptions {

  /**
   * Ошибка.
   * @type {AppCoreExecutionOptions}
   */
  error = new AppCoreExecutionOptions();

  /**
   * Исключение.
   * @type {AppCoreExecutionOptions}
   */
  exception = new AppCoreExecutionOptions();

  /**
   * Успех.
   * @type {AppCoreExecutionOptions}
   */
  success = new AppCoreExecutionOptions();

  /**
   * Предупреждение.
   * @type {AppCoreExecutionOptions}
   */
  warning = new AppCoreExecutionOptions();

  /** Конструктор. */
  constructor() {
    this.error.isNotificationDisabled = true;
    this.success.isNotificationDisabled = true;
    this.warning.isNotificationDisabled = true;
  }
}
