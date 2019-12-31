// //Author Maxim Kuzmin//makc//

import {HttpErrorResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {EMPTY, Observable} from 'rxjs';
import {AppCoreLoggingService} from '../logging/core-logging.service';
import {AppCoreNotificationService} from '../notification/core-notification.service';
import {AppCoreExecutionMethodValue} from './core-execution-method';
import {AppCoreExecutionResult} from './core-execution-result';

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
   * @returns {Observable<never>} Пустой поток.
   */
  onError(
    jobName: string,
    error: any,
    logger: AppCoreLoggingService
  ) {
    let message = `${jobName} is failed`;

    if (error instanceof HttpErrorResponse) {
      const httpError = <HttpErrorResponse>error;

      const status = httpError.status;

      if (status) {
        message += ` with HTTP status ${status}`;
      }
    }

    logger.logError(true, message, error);

    this.appNotification.showError([message]);
  }

  /**
   * Получить результирующий поток после обработки ошибки.
   * @param {string} jobName Наименование задания.
   * @param {any} error Ошибка.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @returns {Observable<never>} Пустой поток.
   */
  onError$(
    jobName: string,
    error: any,
    logger: AppCoreLoggingService
  ): Observable<never> {
    this.onError(jobName, error, logger);

    return EMPTY;
  }

  /**
   * Получить результат после обработки успеха.
   * @param {string} jobName Наименование задания.
   * @param {TResult} result Результат.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @returns {TResult} Результат.
   */
  onSuccess<TResult extends AppCoreExecutionResult>(
    jobName: string,
    result: TResult,
    logger: AppCoreLoggingService
  ): TResult {
    if (result.warningMessages && result.warningMessages.length > 0) {
      logger.logInfo(result.warningMessages.join('. '));
      this.appNotification.showInfo(result.warningMessages);
    }

    if (result.isOk) {
      if (result.successMessages && result.successMessages.length > 0) {
        logger.logInfo(result.successMessages.join('. '));

        this.appNotification.showSuccess(result.successMessages);
      } else {
        logger.logDebug(`${jobName} is successful`, result);
      }
    } else {
      if (result.errorMessages && result.errorMessages.length > 0) {
        logger.logError(false, result.errorMessages.join('. '));

        this.appNotification.showError(result.errorMessages);
      } else {
        logger.logError(false, `${jobName} is failed`, result);
      }
    }

    return result;
  }
}
