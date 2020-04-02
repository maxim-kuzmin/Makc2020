// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyTreeJobItemGetInput} from '../get/mod-dummy-tree-job-item-get-input';

/** Мод "DummyTree". Задания. Элемент. Удаление. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreeJobItemDeleteService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppCoreHttpService} appHttp HTTP.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appHttp: AppCoreHttpService,
    private appNavigation: AppCoreNavigationService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppModDummyTreeJobItemGetInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppCoreExecutionResult>} Результирующий поток.
   */
  execute$(
    input: AppModDummyTreeJobItemGetInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-tree/item');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.delete, url, input);

    return this.appHttp.delete<AppCoreExecutionResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppCoreExecutionResult>(
            jobName,
            result,
            handler
          )
        ),
        catchError(
          error => this.appExecution.onError$(
            jobName,
            error,
            handler
          )
        )
      );
  }
}