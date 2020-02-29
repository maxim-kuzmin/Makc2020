// //Author Maxim Kuzmin//makc//

import {HttpErrorResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {EMPTY, Observable} from 'rxjs';
import {AppCoreLoggingService} from '../logging/core-logging.service';
import {AppCoreExecutionMethodValue} from './core-execution-method';
import {AppCoreExecutionResult} from './core-execution-result';

/** Ядро. Выполнение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreExecutionService {

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

    logger.logError(true, [message], error);
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
    const {
      warningMessages
    } = result;

    if (warningMessages && warningMessages.length > 0) {
      logger.logWarning(warningMessages);
    }

    if (result.isOk) {
      const {
        successMessages
      } = result;

      if (successMessages && successMessages.length > 0) {
        logger.logSuccess(successMessages);
      } else {
        logger.logDebug([`${jobName} is successful`], result);
      }
    } else {
      const {
        errorMessages
      } = result;

      if (errorMessages && errorMessages.length > 0) {
        logger.logError(false, errorMessages);
      } else {
        logger.logError(false, [`${jobName} is failed`], result);
      }
    }

    return result;
  }
}
