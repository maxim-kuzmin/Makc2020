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
import {AppModDummyTreeJobListGetInput} from '../../list/get/mod-dummy-tree-job-list-get-input';

/** Мод "DummyTree". Задания. Список. Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreeJobFilteredDeleteService {

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
   * @param {AppModDummyTreeJobListGetInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppCoreExecutionResult>} Результирующий поток.
   */
  execute$(
    input: AppModDummyTreeJobListGetInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-tree/filtered/delete');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.post, url, input);

    return this.appHttp.post<AppCoreExecutionResult>(url, input)
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
