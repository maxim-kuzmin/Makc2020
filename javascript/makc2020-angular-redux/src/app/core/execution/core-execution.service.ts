// //Author Maxim Kuzmin//makc//

import {HttpErrorResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {EMPTY, NEVER, Observable} from 'rxjs';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreExecutionHandler} from './core-execution-handler';
import {AppCoreExecutionMethodValue} from './core-execution-method';
import {AppCoreExecutionResult} from './core-execution-result';

/** Ядро. Выполнение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreExecutionService {

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   */
  constructor(
    private appExceptionStore: AppCoreExceptionStore
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
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<NEVER>} Пустой поток.
   */
  onError(
    jobName: string,
    error: any,
    handler: AppCoreExecutionHandler
  ) {
    let message = `${jobName} is failed`;

    if (error instanceof HttpErrorResponse) {
      const httpError = <HttpErrorResponse>error;

      const status = httpError.status;

      if (status) {
        message += ` with HTTP status ${status}`;
      }
    }

    this.appExceptionStore.runActionThrow(message, error);

    handler.onException(message, error);
  }

  /**
   * Получить результирующий поток после обработки ошибки.
   * @param {string} jobName Наименование задания.
   * @param {any} error Ошибка.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<NEVER>} Пустой поток.
   */
  onError$(
    jobName: string,
    error: any,
    handler: AppCoreExecutionHandler
  ): Observable<never> {
    this.onError(jobName, error, handler);

    return EMPTY;
  }

  /**
   * Получить результат после обработки успеха.
   * @param {string} jobName Наименование задания.
   * @param {TResult} result Результат.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {TResult} Результат.
   */
  onSuccess<TResult extends AppCoreExecutionResult>(
    jobName: string,
    result: TResult,
    handler: AppCoreExecutionHandler
  ): TResult {
    const {
      warningMessages
    } = result;

    if (warningMessages && warningMessages.length > 0) {
      handler.onWarning(warningMessages);
    }

    if (result.isOk) {
      let {
        successMessages
      } = result;

      if (!successMessages || successMessages.length < 1) {
        successMessages = [`${jobName} is successful`];
      }

      handler.onSuccess(successMessages);
    } else {
      let {
        errorMessages
      } = result;

      if (!errorMessages || errorMessages.length < 1) {
        errorMessages = [`${jobName} is failed`];
      }

      handler.onError(errorMessages);
    }

    return result;
  }
}
