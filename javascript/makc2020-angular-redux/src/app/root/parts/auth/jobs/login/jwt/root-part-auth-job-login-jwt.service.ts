// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostPartAuthCommonJobLoginInput} from '@app/host/parts/auth/common/jobs/login/host-part-auth-common-job-login-input';
// tslint:disable-next-line:max-line-length
import {AppHostPartAuthCommonJobLoginJwtResult} from '@app/host/parts/auth/common/jobs/login/jwt/host-part-auth-common-job-login-jwt-result';

/** Корень. Часть "Auth". Задания. Вход в систему. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPartAuthJobLoginJwtService {

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
 * @param {AppHostPartAuthCommonJobLoginInput} input Ввод.
 * @returns {Observable<AppHostPartAuthCommonJobLoginJwtResult>}
 * Поток вывода.
 */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostPartAuthCommonJobLoginInput
  ): Observable<AppHostPartAuthCommonJobLoginJwtResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('auth/login');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.post, url, input);

    return this.appHttp.post<AppHostPartAuthCommonJobLoginJwtResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppHostPartAuthCommonJobLoginJwtResult>(
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
