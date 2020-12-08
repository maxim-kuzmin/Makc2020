// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyMainJobListGetInput} from './mod-dummy-main-job-list-get-input';
import {AppModDummyMainJobListGetResult} from './mod-dummy-main-job-list-get-result';

/** Мод "DummyMain". Задания. Список. Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainJobListGetService {

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
   * @param {AppModDummyMainJobItemGetInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppModDummyMainJobListGetResult>} Результирующий поток.
   */
  execute$(
    input: AppModDummyMainJobListGetInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppModDummyMainJobListGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-main/list');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.get<AppModDummyMainJobListGetResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModDummyMainJobListGetResult>(
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
