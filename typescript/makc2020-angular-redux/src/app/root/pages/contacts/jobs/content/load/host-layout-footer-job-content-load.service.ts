// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {
  AppRootPageContactsJobContentLoadResult,
  appRootPageContactsJobContentLoadResultCreate
} from './host-layout-footer-job-content-load-result';
import {AppRootPageContactsJobContentLoadInput} from './host-layout-footer-job-content-load-input';

/** Хост. Разметка. Подвал. Задания. Содержимое. Загрузка. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPageContactsJobContentLoadService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppCoreHttpService} appHttp
   * @param {AppCoreNavigationService} appNavigation
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appHttp: AppCoreHttpService,
    private appNavigation: AppCoreNavigationService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppRootPageContactsJobContentLoadInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppRootPageContactsJobContentLoadResult>} Результирующий поток.
   */
  execute$(
    input: AppRootPageContactsJobContentLoadInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppRootPageContactsJobContentLoadResult> {
    const url = this.appNavigation.createAbsoluteUrlOfHost(
      `assets/root/pages/contacts/content/asset-root-page-contacts.content.${input.languageKey}.html`
    );

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.getText(url)
      .pipe(
        map(
          data => {
            const result = appRootPageContactsJobContentLoadResultCreate();

            result.isOk = true;
            result.data = data;

            return result;
          }
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
