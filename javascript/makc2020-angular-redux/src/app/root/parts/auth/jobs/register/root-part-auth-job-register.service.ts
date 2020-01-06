// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostPartAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-input';
import {AppHostPartAuthCommonJobRegisterResult} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-result';

/** Корень. Часть "Auth". Задания. Регистрция. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPartAuthJobRegisterService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppCoreHttpService} appHttp HTTP.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appHttp: AppCoreHttpService,
    private appNavigation: AppCoreNavigationService,
  ) { }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostPartAuthCommonJobRegisterInput} input Ввод.
   * @returns {Observable<AppHostPartAuthCommonJobRegisterResult>} Поток вывода.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostPartAuthCommonJobRegisterInput
  ): Observable<AppHostPartAuthCommonJobRegisterResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('auth/register');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.post, url, input);

    return this.appHttp.post<AppHostPartAuthCommonJobRegisterResult>(url, input)
      .pipe(
        map(result =>
          this.appExecution.onSuccess<AppHostPartAuthCommonJobRegisterResult>(
            jobName,
            result,
            logger
          )
        ),
        catchError(error =>
          this.appExecution.onError$(
            jobName,
            error,
            logger
          )
        )
      );
  }
}
