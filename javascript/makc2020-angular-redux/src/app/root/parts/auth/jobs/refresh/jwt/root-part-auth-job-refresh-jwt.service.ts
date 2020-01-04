// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
// tslint:disable-next-line:max-line-length
import {AppHostPartAuthCommonJobLoginJwtResult} from '@app/host/parts/auth/common/jobs/login/jwt/host-part-auth-common-job-login-jwt-result';
import {AppRootPartAuthJobRefreshJwtInput} from './root-part-auth-job-refresh-jwt-input';

/** Корень. Часть "Auth". Задания. Обновление. JWT. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPartAuthJobRefreshJwtService {

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
   * @param {AppRootPartAuthJobRefreshJwtInput} input Ввод.
   * @returns {Observable<AppHostPartAuthCommonJobLoginJwtResult>} Поток вывода.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppRootPartAuthJobRefreshJwtInput
  ): Observable<AppHostPartAuthCommonJobLoginJwtResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('auth/refresh');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.post, url, input);

    return this.appHttp.post<AppHostPartAuthCommonJobLoginJwtResult>(url, input)
      .pipe(
        map(
          output => this.appExecution.onSuccess<AppHostPartAuthCommonJobLoginJwtResult>(
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
