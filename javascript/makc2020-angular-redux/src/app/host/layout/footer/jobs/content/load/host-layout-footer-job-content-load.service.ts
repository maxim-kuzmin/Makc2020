// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {Observable} from 'rxjs';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {catchError, map} from 'rxjs/operators';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {
  AppHostLayoutFooterJobContentLoadResult,
  appHostLayoutFooterJobContentLoadResultCreate
} from './host-layout-footer-job-content-load-result';
import {AppHostLayoutFooterJobContentLoadInput} from './host-layout-footer-job-content-load-input';

/** Хост. Разметка. Подвал. Задания. Содержимое. Загрузка. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostLayoutFooterJobContentLoadService {

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
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostLayoutFooterJobContentLoadInput} input Ввод.
   * @returns {Observable<AppHostLayoutFooterJobContentLoadResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostLayoutFooterJobContentLoadInput
  ): Observable<AppHostLayoutFooterJobContentLoadResult> {
    const url = this.appNavigation.createAbsoluteUrlOfHost(
      `assets/host/layout/footer/content/asset-host-layout-footer.content.${input.languageKey}.html`
    );

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.getText(url)
      .pipe(
        map(
          data => {
            const result = appHostLayoutFooterJobContentLoadResultCreate();

            result.isOk = true;
            result.data = data;

            return result;
          }
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
