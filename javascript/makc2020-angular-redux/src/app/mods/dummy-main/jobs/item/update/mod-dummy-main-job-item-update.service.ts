// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyMainJobItemGetOutput} from '../get/mod-dummy-main-job-item-get-output';
import {AppModDummyMainJobItemGetResult} from '../get/mod-dummy-main-job-item-get-result';

/** Мод "DummyMain". Задания. Элемент. Обновление. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainJobItemUpdateService {

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
  ) { }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppModDummyMainJobItemGetOutput} input Ввод.
   * @returns {Observable<AppModDummyMainJobItemGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppModDummyMainJobItemGetOutput
  ): Observable<AppModDummyMainJobItemGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-main/item');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.put, url, input);

    return this.appHttp.put<AppModDummyMainJobItemGetResult>(url, input)
      .pipe(
        map(
        result => this.appExecution.onSuccess<AppModDummyMainJobItemGetResult>(
            jobName,
            result,
            logger
          )
        ),
        catchError(
          error => this.appExecution.onError$(
            jobName,
            error,
            logger
          )
        )
      );
  }
}
