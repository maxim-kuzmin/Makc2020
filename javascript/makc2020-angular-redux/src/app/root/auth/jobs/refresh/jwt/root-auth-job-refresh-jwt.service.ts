// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostAuthCommonJobLoginJwtResult} from '@app/host/auth/common/jobs/login/jwt/host-auth-common-job-login-jwt-result';
import {AppRootAuthJobRefreshJwtInput} from './root-auth-job-refresh-jwt-input';

/** Мод "Auth". Задания. Обновление. JWT. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootAuthJobRefreshJwtService {

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
   * @param {AppRootAuthJobRefreshJwtInput} input Ввод.
   * @returns {Observable<AppHostAuthCommonJobLoginJwtResult>} Поток вывода.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppRootAuthJobRefreshJwtInput
  ): Observable<AppHostAuthCommonJobLoginJwtResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('auth/refresh');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.post, url, input);

    return this.appHttp.post<AppHostAuthCommonJobLoginJwtResult>(url, input)
      .pipe(
        map(
          output => this.appExecution.onSuccess<AppHostAuthCommonJobLoginJwtResult>(
            jobName,
            output,
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
