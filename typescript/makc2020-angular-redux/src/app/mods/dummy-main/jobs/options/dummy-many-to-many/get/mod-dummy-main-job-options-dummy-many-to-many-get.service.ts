// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyMainJobOptionsDummyManyToManyGetResult} from './mod-dummy-main-job-options-dummy-many-to-many-get-result';

/** Мод "DummyMain". Задания. Варианты выбора. Сущность "DummyManyToMany". Получить. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainJobOptionsDummyManyToManyGetService {

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
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppModDummyMainJobOptionsDummyManyToManyGetResult>} Результирующий поток.
   */
  execute$(
    handler: AppCoreExecutionHandler
  ): Observable<AppModDummyMainJobOptionsDummyManyToManyGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-main/options/dummy-many-to-many');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    return this.appHttp.get<AppModDummyMainJobOptionsDummyManyToManyGetResult>(url)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModDummyMainJobOptionsDummyManyToManyGetResult>(
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
