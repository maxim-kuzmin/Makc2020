// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-auth-common-job-register-input';
import {AppHostAuthCommonJobRegisterResult} from '@app/host/parts/auth/common/jobs/register/host-auth-common-job-register-result';

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
   * @param {AppHostAuthCommonJobRegisterInput} input Ввод.
   * @returns {Observable<AppHostAuthCommonJobRegisterResult>} Поток вывода.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostAuthCommonJobRegisterInput
  ): Observable<AppHostAuthCommonJobRegisterResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('auth/register');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.post, url, input);

    return this.appHttp.post<AppHostAuthCommonJobRegisterResult>(url, input)
      .pipe(
        map(result =>
          this.appExecution.onSuccess<AppHostAuthCommonJobRegisterResult>(
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
