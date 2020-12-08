// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyMainJobItemGetInput} from './mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobItemGetResult} from './mod-dummy-main-job-item-get-result';

/** Мод "DummyMain". Задания. Элемент. Получение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainJobItemGetService {

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
   * @returns {Observable<AppModDummyMainJobItemGetResult>} Результирующий поток.
   */
  execute$(
    input: AppModDummyMainJobItemGetInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppModDummyMainJobItemGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-main/item');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.get<AppModDummyMainJobItemGetResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModDummyMainJobItemGetResult>(
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
