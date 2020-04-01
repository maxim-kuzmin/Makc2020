// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyTreeJobListGetInput} from './mod-dummy-tree-job-list-get-input';
import {AppModDummyTreeJobListGetResult} from './mod-dummy-tree-job-list-get-result';

/** Мод "DummyTree". Задания. Список. Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreeJobListGetService {

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
   * @returns {Observable<AppModDummyTreeJobListGetResult>} Результирующий поток.
   */
  execute$(
    input: AppModDummyTreeJobListGetInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppModDummyTreeJobListGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-tree/list');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.get<AppModDummyTreeJobListGetResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModDummyTreeJobListGetResult>(
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
