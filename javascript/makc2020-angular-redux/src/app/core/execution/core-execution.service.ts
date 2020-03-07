// //Author Maxim Kuzmin//makc//

import {HttpErrorResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {EMPTY, Observable} from 'rxjs';
import {AppCoreLoggingService} from '../logging/core-logging.service';
import {AppCoreExecutionMethodValue} from './core-execution-method';
import {AppCoreExecutionOptions} from '@app/core/execution/core-execution-options';
import {AppCoreExecutionResult} from './core-execution-result';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';

/** Ядро. Выполнение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreExecutionService {

  /**
   * Конструктор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   */
  constructor(
    private appNotification: AppCoreNotificationService
  ) {
  }

  /**
   * Создать наименование задания.
   * @param {AppCoreExecutionMethodValue} method Метод.
   * @param {string} url URL.
   * @param {any} input Ввод.
   * @returns {string} Наименование задания.
   */
  createJobName(
    method: AppCoreExecutionMethodValue,
    url: string,
    input: any = null
  ): string {
    let result = `${method} ${url}`;

    if (input) {
      result += ` ${JSON.stringify(input)}`;
    }

    return result;
  }

  /**
   * Обработчик ошибки.
   * @param {string} jobName Наименование задания.
   * @param {any} error Ошибка.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppCoreExecutionOptions} options Параметры.
   * @returns {Observable<never>} Пустой поток.
   */
  onError(
    jobName: string,
    error: any,
    logger: AppCoreLoggingService,
    options: AppCoreExecutionOptions = null
  ) {
    if (!options) {
      options = new AppCoreExecutionOptions();
    }

    let message = `${jobName} is failed`;

    if (error instanceof HttpErrorResponse) {
      const httpError = <HttpErrorResponse>error;

      const status = httpError.status;

      if (status) {
        message += ` with HTTP status ${status}`;
      }
    }

    const errorMessages = [message];

    logger.logError(true, errorMessages, error);

    const {
      isErrorNotificationNeeded
    } = options;

    if (isErrorNotificationNeeded) {
      this.appNotification.showError(errorMessages);
    }
  }

  /**
   * Получить результирующий поток после обработки ошибки.
   * @param {string} jobName Наименование задания.
   * @param {any} error Ошибка.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppCoreExecutionOptions} options Параметры.
   * @returns {Observable<never>} Пустой поток.
   */
  onError$(
    jobName: string,
    error: any,
    logger: AppCoreLoggingService,
    options: AppCoreExecutionOptions = null
  ): Observable<never> {
    this.onError(jobName, error, logger, options);

    return EMPTY;
  }

  /**
   * Получить результат после обработки успеха.
   * @param {string} jobName Наименование задания.
   * @param {TResult} result Результат.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppCoreExecutionOptions} options Параметры.
   * @returns {TResult} Результат.
   */
  onSuccess<TResult extends AppCoreExecutionResult>(
    jobName: string,
    result: TResult,
    logger: AppCoreLoggingService,
    options: AppCoreExecutionOptions = null
  ): TResult {
    if (!options) {
      options = new AppCoreExecutionOptions();
    }

    const {
      warningMessages
    } = result;

    if (warningMessages && warningMessages.length > 0) {
      logger.logWarning(warningMessages);
    }

    if (result.isOk) {
      let {
        successMessages
      } = result;

      if (successMessages && successMessages.length > 0) {
        logger.logSuccess(successMessages);
      } else {
        successMessages = [`${jobName} is successful`];

        logger.logDebug(successMessages, result);
      }

      const {
        isSuccessNotificationNeeded
      } = options;

      if (isSuccessNotificationNeeded) {
        this.appNotification.showSuccess(successMessages);
      }
    } else {
      let {
        errorMessages
      } = result;

      if (errorMessages && errorMessages.length > 0) {
        logger.logError(false, errorMessages);
      } else {
        errorMessages = [`${jobName} is failed`];

        logger.logError(false, errorMessages, result);
      }

      const {
        isErrorNotificationNeeded
      } = options;

      if (isErrorNotificationNeeded) {
        this.appNotification.showError(errorMessages);
      }
    }

    return result;
  }
}
