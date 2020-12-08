// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionOptions} from '@app/core/execution/core-execution-options';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppCoreExecutionHandlerOptions} from './handler/core-execution-handler-options';

/** Ядро. Выполнение. Обработчик. */
export class AppCoreExecutionHandler {

  /**
   * Функция выполнения после ошибки.
   * @type {Function}
   */
  funcExecuteAfterException: Function;

  /**
   * Функция установки опций исключения.
   * @type {(options: AppCoreExecutionOptions, error: any) => void}
   */
  funcSetExceptionOptions: (options: AppCoreExecutionOptions, error: any) => void;

  /**
   * Регистратор.
   * @type {AppCoreLoggingService}
   */
  logger: AppCoreLoggingService;

  /**
   * Извещение.
   * @type {AppCoreNotificationService}
   */
  notification: AppCoreNotificationService;

  /**
   * Опции.
   * @type {AppCoreExecutionHandlerOptions}
   */
  options = new AppCoreExecutionHandlerOptions();

  /** Включить извещение на всё. */
  enableNotificationOnAll() {
    this.options.error.isNotificationDisabled = false;
    this.options.success.isNotificationDisabled = false;
    this.options.warning.isNotificationDisabled = false;
  }

  /**
   * Обработчик ошибки.
   * @param {string[]} errorMessages Сообщения об ошибках.
   * @param {?any} error Ошибка.
   */
  onError(errorMessages: string[], error?: any) {
    const {
      isLoggingDisabled,
      isNotificationDisabled
    } = this.options.error;

    if (!isLoggingDisabled && this.logger) {
      this.logger.logError(errorMessages, error);
    }

    if (!isNotificationDisabled && this.notification) {
      this.notification.showError(errorMessages);
    }
  }

  /**
   * Обработчик исключения.
   * @param {string[]} message Сообщение.
   * @param {any} error Ошибка.
   */
  onException(message: string, error: any) {
    let {
      isLoggingDisabled,
      isNotificationDisabled
    } = this.options.exception;

    if (this.funcSetExceptionOptions) {
      const options = this.options.exception.clone();

      this.funcSetExceptionOptions(options, error);

      isLoggingDisabled = options.isLoggingDisabled;
      isNotificationDisabled = options.isNotificationDisabled;
    }

    const errorMessages = [message];

    if (!isLoggingDisabled && this.logger) {
      this.logger.logError(errorMessages, error);
    }

    if (!isNotificationDisabled && this.notification) {
      this.notification.showError(errorMessages);
    }

    if (this.funcExecuteAfterException) {
      this.funcExecuteAfterException();
    }
  }

  /**
   * Обработчик успеха.
   * @param {string[]} successMessages Сообщения об успехах.
   */
  onSuccess(successMessages: string[]) {
    const {
      isLoggingDisabled,
      isNotificationDisabled
    } = this.options.success;

    if (!isLoggingDisabled && this.logger) {
      this.logger.logSuccess(successMessages);
    }

    if (!isNotificationDisabled && this.notification) {
      this.notification.showSuccess(successMessages);
    }
  }

  /**
   * Обработчик предупреждения.
   * @param {string[]} warningMessages Предупреждающие сообщения.
   */
  onWarning(warningMessages: string[]) {
    const {
      isLoggingDisabled,
      isNotificationDisabled
    } = this.options.warning;

    if (!isLoggingDisabled && this.logger) {
      this.logger.logWarning(warningMessages);
    }

    if (!isNotificationDisabled && this.notification) {
      this.notification.showWarning(warningMessages);
    }
  }
}
